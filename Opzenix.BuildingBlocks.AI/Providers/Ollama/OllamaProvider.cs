using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Models;
using Opzenix.BuildingBlocks.AI.Prompts.Reviews;
using Opzenix.BuildingBlocks.AI.Providers.Ollama.Parsing;

namespace Opzenix.BuildingBlocks.AI.Providers.Ollama;

public sealed class OllamaProvider
    : IAiProvider
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly OllamaOptions _options;

    public string Name => "Ollama";

    public OllamaProvider(
        IHttpClientFactory httpClientFactory,
        IOptions<OllamaOptions> options)
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
                $"{_options.BaseUrl}/api/generate",
                new OllamaRequest
                {
                    Model = _options.Model,
                    Prompt = prompt,
                    Stream = false
                },
                cancellationToken);

        response.EnsureSuccessStatusCode();

        var result =
            await response.Content.ReadFromJsonAsync<
                OllamaResponse>(
                cancellationToken);
        
        Console.WriteLine(
            "========== OLLAMA RESPONSE ==========");

        Console.WriteLine(
            result?.Response);

        Console.WriteLine(
            "=====================================");

        var findings =
            OllamaResponseParser.Parse(
                request.FileName,
                result?.Response ?? string.Empty);

        return new AiReviewResponse
        {
            Findings = findings
        };
    }
}