# Sprint 5: Hasar Fotoğrafları ve Yapay Zeka Entegrasyonu

**Durum (Status):** Tamamlanmadı

## Sprint Amacı
Müşterinin görsel kanıtları sisteme dahil edebilmesi ve Yapay Zekanın bu sürecin arkasında destek olarak konumlanmasıdır.

## Çıktılar
*   **ClaimPhoto Entity:** `Claim` ile ilişkili görseller.
*   **Local Storage Entegrasyonu:** Gelen görsel form verilerinin arka planda sunucuda saklanıp URL'lerinin DB'ye (FileUrl kolonuna) kaydedilmesi.
*   **AI Integration:** Backend üzerinde basit bir LLM/AI prompt entegrasyonu (Veya mock servis). Gelen hasar bilgilerine göre analiz çıkaran ve metinsel `AiSummary` mantığını çalıştıran servis.
*   **UI Components:** Mobil cihazdan kamerayı/galeriyi açma ve yükleme arayüzü.

## Kabul Kriterleri
*   Yüklenen dosyalar güvenli ve kısıtlı uzantılarda (JPG, PNG) olmalı, boyut limiti (örn: 5MB) kontrol edilmelidir.
*   Mobil uygulama, hasar ihbarı oluştururken fotoğrafları Multipart Form Data şeklinde API'ye iletmelidir.
*   Admin, talep dosyasını açtığında resimleri bir galeri olarak görebilmeli ve yanında AI'ın önerdiği metinsel özeti inceleyebilmelidir.

## Kapsam Dışı
*   MinIO veya Amazon S3 gibi harici Object Storage bağlantıları.
*   LLM üzerinde Fine-tuning işlemleri veya video render/analiz araçları.
