# AI Providers

## Current Providers

### Gemini

Model:

* gemini-2.5-flash

Purpose:

* Production AI reviews

### RuleBased

Purpose:

* Fallback engine
* Offline analysis

## Provider Selection

Configured through:

AI:DefaultProvider

Example:

Gemini

RuleBased

## Future Providers

OpenAI
Claude
DeepSeek
Azure OpenAI
AWS Bedrock

## Architecture

IAiProvider

```
├── GeminiProvider
├── RuleBasedProvider
├── OpenAiProvider
├── ClaudeProvider
└── DeepSeekProvider
```
