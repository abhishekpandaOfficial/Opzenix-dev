# Review Agent Architecture

## Goal

Opzenix Review Agent performs automated pull request reviews using AI and rule-based analysis.

## Workflow

Repository
↓
Pull Request Sync
↓
Pull Request Files
↓
Create Review
↓
Generate Review
↓
AI Provider
↓
Findings
↓
Analytics
↓
Dashboard

## Supported Providers

* Gemini
* RuleBased

Future:

* OpenAI
* Claude
* DeepSeek
* Azure OpenAI

## Review Types

* General
* Security
* Performance
* Architecture
* Maintainability

## Output

Severity | Category | Message | Recommendation
