# 10. AI Development Guide

Bu kılavuz, AI Agent'ın "Insurance Operations Portal" üzerinde çalışırken uymakla yükümlü olduğu temel davranış ve kod üretim prensiplerini içerir. Kod oluşturmadan önce daima bu kuralları gözden geçir.

## Project Context
*   **Proje Adı:** Insurance Operations Portal
*   **Odağımız:** Modüler, ölçeklenebilir ve güvenli sigorta operasyon yazılımı.
*   **Teknoloji Yığını:**
    *   Backend: ASP.NET Core (C# 12, .NET 8+)
    *   Dashboard: React (TypeScript)
    *   Mobile: React Native (TypeScript)
    *   Veritabanı: PostgreSQL

## Development Principles
1.  **Architecture First:** Clean Architecture katman yapısını asla bozma.
2.  **DRY (Don't Repeat Yourself):** Kod tekrarlarından kaçın; ortak logic'leri utility veya base sınıflara taşı.
3.  **Scoped Edits:** Yalnızca senden istenen feature ile ilgili dosyaları düzenle. İlgisiz dosyalarda yapısal refactor yapmaya çalışma.
4.  **Production Quality:** Prototype ya da "örnek olsun diye yazılmış" kalitede kod üretme. Ürettiğin her kod hata yönetimine sahip, üretim standartlarında olmalı.
5.  **Simplicity (YAGNI):** Gereksiz abstraction ve factory'lere girme. Karmaşıklıktan uzak dur, sadeliğe ve okunabilirliğe öncelik ver.
6.  **SOLID:** Prensipleri ihlal etme, sınıfları Single Responsibility kuralına göre küçük tut.

## Constraints
*   Mevcut Entity yapısına, **istek üzerine açıkça belirtilmedikçe** yeni field ekleme.
*   PostgreSQL veritabanı şemasını kendi inisiyatifinle değiştirme.
*   Halihazırda projeye dahil edilmemiş 3. parti veya spesifik teknoloji kütüphanelerini onay almadan ekleme.
*   Müşteri uygulamalarında kullanılan mevcut API Endppoint imzasını (contract) bozma (Breaking changes yasak).
*   Validasyon kurallarını ya da Security katmanını pas geçme veya by-pass edecek kod ekleme.

## Folder Rules
Kodun doğru klasöre (katmana) eklendiğinden emin ol:
*   `Entity`, `Enum`, `Business Exception` -> **Domain Layer**
*   `DTO`, `Command`, `Query`, `AppService`, `Validators` -> **Application Layer**
*   `EfDbContext`, `Repository Implementation`, `External API Integration` -> **Infrastructure Layer**
*   `Controller`, `Middleware`, `Program.cs` -> **Presentation Layer**

## Feature Workflow
1.  **Understand Requirement:** Ne istendiğini analiz et.
2.  **Check Documentation:** ERD (04) veya User Stories (06) dosyalarını kontrol et.
3.  **Explain Approach:** Planını kısaca listele. (Ne/Nereye eklenecek).
4.  **Generate Code:** Katı sınırlara sadık kalarak kod bloğunu üret.
5.  **Explain Changes:** Eklediğin kodu neden bu şekilde yazdığını 1-2 cümleyle açıkla.

## Prompt Template
İdeal ve net üretim için prompt yapısı şu şekilde kurgulanmalıdır:
```text
[Goal]
Kısaca özelliğin amacı belirtilir (Örn: Claim Create mekanizmasını yaz.)

[Requirements]
Yapılması istenen asıl iş (Örn: Post endpoint, file upload logic)

[Acceptance Criteria]
Özelliğin bittiğini gösteren kurallar.

[Constraints]
Yapılmaması gerekenler.

[Deliverables]
Üretilecek olan spesifik dosyalar.
```

## Definition of Done (DoD)
Yazdığın kod aşağıdakileri sağlıyor mu kontrol et:
*   Compiles (Derleniyor mu?)
*   No warnings (Warning veya açıkça bırakılmamış NotImplemented Exception var mı?)
*   Uses Validation (FluentValidation kullanıldı mı?)
*   Uses DTOs (Direkt Entity yerine Request/Response nesneleri var mı?)
*   Uses Repository Pattern (EF DbContext doğrudan Service katmanından çağrılmamalı)
*   Uses Mapping (Mapster ile Entity-DTO dönüşümü yapıldı mı?)
*   Swagger Updated (Gerekli API açıklamaları eklendi mi?)
