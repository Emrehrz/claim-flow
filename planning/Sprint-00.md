# Sprint 00 — Proje Altyapısı (Project Foundation)

**Durum (Status):** Tamamlandı

## Sprint Amacı
Proje altyapısını, depo (repository) yapısını ve yerel geliştirme ortamını kurarak sonraki tüm modüllerin ürün tasarımını değiştirmeden adım adım uygulanabilmesini sağlamak.

## İş Bağlamı
Bu sprint, hasar yönetim platformu için kararlı bir teknik temel sağlamak amacıyla mevcuttur. Herhangi bir iş modülü üzerinde çalışmaya başlamadan önce backend, dashboard ve mobil kod tabanlarının tutarlı bir şekilde başlatılmasını sağlar.

## Kapsam
- Backend çözüm yapısının (solution structure) ve temel katmanların başlatılması.
- Dashboard ve mobil uygulama çatıların (shells) hazırlanması.
- Yerel geliştirme altyapısının ve veritabanı bağlantısının yapılandırılması.
- Gelecekteki tüm sprint'lerin ihtiyaç duyduğu ortak proje standartlarının (conventions) ayarlanması.

## Çıktılar
- Solution ve proje yapısı
- Backend katman yapısı
- Entity Framework Core yapılandırması
- PostgreSQL bağlantı kurulumu
- Docker ve Docker Compose kurulumu
- Ortak bağımlılık enjeksiyonu (dependency injection) temeli
- İlk dashboard ve mobil uygulama taslakları
 - Temel ortam (environment) yapılandırma dosyaları

## Uygulama Sırası
1. Solution ve temel proje yapısını oluştur.
2. Backend katmanlarını ve ortak soyutlamaları (abstractions) ayarla.
3. PostgreSQL ve EF Core entegrasyonunu yapılandır.
4. Docker ve yerel ortam yapılandırmasını ekle.
5. Dashboard ve mobil uygulama çatılarını başlat.
6. Uygulamanın yerel ortamda çalıştığını doğrula.

## Kabul Kriterleri
- Solution başarıyla derlenir (builds).
- Backend, yerel PostgreSQL instancena bağlanır.
- Depo (repository) yapısı belgelenen mimariyle eşleşir.
- Dashboard ve mobil uygulama çatıları, iş özellikleri (business features) uygulanmadan başlatılabilir.
- Kurulum ve altyapı dışında hiçbir kapsam eklenmez.

## Kapsam Dışı
- Kimlik doğrulama (Authentication) veya yetkilendirme (authorization) akışları.
- Herhangi bir domain entity veya iş kuralı (business rule) uygulaması.
- İş modülleri için CRUD işlemleri.
- Başlangıç uygulama çatıları dışında kalan kullanıcı arayüzü (UI) özellik ekranları.

## İlgili Dokümantasyon
- docs/01-project-overview.md
- docs/04-erd.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md
- docs/11-coding-standards.md

## Öneriler
- Sprint'ler arası bağımlılığı azaltmak için ortam (environment) hazırlık script'lerini iş modüllerinden izole tutun.
- Derleme (build) veya compose komutları büyürse, bunları daha sonra mimariyi değiştirmeden özel geliştirici script'lerine bölün.
