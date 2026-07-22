# Sprint 01 — Kimlik Doğrulama Modülü (Authentication Module)

**Durum (Status):** Tamamlandı

## Sprint Amacı
Platforma ve gelecekte korunan modüllere güvenli erişim için gereken kimlik doğrulama (authentication) temelini uygulamak.

## İş Bağlamı
Kimlik doğrulama, tüm müşteri ve yönetici (admin) etkileşimlerinin giriş noktasıdır. Sistem, herhangi bir iş modülü dışa açılmadan önce güvenilir bir giriş (login) akışına ve token tabanlı erişim kontrolüne ihtiyaç duyar.

## Kapsam
- Kullanıcı doğrulaması (User authentication) ve token oluşturma.
- Access token ve refresh token desteği.
- Admin ve Müşteri (Customer) kullanıcılar için rol tabanlı erişim kontrolü.
- İstemci uygulamaları (client applications) için backend login endpoint'i ve korumalı rota (protected route) desteği.

## Çıktılar
- Kullanıcı kimlik doğrulama domain desteği
- Login istek (request) ve yanıt (response) DTO'ları
- JWT token servisi
- Refresh token işleme
- Kimlik doğrulama (Authentication) controller'ı
- Kimlik doğrulama API endpoint'leri
- Login girişleri için validasyon kuralları
- Dashboard ve mobil için korumalı rota (protected route) entegrasyonu
- Kimlik doğrulama unit testleri

## Uygulama Sırası
1. Kimlik doğrulama (authentication) kontratlarını ve DTO'larını tanımla.
2. Kullanıcı kimlik bilgisi (credential) doğrulaması ekle.
3. JWT ve refresh token oluşturma özelliklerini ekle.
4. Login ve refresh endpoint'lerini dışa aç.
5. İstek (request) validasyonu ve yetkilendirme (authorization) bağlantılarını ekle.
6. İstemcilerdeki korumalı rota (protected route) işlemlerini entegre et.
7. Login ve token akışları için unit testler ekle.

## Kabul Kriterleri
- Geçerli kimlik bilgileri, JWT tabanlı kimliği doğrulanmış bir yanıt döndürür.
- Geçersiz kimlik bilgileri, standart bir yetkisiz (unauthorized) yanıt döndürür.
- Korumalı endpoint'ler, kimliği doğrulanmamış (unauthenticated) istekleri reddeder.
- İstemci uygulamaları, yayınlanan token'ı saklayabilir ve kimliği doğrulanmış gezinme (navigation) için kullanabilir.
- Kimlik doğrulama davranışı, belgelenen API kontratıyla uyumlu kalır.

## Kapsam Dışı
- Kayıt olma (Register) akışı.
- Şifre sıfırlama (Password reset) veya e-posta doğrulama.
- Müşteri, araç, poliçe, hasar veya talep (request) özellikleri.
- Dashboard analitiği veya aktivite loglama.

## İlgili Dokümantasyon
- docs/01-project-overview.md
- docs/03-business-rules.md
- docs/05-api-spec.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md

## Öneriler
- Kimlik doğrulama rotalarını ve token işlemlerini iş modülü controller'larından ayrı tutun.
- Daha sonraki bir sprint'in ek rol iddialarına (role claims) ihtiyacı olursa, bunları login kontratını değiştirmeden ekleyin.
