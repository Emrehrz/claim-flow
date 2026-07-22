# Sprint 8: Finalization & Deployment

## 1. Objective
Projede uçtan uca doğrulamaların yapılması, performans hatalarının giderilmesi, kodun C# / React standartları çerçevesinde temizlenmesi ve uygulamanın canlıya alınabilir paketinin (Deployment) sunulmasıdır.

## 2. Deliverables
*   **Testing:** Kritik core modüllere (Hasar ekleme ve JWT Authentication) ait basit Unit test senaryolarının (Arrange, Act, Assert pattern ile) yazılması.
*   **Bug Fixes & Refactoring:** Son testlerde ortaya çıkan P1 ve P2 ölçeğindeki hataların giderilmesi, `Mapster` ve `FluentValidation` implementasyonlarının incelenerek standartlardan sapma varsa onarılması.
*   **UI Polish:** Arayüzdeki (Mobile ve Dashboard) gecikme yaşam alanlarında Loading State'lerin onarımı, Empty (Boş veri) component tasarımları ve sayfa geçişlerindeki micro-animation dokunuşları.
*   **Deployment Ready:** Projenin son `docker-compose.yml` komutuyla (`docker-compose up --build`) tek bir satırda DB, Backend ve Frontend'in bir arada ayağa kalkacak formata gelmesi.

## 3. Acceptance Criteria
*   Son build işleminde Visual Studio ve React sunucularında konsolda minimum pürüz (sıfır warning hedefli) olmalıdır.
*   Unit Testler CI pipeline'ında (varsa veya manuel Terminal komutuyla) başarılı bir şekilde "Pass" olmalıdır.
*   Global Exception Handling kontrolü; her koşulda response'un standart formla 200/400/500 gibi JSON datası dönmesi sağlanmalıdır.
*   Çalışan Docker imajları oluşturulabilmelidir.

## 4. Out of Scope
*   AWS, Azure veya Kubernetes konfigürasyon dosyaları, Helm chart yazımı.
*   Stress ve Penetration/Güvenlik testleri.
*   Bu sprint içinde yeni bir yazılımsal fonsiyonun (Business feature) eklenmesi kesinlikle reddedilecektir.
