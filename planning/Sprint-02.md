# Sprint 02 — Müşteri ve Araç Modülü (Customer & Vehicle Module)

**Durum (Status):** Tamamlandı

## Sprint Amacı
Müşteri sahipliği ve araç kayıtlarının tutarlı bir şekilde yönetilebilmesi için müşteri ve araç temelini oluşturmak.

## İş Bağlamı
Müşteriler ve araçları, hasar akışının temel aktörleridir. Bu modül; poliçe, hasar ve talep modüllerinin gerektirdiği kimlik ve sahiplik verilerini sağlar.

## Kapsam
- Müşteriye dönük profil verileri.
- Araç sahipliği ve liste yönetimi.
- Admin yönetimli müşteri ve araç bakımı (maintenance).
- Kullanıcı araçlarına, sahiplik tabanlı özel erişim.

## Çıktılar
- Müşteri/kullanıcı (Customer/user) entity desteği
- Araç (Vehicle) entity desteği
- Müşteri ve araç DTO'ları
- Müşteri ve araç repository katmanı
- Müşteri ve araç servis (service) katmanı
- Araç girdileri için validasyon kuralları
- Müşteri ve araç controller'ları
- Müşteri ve araç API endpoint'leri
- Araç kayıtları için veritabanı migration'ı
- Müşteri ve araç operasyonları için unit testler

## Uygulama Sırası
1. Müşteri ve araç domain modellemesini doğrula.
2. DTO'lar ve validasyon kuralları ekle.
3. Sahipliğe duyarlı (ownership-aware) veri erişimi için repository'ler uygula.
4. Müşteri ve araç işlemleri için servisler inşa et.
5. Controller'ları ve API endpoint'lerini dışa aç.
6. Gerekirse veritabanı migration'ı ve seed verilerini (varsayılan listeleri) ekle.
7. Sahiplik (ownership) ve CRUD davranışı için unit testler ekle.

## Kabul Kriterleri
- Admin kullanıcıları müşteri ve araç kayıtlarını listeleyebilir ve yönetebilir.
- Müşteriler yalnızca kendi araçlarına erişebilirler.
- Validasyon, geçersiz araç verilerinin kaydedilmesini engeller.
- Modül, poliçe veya hasar davranışı tanıtılmadan (hariç tutularak) uygulanır.

## Kapsam Dışı
- Poliçe (Policy) yönetimi.
- Hasar (Claim) oluşturma veya hasar medyası (Claim media) işleme.
- Poliçe talep (Policy request) akışları.
- Raporlama veya dashboard analitiği.

## İlgili Dokümantasyon
- docs/01-project-overview.md
- docs/04-erd.md
- docs/05-api-spec.md
- docs/08-system-architecture.md
- docs/09-development-roadmap.md

## Öneriler
- Müşteri sahiplik (ownership) kurallarını merkezi tutun ki ileriki modüller bunları tekrar kullanabilsin.
- Kullanıcı arayüzünde (UI) "müşteri (customer)" dili kullanılsa dahi, ERD'deki mevcut entity isimlendirmesini koruyun.
