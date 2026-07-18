# Sprint 02 — Customer & Vehicle Module

## Sprint Goal
Implement the customer and vehicle foundation so customer ownership and vehicle records can be managed consistently.

## Business Context
Customers and their vehicles are the core actors of the claim flow. This module provides the identity and ownership data required by policy, claim, and request modules.

## Scope
- Customer-facing profile data.
- Vehicle ownership and list management.
- Admin-managed customer and vehicle maintenance.
- Ownership-aware access to user vehicles.

## Deliverables
- Customer/user entity support
- Vehicle entity support
- Customer and vehicle DTOs
- Customer and vehicle repository layer
- Customer and vehicle service layer
- Validation for vehicle inputs
- Customer and vehicle controller(s)
- Customer and vehicle API endpoints
- Database migration for vehicle records
- Unit tests for customer and vehicle operations

## Implementation Order
1. Confirm customer and vehicle domain modeling.
2. Add DTOs and validation rules.
3. Implement repositories for ownership-aware data access.
4. Build services for customer and vehicle operations.
5. Expose controllers and API endpoints.
6. Add database migration and seed adjustments if needed.
7. Add unit tests for ownership and CRUD behavior.

## Acceptance Criteria
- Admin users can list and manage customer and vehicle records.
- Customers can only access their own vehicles.
- Validation prevents invalid vehicle data from being saved.
- The module is implemented without introducing policy or claim behavior.

## Out of Scope
- Policy management.
- Claim creation or claim media handling.
- Policy request flows.
- Reporting or dashboard analytics.

## Related Documentation
- docs/01-project-overview.md
- docs/04-erd.md
- docs/05-api-spec.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md

## Suggestions
- Keep customer ownership rules centralized so later modules can reuse them.
- Preserve the current entity naming from the ERD even if UI copy uses customer language.
