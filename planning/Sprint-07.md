# Sprint 7: Dashboard Analiz ve Audit (Aktivite Logları)

## Sprint Amacı
Sistemdeki hareketliliğin canlı takibi (Audit logs) ve yöneticilere genel bakış sağlayacak metrik panellerinin oluşturulmasıdır.

## Çıktılar
*   **ActivityLog Entity & Automation:** Kayıtlar üzerinde yapılan kritik `Create`, `Update`, `Delete` metotlarının merkezi bir Interceptor veya AppService mantığı ile `ActivityLog` tablosuna dökülmesi.
*   **Dashboard Stats API:** "Toplam Aktif Poliçe", "Bekleyen Hasar Dosyası", "Haftanın Talepleri" gibi anahtar performans göstergelerini (KPI) dönecek özel Query endpoint'i.
*   **React Dashboard UI:** Ana ekranda grafiksel widgetlar (Recharts vb.) veya Card bileşenleri ile bu statülerin şık şekilde gösterimi. Activity geçmişinin tarihçe formatında tablo listesi.

## Kabul Kriterleri
*   Adminler hangi işlemi kimin yaptığını log'larda net bir metin ve kimlik bilgisi (`PerformedBy`) ile görmelidir. (Örn: "Admin A, 42 ID'li Hasarın durumunu Approved yaptı").
*   KPI API'si sayfaları tıkamamak için asenkron çalışmalı, gerekirse aggregate methodlar optimize edilmelidir.
*   Frontend, verileri beklerken şık Skeleton yükleme bileşenleri göstermelidir.

## Kapsam Dışı
*   Excel, PDF vb. kompleks rapor alma/dışa aktarım arayüzleri veya BI entegrasyonu.
*   Grafikler harici çok katmanlı pivot tablolar.
