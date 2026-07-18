# API Specification

## Base URL: `/api/v1`

Tüm yetki gerektiren endpoint'lerde `Authorization: Bearer <token>` header'ı bulunmalıdır.

---

## 1. Authentication
- `POST /auth/login`: Authenticate user and return JWT + Refresh Token.
- `POST /auth/refresh`: Refresh JWT token.

## 2. Customer (Mobile)
- `GET /customer/profile`: Get logged-in user profile.
- `GET /customer/vehicles`: List user's vehicles.
- `GET /customer/policies`: List policies for user's vehicles.
- `GET /customer/policies/{id}/coverage`: Get coverage details.

## 3. Claims (Mobile & Admin)
- `POST /claims`: Create a new claim (requires active policy).
- `POST /claims/{id}/photos`: Upload claim photos.
- `GET /claims/{id}`: View claim details.
- `GET /customer/claims`: List claims for customer.
- `GET /admin/claims`: List all claims (Admin).
- `PUT /admin/claims/{id}/status`: Update claim status (Admin).
- `POST /admin/claims/{id}/ai-summary`: Trigger/Generate AI Summary (Admin).

## 4. Policy Requests
- `POST /policy-requests/renewal`: Create renewal request.
- `POST /policy-requests/update`: Create policy update request.
- `GET /customer/policy-requests`: List user's requests.
- `GET /admin/policy-requests`: List all pending requests (Admin).
- `PUT /admin/policy-requests/{id}/offer`: Enter manual dummy offer (Admin).

## 5. Admin Management
- `GET /admin/dashboard`: Get KPI cards and stats.
- `GET /admin/customers`: List all customers.
- `GET /admin/vehicles`: List all vehicles.
- `GET /admin/policies`: List all policies.
- `GET /admin/activity-logs`: View system activity logs.
