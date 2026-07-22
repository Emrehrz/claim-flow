# Sprint 4: Hasar Temeli ve Raporlama

## Sprint Amacı
Hasar süreçlerinin uçtan uca yönetimi, kullanıcının ihbar bırakması ve Admin'in durum güncellemelerini takip etmesi.

## Çıktılar
*   **Claim Entity:** `Policy` entity'sine bağlı Claim nesnesinin oluşturulması.
*   **Mobile Workflow:** Kullanıcının aktif olan bir poliçe seçip ihbar başlığı ve hasar açıklaması (Description) gönderdiği ekran tasarımı ve API bağlantısı.
*   **Admin Workflow:** Sisteme düşen hasar talebinin görüntülenmesi, durum statülerinin (Örn: In Review, Approved, Rejected) Dropdown üzerinden güncellenmesi.
*   **Timeline Logic:** Kullanıcının mobil uygulamasında "Hasar Durumum Nerede?" konseptinde statü değişimlerini adım adım görmesi.

## Kabul Kriterleri
*   Yalnızca durumu "Active" olan bir poliçe üzerinden hasar dosyası oluşturulabilecektir.
*   Statü değişimleri başarıyla kaydedilmeli ve müşteri tarafından listelenebilmelidir.
*   Müşteri kendi dosyası haricindeki dosyaları asla göremeyecek, Controller'da ID validation garantisi verilecektir.

## Kapsam Dışı
*   Hasar anında fotoğraf veya kaza tespit tutanağı PDF'lerinin yüklenmesi.
*   Yapay zeka asistanı ile hasar özetinin çalıştırılması.
*   Hasar masrafları için ödeme/muhasebe işlemleri.
