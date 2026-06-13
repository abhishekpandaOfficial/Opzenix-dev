# Backend Architecture

## Architecture Style

Modular Monolith

Patterns:

* Domain Driven Design
* CQRS
* Clean Architecture
* Repository Pattern
* Provider Pattern
* Dependency Injection

---

## Modules

### Identity

Authentication and authorization.

### Repositories

Repository synchronization and Git provider integrations.

### Reviews

Review orchestration and findings management.

### Knowledge Graph

Engineering knowledge graph and dependency intelligence.

### AI

AI abstraction layer and provider integrations.

---

## Data Flow

Repository

↓

Pull Request

↓

Review

↓

AI Provider

↓

Findings

↓

Analytics

↓

Dashboard
