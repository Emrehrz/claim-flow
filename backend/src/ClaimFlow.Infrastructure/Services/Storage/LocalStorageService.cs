using System;
using System.IO;
using System.Threading.Tasks;
using ClaimFlow.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Hosting;

namespace ClaimFlow.Infrastructure.Services.Storage;

public class LocalStorageService : ILocalStorageService
{
    private readonly IWebHostEnvironment _env;

    public LocalStorageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string subFolder = "claims")
    {
        // Dosya yolu: wwwroot/uploads/claims
        var uploadsFolder = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads", subFolder);
        
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        // Benzersiz bir dosya adı oluştur
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStreamOutput = new FileStream(filePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(fileStreamOutput);
        }

        // DB'ye kaydedilecek URL yolunu döndür
        return $"/uploads/{subFolder}/{uniqueFileName}";
    }
}