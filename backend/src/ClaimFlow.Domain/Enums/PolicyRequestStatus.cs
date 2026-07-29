namespace ClaimFlow.Domain.Enums;

public enum PolicyRequestStatus
{
    Pending = 1,   // Beklemede / Açık
    Completed = 2, // Admin Fiyat/Yanıt Girdi
    Rejected = 3   // Reddedildi
}