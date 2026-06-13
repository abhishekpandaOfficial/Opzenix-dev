using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Models;
using Opzenix.BuildingBlocks.AI.Prompts.Reviews;
using Opzenix.BuildingBlocks.AI.Providers.Gemini.Parsing;

namespace Opzenix.BuildingBlocks.AI.Providers.Gemini;

public sealed class GeminiProvider
    : IAiProvider
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly GeminiOptions _options;

    public string Name => "Gemini";
    public string Model => _options.Model;

    public GeminiProvider(
        IHttpClientFactory httpClientFactory,
        IOptions<GeminiOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<AiReviewResponse> ReviewAsync(
        AiReviewRequest request,
        CancellationToken cancellationToken)
    {
        var client =
            _httpClientFactory.CreateClient();

        var prompt =
            ReviewPromptBuilder.Build(
                request.FileName,
                request.Content,
                request.ReviewType);

        var response =
            await client.PostAsJsonAsync(
                $"https://generativelanguage.googleapis.com/v1beta/models/{_options.Model}:generateContent?key={_options.ApiKey}",
                new GeminiRequest
                {
                    Contents =
                    [
                        new GeminiContent
                        {
                            Parts =
                            [
                                new GeminiPart
                                {
                                    Text = prompt
                                }
                            ]
                        }
                    ]
                },
                cancellationToken);

        response.EnsureSuccessStatusCode();

        var result =
            await response.Content.ReadFromJsonAsync<
                GeminiResponse>(
                cancellationToken);

        var text =
            result?.Candidates?
                .FirstOrDefault()?
                .Content?
                .Parts?
                .FirstOrDefault()?
                .Text
            ?? "[]";

        Console.WriteLine();
        Console.WriteLine("========== GEMINI RESPONSE ==========");
        Console.WriteLine(text);
        Console.WriteLine("=====================================");
        Console.WriteLine();

        return new AiReviewResponse
        {
            Findings =
                GeminiResponseParser.Parse(
                    request.FileName,
                    text)
        };
    }
}