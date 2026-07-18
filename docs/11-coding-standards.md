# 11. Coding Standards

Tüm geliştiriciler ve AI bu dosyadaki C# ve genel programlama stiline istisnasız uymak zorundadır.

## Naming Conventions
*   **Sınıflar (Classes), Metodlar (Methods) ve Özellikler (Properties):** `PascalCase` kullanılacaktır (Örn: `GetUserList()`, `PolicyRepository`, `FirstName`).
*   **Değişkenler (Variables), Parametreler (Parameters) ve Private Alanlar:** `camelCase` kullanılacaktır (Private field'lar `_camelCase` olarak başlatılacaktır).
*   **DTO İsimlendirmeleri:** Tam açıklayıcı olmalıdır: `<Action><Entity><Type>`. (Örn: `CreatePolicyRequest`, `GetClaimByIdResponse`, `UpdateVehicleRequest`).

## Controller Prensibi (Thin Controller)
Controller'lar her zaman **ince (thin)** kalmalıdır. 
*   Controller içerisinde kesinlikle LINQ, DbContext, ya da direkt Business Logic yazılmayacaktır.
*   Akış: `Endpoint(Request)` -> `AppService(Metot)` -> `Response` şeklinde olacaktır.

## Validation Prensibi
*   **FluentValidation:** Projedeki yegane validasyon yöntemidir. 
*   **YASAK:** `[Required]`, `[MaxLength(50)]` gibi "DataAnnotation" attribute'leri DTO veya Entity sınıfları içerisine KESİNLİKLE yazılmayacaktır. Kurallar Validator (`UserValidator`, `CreatePolicyCommandValidator` vb.) sınıflarında barınacaktır.

## Mapping
*   **Mapster:** Entity ve DTO arasındaki dönüştürmeler (mapping) için yalnızca Mapster kütüphanesi kullanılacaktır.
*   **Manuel Mapping Yasaktır:** `dto.Name = entity.Name;` şeklinde el ile dönüştürme işleminden kaçınılacaktır.

## Dependency Injection (DI)
*   Uygulamadaki tüm servisler (Repository, Service, HttpClient, vs.) IServiceCollection'a register edilecek ve sınıflar içerisinde **Yalnızca Constructor Injection** ile alınacaktır. Global Instance veya Singleton nesnelere (Eğer State tutmuyorsa) doğrudan property (new() keyword'ü) üzerinden erişim yasaktır.

## Async İlkeleri
*   Network veya Veritabanı üzerinde gerçekleşen **her** işlem (CRUD vb.) `async / await` yapısında olacaktır. `Task` dönmeli ve EF Core Async metodları (`FirstOrDefaultAsync`, `ToListAsync` vb.) tercih edilmelidir.

## Exceptions (Hata Yönetimi)
*   **Global Exception Middleware:** Controller akışlarında `try/catch` kullanımı kesinlikle YASAKTIR. 
*   Tüm iş kuralları (Business Exceptions) manuel fırlatılır (Kural ihlali durumunda `throw new BusinessException("Kullanıcı zaten mevcut.");` şeklinde). Exception'lar bu işe uygun Middleware tarafından yakalanır ve frontend tarafına standart (`success: false, message: ...`) JSON cevabı olarak dönülür.

## Logging
*   **Technical (Serilog):** Sadece Error, sistem Warning durumları serilog ile console'a (veya file'a) yazılır. (Örn: "Veritabanı bağlantısı kopuk", "File Upload Failure").
*   **Business (ActivityLog):** Kullanıcı operasyonları DB tablosuna (ActivityLogs) yazılır. (Örn: "23 Numaralı Hasar Durumu İnceleniyor olarak değiştirildi by UserX").

## Comments ve Dokümantasyon
*   Sınıfların, metodların ne yaptığını anlatan düz yazılar ("Adds two integers") gibi gereksiz XML yorum satırlarından kaçınılmalıdır. İsimlendirmelerin (Naming) kodu zaten anlatıyor olması ("Clean Code") gerekir. Metot isimleri kendinden açıklamalı olmalıdır.
*   Sadece komplike algoritmaların *"Niçin"* (Why) öyle yazıldığını anlatan comment'ler kritiktir.

## Formatting ve Dosya Yapısı
*   Hiçbir C# dosyası (Aksi çok zorunlu olmadıkça) birden fazla Sınıf veya Interface tanımasın barındırmamalıdır. Her şey kendi bağımsız `*.cs` dosyasında olmalıdır.
*   Single Responsibility: Bir interface/sınıf sadece kendi işine ait özellikleri sağlamalıdır. Metodların uzunluğu mümkün olduğunca ~30 satırı geçmemelidir.

## API Principles
*   Projedeki REST API path isimlendirmeleri çoğul olmalıdır: `/api/users`, `/api/claims/123/photos`.
*   Aksiyon tabanlı URL kullanılmayacaktır (Örn: `/api/claims/update_status` YERİNE `PUT /api/claims/{id}/status`).
*   Durumlara uygun HTTP Standart Data statüleri dönecektir (200 OK, 201 Created, 400 Bad Request, 401 Unauthorized, 404 Not Found, 403 Forbidden).

## Testing (Future Outlook)
*   İlerleyen fazlarda yazılacak testler için her zaman `Arrange - Act - Assert` pattern'i takip edilecektir. Saf domain kodları bağımlılıksız test edilebilir formda bırakılmalıdır.
