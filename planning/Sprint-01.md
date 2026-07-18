# Sprint 01 — Authentication Module

## Sprint Goal
Implement the authentication foundation needed for secure access to the platform and future protected modules.

## Business Context
Authentication is the entry point for all customer and admin interactions. The system needs a reliable login flow and token-based access control before any business module can be exposed.

## Scope
- User authentication and token issuance.
- Access token and refresh token support.
- Role-aware access control for Admin and Customer users.
- Backend login endpoint and protected route support for client applications.

## Deliverables
- User authentication domain support
- Login request and response DTOs
- JWT token service
- Refresh token handling
- Authentication controller
- Authentication API endpoints
- Validation rules for login input
- Protected route integration for dashboard and mobile
- Authentication unit tests

## Implementation Order
1. Define authentication contracts and DTOs.
2. Implement user credential verification.
3. Add JWT and refresh token generation.
4. Expose login and refresh endpoints.
5. Add request validation and authorization wiring.
6. Integrate protected route handling in clients.
7. Add unit tests for login and token flows.

## Acceptance Criteria
- Valid credentials return a JWT-based authenticated response.
- Invalid credentials return a standard unauthorized response.
- Protected endpoints reject unauthenticated requests.
- Client applications can store and use the issued token for authenticated navigation.
- Authentication behavior remains aligned with the documented API contract.

## Out of Scope
- Register flow.
- Password reset or email verification.
- Customer, vehicle, policy, claim, or request features.
- Dashboard analytics or activity logging.

## Related Documentation
- docs/01-project-overview.md
- docs/03-business-rules.md
- docs/05-api-spec.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md

## Suggestions
- Keep authentication routes and token handling separate from business module controllers.
- If a later sprint needs additional role claims, add them without changing the login contract.
