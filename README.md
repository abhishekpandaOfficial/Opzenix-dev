# Opzenix

> AI-Native Engineering Intelligence Platform

Opzenix is an enterprise-grade AI-powered software engineering platform that helps teams review code, analyze repositories, build knowledge graphs, understand architecture, automate engineering workflows, and orchestrate multiple AI agents across the software development lifecycle.

---

# Vision

Build the operating system for modern software engineering.

Opzenix combines:

* AI Code Review
* Repository Intelligence
* Knowledge Graphs
* Multi-Agent Systems
* Engineering Analytics
* AI Routing
* Autonomous Engineering Workflows

into a single platform.

---

# Core Principles

* AI First
* Modular Architecture
* Enterprise Ready
* Cloud Native
* Multi Tenant
* Extensible Provider Architecture
* Agent Driven Workflows
* Vendor Agnostic AI

---

# Current Development Status

## Phase 1 — Foundation

### Identity Module

Status: ✅ Completed

Features:

* Organizations
* Users
* Memberships
* Roles
* Permissions
* EF Core Migrations
* PostgreSQL Persistence

---

### Repositories Module

Status: ✅ Completed

Features:

* Repository Sync
* Branch Sync
* Commit Sync
* Pull Request Sync
* Pull Request File Sync
* GitHub Integration

Entities:

* Repository
* Branch
* Commit
* PullRequest
* PullRequestFile

---

### Reviews Module

Status: ✅ MVP Completed

Features:

* Create Review
* Generate Review
* Review Metrics
* Review Findings
* Review Summary
* Review Status Tracking
* Get Review
* Get Reviews
* Get Findings

Metrics:

* Files Analyzed
* Lines Analyzed
* Findings Count
* Started At
* Completed At

---

### AI Foundation

Status: ✅ Completed

Components:

* IAiProvider
* IAiProviderFactory
* AiOptions
* RuleBasedProvider
* Configuration Driven Provider Selection

Architecture:

Review Engine
↓
IAiProviderFactory
↓
IAiProvider
↓
Provider Implementation

Current Provider:

* RuleBasedProvider

Future Providers:

* QwenProvider
* OpenAIProvider
* ClaudeProvider
* GeminiProvider

---

# Architecture

## High Level Architecture

Client
↓
API Gateway
↓
Application Modules
↓
AI Providers
↓
Workers
↓
Database

---

## Solution Structure

Opzenix.Api

Opzenix.BuildingBlocks

Opzenix.BuildingBlocks.AI

Modules

* Identity
* Repositories
* Reviews
* Projects
* KnowledgeGraph

Workers

* AI
* Repository
* Review
* Graph

Infrastructure

* PostgreSQL
* GitHub
* Ollama
* OpenAI
* Claude
* Gemini

---

# AI Provider Architecture

IAiProvider
↓
IAiProviderFactory
↓
Provider Resolution
↓
Review Pipeline

Providers:

* RuleBasedProvider
* QwenProvider
* OpenAIProvider
* ClaudeProvider
* GeminiProvider

Provider selection is configuration driven.

Example:

{
"AI": {
"DefaultProvider": "Qwen"
}
}

---

# Agents Roadmap

## Review Agent

Status: 🚧 In Progress

Responsibilities:

* Code Review
* Security Analysis
* Maintainability Analysis
* Performance Analysis
* Architecture Review

---

## Repository Agent

Status: 🚧 Planned

Responsibilities:

* Repository Discovery
* Sync Management
* Repository Intelligence

---

## Knowledge Graph Agent

Status: 🚧 Planned

Responsibilities:

* Dependency Mapping
* Architecture Graph
* Service Relationships
* Ownership Mapping

---

## Security Agent

Status: 🚧 Planned

Responsibilities:

* Secret Detection
* Vulnerability Detection
* Dependency Analysis

---

## Architecture Agent

Status: 🚧 Planned

Responsibilities:

* Design Review
* Layer Validation
* Bounded Context Validation
* Architecture Drift Detection

---

## Performance Agent

Status: 🚧 Planned

Responsibilities:

* Query Analysis
* Performance Bottlenecks
* Resource Optimization

---

## AI Router Agent

Status: 🚧 Planned

Responsibilities:

* Provider Selection
* Cost Optimization
* Model Benchmarking
* Intelligent Routing

---

# Current Milestones

## Completed

* Identity Module
* Repository Module
* Review Module MVP
* AI Provider Abstraction
* RuleBasedProvider
* Review Metrics
* Review APIs

---

## In Progress

* QwenProvider
* Local AI Integration
* Ollama Integration

---

## Planned

* OpenAI Provider
* Claude Provider
* Gemini Provider
* Multi Agent Review Pipeline
* Review Worker
* Knowledge Graph
* Engineering Analytics
* SaaS Dashboard

---

# Development Roadmap

## Phase 2

AI Providers

* Qwen
* OpenAI
* Claude
* Gemini

Review Profiles

* Security Review
* Performance Review
* Architecture Review

---

## Phase 3

Multi Agent Reviews

Reviewer Agent
↓
Security Agent
↓
Architecture Agent
↓
Performance Agent

↓

Unified Report

---

## Phase 4

Knowledge Graph

* Services
* Repositories
* Ownership
* Dependencies

---

## Phase 5

Engineering Intelligence Platform

* Dashboards
* Analytics
* AI Insights
* Engineering Metrics

---

# Technology Stack

Backend

* .NET 10
* ASP.NET Core
* MediatR
* EF Core
* PostgreSQL

AI

* Ollama
* Qwen
* OpenAI
* Claude
* Gemini

Infrastructure

* Docker
* Kubernetes
* Azure

Observability

* OpenTelemetry
* Prometheus
* Grafana

---

# Project Status

Current Version:

v0.1.0-alpha

Current Focus:

QwenProvider + Ollama Integration

Next Milestone:

First AI Powered Review using Qwen
