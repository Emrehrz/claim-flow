# 9. Development Roadmap

Aşağıda MVP'nin hayata geçirilmesi için planlanan iteratif geliştirme süreçleri (Sprint'ler) listelenmiştir.

## Sprint 0: Environment & Core Setup
*   **Objective:** Geliştirme altyapısının kurulması.
*   **Deliverables:** Solution yapısının oluşturulması, Git reposu konfigürasyonları, Docker ve docker-compose dosyalarının hazırlanması, veritabanı bağlantısı, boş React ve React Native projelerinin ayaklandırılması.
*   **Acceptance Criteria:** Her üç projenin (API, Dashboard, Mobile) sorunsuz bir şekilde derlenmesi, Docker Compose ile PostgreSQL tabanının ayağa kalkması ve birbirleriyle ping/pong atabilmesi.
*   **Out of Scope:** Herhangi bir business feature veya ekran kodlaması.

## Sprint 1: Security & Authentication
*   **Objective:** Kullanıcı doğrulama altyapısının inşası.
*   **Deliverables:** JWT entegrasyonu, Login endpointi, Refresh token mekanizması, Authorization rollerinin (Admin/Customer) belirlenmesi ve frontend korumalı (protected) yönlendirmelerinin ayarlanması.
*   **Acceptance Criteria:** Backend'in geçerli bir JWT sağlaması, Frontend'in login yapıp token'ı güvenli şekilde saklaması ve Admin/Customer rollerine özel sayfalara erişimin sağlanması.
*   **Out of Scope:** Şifremi Unuttum fonksiyonu, Mail onayları.

## Sprint 2: Core Entities (User & Vehicle)
*   **Objective:** Müşteri ve araç yönetiminin temelleri.
*   **Deliverables:** User ve Vehicle entity'lerinin oluşturulması. İlgili CRUD API endpointlerinin yazılması, Dashboard üzerinden bu verilerin listelenebilmesi.
*   **Acceptance Criteria:** Adminlerin müşteri ve araçları listeleyebilmesi; Customeların yalnızca kendi profilini ve araçlarını görüntüleyebilmesi.
*   **Out of Scope:** Poliçe ve hasar bağlamı işlemleri.

## Sprint 3: Policy Management
*   **Objective:** Poliçe oluşturma ve takip özellikleri.
*   **Deliverables:** Policy entity ve CRUD işlemleri. Kapsam özetinin (Coverage) yönetimi.
*   **Acceptance Criteria:** Admin paneli üzerinden aktif, süresi dolmuş poliçelerin yönetilmesi. Müşterinin, mobil ve web platformlarında kendine ait poliçeleri aktif/pasif ayrımı ile görmesi.
*   **Out of Scope:** Online pos tahsilatı ve ödeme altyapısı.

## Sprint 4: Claims Management
*   **Objective:** Hasar bildirim modülünün uçtan uca devreye alınması.
*   **Deliverables:** Claim entity'si, hasar ihbar endpoint'leri, durum (Status) güncelleme ve zaman çizelgesi (Timeline) mantığı.
*   **Acceptance Criteria:** Müşterinin hasar anında ihbar oluşturabilmesi; Adminlerin gelen hasarı görüp statüsünü (In Review, Approved, vs.) güncelleyebilmesi.
*   **Out of Scope:** Hasar fotoğraflarının yüklenmesi ve AI analizi (Sprint 5'e bırakıldı).

## Sprint 5: Media Storage & AI Integration
*   **Objective:** Hasar belgelerinin yönetimi ve AI otomasyonu.
*   **Deliverables:** Dosya validasyonu ile Claim Photos modülü (Local Storage upload). AI summary pipeline entegrasyonu.
*   **Acceptance Criteria:** İstemcilerin hasara fotoğraf ekleyebilmesi ve API'nin dosyayı sunucuya başarıyla kaydetmesi. Adminlerin fotoğrafları ve AI tarafından fotoğrafa/açıklamaya dayanarak oluşturulan basit özeti görebilmesi.
*   **Out of Scope:** MinIO veya S3 entegrasyonu, video yükleme desteği.

## Sprint 6: Policy Requests & Admin Actions
*   **Objective:** Poliçe uzatma ve modifikasyon talepleri.
*   **Deliverables:** Müşteri paneli üzerinden Policy Request (Yenileme/Düzenleme) mekanizması, Adminler için manuel teklif notu/fiyat eklentisi (Dummy price).
*   **Acceptance Criteria:** Müşterinin uygulamada fiyat teklifi/onay isteği gönderebilmesi. Admin panelinde bu taleplere yanıt yazılabilmesi ve statünün tamamlandı olarak işaretlenmesi.
*   **Out of Scope:** Otomatik fiyatlama/scoring motoru.

## Sprint 7: Activity Tracking & Dashboard Reports
*   **Objective:** İzlenebilirlik ve genel istatistiklerin sunumu.
*   **Deliverables:** ActivityLog entity ve interceptor entegrasyonu ile işlemlerin kayıt altına alınması. Dashboard ana sayfası için (Aktif poliçe, bekleyen hasar hesaplamaları vb.) aggregate rapor endpoint'leri.
*   **Acceptance Criteria:** Her işlem logunun veritabanına sorunsuz yazılması. Admin panelinin ana sayfada anlık olarak verileri grafiksel/özet metrikler olarak görselleştirebilmesi.
*   **Out of Scope:** Kompleks BI/Grafik tabloları export mekanizmaları (PDF/Excel dışa aktarım).

## Sprint 8: Hardening & UI Polish
*   **Objective:** Projenin Production-Ready hale getirilmesi.
*   **Deliverables:** Unit/Integration Testlerin tamamlanması, CI/CD pipeline kurulumu, Backend hata çözümleri (Bug Fixes), UI tarafında estetik dokunuşlar (Animations, Feedback Toasts).
*   **Acceptance Criteria:** Kritik iş fonksiyonlarının minimum %70 oranında test edilebilir olması, sıfır P1 (Kritik) seviyesinde bug bulunması ve UX testlerinden başarıyla geçmesi.
*   **Out of Scope:** Feature eklenmesi.
