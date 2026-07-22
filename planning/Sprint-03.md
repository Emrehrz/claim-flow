# Sprint 3: Poliçe Yönetimi

**Durum (Status):** Tamamlanmadı

## Sprint Amacı
Müşterilere sunulan poliçelerin tanımlanması, kapsam detaylarının aktarılması ve geçerlilik takibidir.

## Çıktılar
*   **Policy Entity:** `Vehicle` ile ilişkili `Policy` nesnesinin tasarlanması. (Teminat detayları için JSON kolon türünde `CoverageSummary` alanı kullanımı).
*   **API Endpoints:** Poliçeleri duruma (Active, Expired, Canceled) filtreleyebilen endpoint'ler.
*   **Admin Dashboard UI:** Belirli bir müşteriye spesifik poliçelerin listelenmesi ve yönetilmesi ekranı.
*   **Mobile App UI:** Mobile cihazda poliçe detaylarının ve güncel bitiş süresinin sade bir arayüz ile gösterilmesi.

## Kabul Kriterleri
*   Adminler `CoverageSummary` mantığı ile dinamik teminat detaylarını girebilmelidir.
*   Süresi biten poliçeler, API sorgularında otomatik olarak "Expired" statüsünde sınıflandırılmalıdır.
*   Kullanıcı mobil ekranda poliçe bitiş tarihini net bir şekilde görebilmelidir (Örn: "Poliçenin bitmesine 15 gün kaldı").

## Kapsam Dışı
*   Müşteriden online pos/kredi kartı ile tahsilat alınması.
*   Poliçe yenileme talebinin alınması (Bu modül Sprint 6'nın kapsamındadır).
*   Otomatik PDF (Poliçe çıktısı) üretimi.
