namespace  ClaimFlow.Domain.Enums;

public enum ClaimStatus
{
    Submitted = 1, // İhbar bırakıldığında varsayılan durum
    InReview = 2,  // İncelemede
    Approved = 3,  // Onaylandı
    Rejected = 4   // Reddedildi
}