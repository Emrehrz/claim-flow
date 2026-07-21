# Sprint 00 — Project Foundation

## Sprint Goal
Establish the project foundation, repository structure, and local development environment so all later modules can be implemented step by step without changing the product design.

## Business Context
This sprint exists to provide a stable technical base for the claim management platform. It enables the backend, dashboard, and mobile codebases to be initialized consistently before any business module work begins.

## Scope
- Initialize the backend solution structure and core layers.
- Prepare the dashboard and mobile application shells.
- Configure local development infrastructure and database connectivity.
- Set up shared project conventions needed by all future sprints.

## Deliverables
- Solution and project structure
- Backend layer structure
- Entity Framework Core configuration
- PostgreSQL connection setup
- Docker and Docker Compose setup
- Shared dependency injection baseline
- Initial dashboard and mobile app scaffolds
 - Basic environment configuration files

## Implementation Order
1. Create the solution and base project structure.
2. Set up the backend layers and shared abstractions.
3. Configure PostgreSQL and EF Core integration.
4. Add Docker and local environment configuration.
5. Bootstrap dashboard and mobile application shells.
6. Verify the application can run in the local environment.

## Acceptance Criteria
- The solution builds successfully.
- The backend connects to the local PostgreSQL instance.
- The repository structure matches the documented architecture.
- The dashboard and mobile shells can be started without business features being implemented.
- No scope beyond setup and infrastructure is introduced.

## Out of Scope
- Authentication or authorization workflows.
- Any domain entity or business rule implementation.
- CRUD operations for business modules.
- UI feature screens beyond the initial application shells.

## Related Documentation
- docs/01-project-overview.md
- docs/04-erd.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md
- docs/11-coding-standards.md

## Suggestions
- Keep environment setup scripts isolated from business modules to reduce cross-sprint coupling.
- If build or compose commands grow, split them into dedicated developer scripts later without changing the architecture.
