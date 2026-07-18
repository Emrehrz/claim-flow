# Sprint 1: Authentication & Authorization

## 1. Objective
Sistemin temel kimlik doğrulama, yetkilendirme mekanizmasının ve kullanıcı erişim yönetiminin oluşturulmasıdır.

## 2. Deliverables
*   **User Entity:** Domain katmanında `User` entity'sinin (Admin ve Customer rolleriyle) modellenmesi.
*   **JWT Service:** Infrastructure katmanında Token oluşturma servislerinin (Access ve Refresh Token) yazılması.
*   **Auth Endpoints:** `POST /api/auth/login` endpoint'inin geliştirilmesi.
*   **Frontend & Mobile:** Token'ı yerel depolamada güvenle saklama, Axios interceptor'ları ve `react-router` / `react-navigation` ile protected route (korumalı rota) mekanizmaları.
*   **ActivityLog Foundation:** Gelecekte sistem hareketlerini izleyecek mekanizmanın DbContext üzerinden tetikleyicilerinin altyapısının atılması.

## 3. Acceptance Criteria
*   Kullanıcı geçersiz credential'lar girdiğinde 401 Unauthorized mesajını standart JSON Response formatında almalıdır.
*   Geçerli giriş yapıldığında JWT oluşturulmalı ve Frontend arayüzünde kullanıcı rolüne uygun dashboard ekranına yönlendirmelidir.
*   Özel uç noktalara, geçerli bir header (`Bearer <Token>`) olmadan erişim kesinlikle reddedilmelidir.
*   FluentValidation ve Mapster paketleri bu yapı üzerinde başarıyla çalışmalıdır.

## 4. Out of Scope
*   Kayıt ol (Register) API'si (Sisteme müşterilerin Admin tarafından veya arka planda tanımlandığı varsayılmaktadır).
*   Şifremi unuttum akışı ve Mail (SMTP) servis entegrasyonu.
*   User profilindeki araç (Vehicle) veya poliçe detaylarının gösterimi.
