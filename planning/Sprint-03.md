# Sprint 3: Policy Management

## 1. Objective
Müşterilere sunulan poliçelerin tanımlanması, kapsam detaylarının aktarılması ve geçerlilik takibidir.

## 2. Deliverables
*   **Policy Entity:** `Vehicle` ile ilişkili `Policy` nesnesinin tasarlanması. (Teminat detayları için JSON kolon türünde `CoverageSummary` alanı kullanımı).
*   **API Endpoints:** Poliçeleri duruma (Active, Expired, Canceled) filtreleyebilen endpoint'ler.
*   **Admin Dashboard UI:** Belirli bir müşteriye spesifik poliçelerin listelenmesi ve yönetilmesi ekranı.
*   **Mobile App UI:** Mobile cihazda poliçe detaylarının ve güncel bitiş süresinin sade bir arayüz ile gösterilmesi.

## 3. Acceptance Criteria
*   Adminler `CoverageSummary` mantığı ile dinamik teminat detaylarını girebilmelidir.
*   Süresi biten poliçeler, API sorgularında otomatik olarak "Expired" statüsünde sınıflandırılmalıdır.
*   Kullanıcı mobil ekranda poliçe bitiş tarihini net bir şekilde görebilmelidir (Örn: "Poliçenin bitmesine 15 gün kaldı").

## 4. Out of Scope
*   Müşteriden online pos/kredi kartı ile tahsilat alınması.
*   Poliçe yenileme talebinin alınması (Bu modül Sprint 6'nın kapsamındadır).
*   Otomatik PDF (Poliçe çıktısı) üretimi.
