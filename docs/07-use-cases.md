# Use Case Analizi

## Customer Use Cases

```text
Login
│
├── View Dashboard
│
├── View My Vehicles
│
├── View My Policies
│
│     └── View Coverage Details
│
├── Create Claim
│     ├── Select Vehicle
│     ├── Upload Photos
│     ├── AI Damage Analysis
│     └── Submit Claim
│
├── View Claim Details
│
├── Track Claim Status
│
├── Create Renewal Request
│
├── Create Policy Update Request
│
└── View Request History
```

Bu akış mobil uygulamanın temel navigasyonunu da belirliyor.

---

## Admin Use Cases

```text
Login
│
├── Dashboard
│
├── Customer Management
│     ├── Customer Detail
│     ├── Vehicles
│     ├── Policies
│     └── Claims
│
├── Policy Management
│     ├── View Policy
│     └── Update Policy
│
├── Claim Management
│     ├── View Claim
│     ├── Review Photos
│     ├── View AI Summary
│     ├── Update Status
│     └── Close Claim
│
├── Request Management
│     ├── View Requests
│     ├── Enter Dummy Offer
│     └── Complete Request
│
└── Reports
```

---

## Sistemin En Önemli Akışı (Happy Path)

Bu, demo sırasında göstereceğin ana senaryo olacak.

```text
Customer Login
        │
        ▼
Poliçesini Görüntüler
        │
        ▼
Hasar Oluşturur
        │
        ▼
Fotoğraf Yükler
        │
        ▼
AI Ön Analizi Oluşur
        │
        ▼
Admin Dashboard'da Yeni Görev Görünür
        │
        ▼
Admin Talebi İnceler
        │
        ▼
Hasar Durumunu Günceller
        │
        ▼
Customer Mobilde Güncel Durumu Görür
```
