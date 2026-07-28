using System.Threading.Tasks;
using ClaimFlow.Application.Interfaces.Ai;

namespace ClaimFlow.Infrastructure.Services.Ai;

public class MockAiService : IAiService
{
    public Task<string> AnalyzeClaimAsync(string description, int photoCount)
    {
        // Basit kural tabanlı bir analiz simülasyonu[cite: 8]
        var summary = $"Yapay Zeka Ön Değerlendirmesi: Müşteri beyanında '{description}' ifadeleri yer alıyor. " +
                      $"Sisteme {photoCount} adet kanıt fotoğrafı yüklendi. Görsel hasar tespiti için dosyalar incelenmeye uygundur.";

        return Task.FromResult(summary);
    }
}