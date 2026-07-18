# Sprint 2: Customer & Vehicle Management

## 1. Objective
Müşteri verileri ve müşterilere ait araç koleksiyonlarının temel CRUD operasyonlarıyla yönetilebilir hale gelmesidir.

## 2. Deliverables
*   **Vehicle Entity:** Domain katmanında `Vehicle` entity'sinin User ile ilişkili şekilde modellenmesi (1:N orantısı).
*   **API Endpoints:** Kullanıcılar ve araçlar için gerekli `GET`, `POST`, `PUT`, `DELETE` endpoint'lerinin (DTO'larla birlikte) Presentation katmanına eklenmesi.
*   **Admin Dashboard UI:** Tüm müşterilerin ve araçların bir tablo görünümünde listelenebilmesi, eklenebilmesi, güncellenmesi ve silinebilmesi (CRUD ekranları).
*   **Mobile App UI:** Müşterinin kendi paneline girdiğinde `Vehicle` verilerini liste halinde görüntüleyebilmesi.

## 3. Acceptance Criteria
*   Admin yetkisi olanlar sistemdeki tüm User ve Vehicle verilerini listeleyebilmeli ve manipüle edebilmelidir.
*   Customer yetkisi olan bir kullanıcı, API isteklerinde sadece kendine ait araçları getirmeli, başkasının kaynağına erişim sağlandığında yetkisizlik hatası fırlatılmalıdır.
*   Giriş verilerinde FluentValidation ile zorunlu alanlar (Plaka formatı, Yıl limiti vb.) başarıyla kontrol edilmelidir.
*   UI tarafında hata dönüşleri Toast/Alert mekanizması ile gösterilmelidir.

## 4. Out of Scope
*   Araçların poliçe bağlamında gösterilmesi.
*   Yeni bir talep (Request) oluşturulması.
*   Resim veya ruhsat görseli yükleme işlemleri.
