# Sprint 6: Policy Requests & Dummy Offers

## 1. Objective
Kullanıcıların mevcut poliçeleriyle ilgili değişiklik/güncelleme ve yenileme taleplerinin iletilmesi süreçlerinin kodlanması.

## 2. Deliverables
*   **PolicyRequest Entity:** `Policy` ile bağlı (Type: Renewal, Update) talepler.
*   **Mobile Form:** Kullanıcının, bitmek üzere olan poliçesini seçip "Yenile" veya "Teminatı Güncelle" talebi oluşturduğu form mantığı.
*   **Admin Dashboard:** Gelen taleplerin bir kuyruk formatında görülmesi. Admin'in bu taleplere manuel bir teklif fiyatı (`DummyPrice`) girerek veya açıklama (`AdminResponse`) yazarak durumu "Completed" olarak değiştirebileceği Modal arayüzü.

## 3. Acceptance Criteria
*   Kullanıcı bir poliçe için aynı anda yalnızca bir "Open/Bekleyen" statülü işlem açabilmelidir.
*   Admin fiyatı girdikten ve statüyü değiştirdikten sonra, müşteri tarafındaki ekranda bu yanıt canlıya yansılamalıdır.
*   İş akışı Thin Controller prensibiyle App Service tarafında gerçekleştirilmelidir.

## 4. Out of Scope
*   Özel sigorta şirketlerinin fiyatlandırma API'leri (Scoring) ile entegrasyon.
*   Kredi kartıyla poliçe başlatma işlemleri.
