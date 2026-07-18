# İş Kuralları / Business Rules

## Temel İş Kuralları
- Aktif poliçesi olmayan araç için hasar oluşturulamaz.
- Aynı poliçe için bekleyen ikinci yenileme talebi oluşturulamaz.
- Her hasar tek bir poliçeye bağlıdır.
- Her hasar en az bir fotoğraf içermelidir.
- Kapatılan hasar yeniden açılamaz.

## Customer
- Inactive users cannot login.

## Policy
- A vehicle cannot have multiple active policies during the same period.
- EndDate cannot be earlier than StartDate.

## Claim
- Claims can only be created for active policies.
- Every claim must belong to exactly one policy.
- Every claim must contain at least one photo.
- Closed claims cannot be reopened.

## Policy Request
- Only one pending renewal request can exist for a policy.
