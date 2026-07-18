# Sprint 0: Setup & Architecture

## 1. Objective
Proje altyapısının kurulması, mimari temellerin atılması ve geliştirme ortamlarının hazır hale getirilmesidir.

## 2. Deliverables
*   ASP.NET Core projesinin "Clean Architecture" katmanlarıyla (Domain, Application, Infrastructure, Presentation) oluşturulması.
*   React (Admin Dashboard) ve React Native (Mobile App) başlangıç projelerinin ayağa kaldırılması.
*   Entity Framework Core ve PostgreSQL bağlantı konfigürasyonlarının yapılması.
*   Repository Pattern altyapısının (Generic Repository Interfaces & Implementations) kurulması.
*   Docker ve `docker-compose.yml` dosyasının yerel geliştirme ortamı için hazırlanması.

## 3. Acceptance Criteria
*   Uygulamalar hata vermeden (Compiles) derlenmeli ve çalıştırılabilmelidir.
*   Docker üzerinden PostgreSQL konteyneri ayağa kalkmalı ve API başarıyla bağlanabilmelidir.
*   Projede tanımlı katmanlar arası bağımlılıklar ve Dependency Injection (DI) sorunsuz çalışmalıdır (Domain'in hiçbir dış katmana bağımlı olmaması kuralına uyulmalı).
*   Gereksiz varsayılan (Örn: WeatherForecast) dosyalar projeden temizlenmelidir.

## 4. Out of Scope
*   Herhangi bir business logic, CRUD işlemi veya Entity modellemesi (Altyapı hariç).
*   Kimlik doğrulama, JWT mekanizması ve Login işlemi.
*   Arayüz (UI) görsel tasarımlarının veya ekran kodlamalarının kodlanması.
