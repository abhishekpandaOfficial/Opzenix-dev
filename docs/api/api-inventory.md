# API Inventory

## Dashboard

GET /api/dashboard/overview

GET /api/dashboard/recent-reviews

GET /api/dashboard/top-repositories

GET /api/dashboard/activity

---

## Analytics

GET /api/analytics/findings

GET /api/analytics/providers

GET /api/analytics/reviews-over-time

---

## Findings

GET /api/findings

GET /api/findings?severity=High

GET /api/findings?category=Security

---

## Reviews

POST /api/reviews

POST /api/reviews/{reviewId}/generate

GET /api/reviews

GET /api/reviews/{reviewId}

GET /api/reviews/{reviewId}/findings

GET /api/reviews/{reviewId}/summary

---

## Repositories

POST /api/repositories

GET /api/repositories/{id}

GET /api/repositories/organization/{organizationId}

GET /api/repositories/github/{owner}/{repository}

GET /api/repositories/github/{owner}/{repository}/branches

GET /api/repositories/github/{owner}/{repository}/commits/{branch}

GET /api/repositories/github/{owner}/{repository}/pullrequests

POST /api/repositories/{repositoryId}/sync-branches

POST /api/repositories/{repositoryId}/branches/{branchId}/sync-commits

POST /api/repositories/{repositoryId}/sync-pullrequests

POST /api/repositories/pullrequests/{pullRequestId}/sync-files
