# Insurance Operations Portal
## Proje Kapsamı ve Genel Tanım (v1.0)

## 1. Proje Amacı

Insurance Operations Portal, sigorta müşterileri ile sigorta şirketi çalışanları arasındaki poliçe, hasar ve talep süreçlerini dijital ortamda yönetmek amacıyla geliştirilen web ve mobil tabanlı bir MVP (Minimum Viable Product) projesidir.

Projenin amacı gerçek bir sigorta çekirdek sistemi geliştirmek değil, gerçek hayattaki operasyon süreçlerini modern yazılım mimarileri kullanarak modellemektir.

---

# 2. Hedef Kullanıcılar

## Customer (Mobil)

Sigorta müşterisi.

Yapabilecekleri:

- Giriş yapma
- Profil görüntüleme
- Araçlarını görüntüleme
- Poliçelerini görüntüleme
- Teminat özetlerini görüntüleme
- Hasar ihbarı oluşturma
- Hasar fotoğrafı yükleme
- Hasar sürecini takip etme
- Poliçe yenileme talebi oluşturma
- Poliçe güncelleme talebi oluşturma
- Taleplerinin durumunu takip etme

---

## Admin (Dashboard)

Sigorta şirketi çalışanı.

Yapabilecekleri:

- Dashboard görüntüleme
- Müşteri yönetimi
- Araç yönetimi
- Poliçe yönetimi
- Hasar yönetimi
- Talep yönetimi
- AI destekli hasar özetini görüntüleme
- Hasar durumlarını güncelleme
- Activity Log görüntüleme
- Basit raporları görüntüleme

---

# 3. Sistem Bileşenleri

## Backend

ASP.NET Core Web API

Sorumlulukları:

- Authentication
- Authorization
- Business Logic
- API
- AI servis entegrasyonu
- Dosya yönetimi
- Veritabanı işlemleri

---

## Dashboard

React tabanlı yönetim paneli.

Admin tarafından kullanılır.

---

## Mobile

React Native tabanlı müşteri uygulaması.

---

# 4. Ana Modüller

## Authentication

- Login
- JWT
- Refresh Token

---

## Customer Management

- Customer
- Vehicle

---

## Policy Management

- Policies
- Coverage Summary

---

## Claim Management

- Claim oluşturma
- Fotoğraf yükleme
- AI destekli hasar özeti
- Claim Timeline
- Claim Status

---

## Request Management

- Renewal Request
- Policy Update Request
- Manual Offer Response

---

## Dashboard

- KPI Kartları
- Bekleyen Hasarlar
- Bekleyen Talepler

---

## Reporting

- Aktif Poliçeler
- Bekleyen Talepler
- Hasar Dağılımı

---

## Audit

- Activity Log

---

# 5. İş Akışları

## Hasar Süreci

Customer
↓
Hasar Oluşturur
↓
Fotoğraf Yükler
↓
AI Ön Analizi
↓
Admin İncelemesi
↓
Durum Güncellenir
↓
Tamamlandı

---

## Yenileme Talebi

Customer
↓
Yenileme Talebi
↓
Admin İnceler
↓
Dummy Teklif Girer
↓
Talep Tamamlanır

---

# 6. İş Kuralları

- Aktif poliçesi olmayan araç için hasar oluşturulamaz.
- Aynı poliçe için bekleyen ikinci yenileme talebi oluşturulamaz.
- Her hasar tek bir poliçeye bağlıdır.
- Her hasar en az bir fotoğraf içermelidir.
- Kapatılan hasar yeniden açılamaz.

---

# 7. Kapsam Dışı

Bu sürümde aşağıdaki özellikler geliştirilmeyecektir:

- Chat
- Bildirim sistemi
- E-posta/SMS gönderimi
- Gerçek fiyat hesaplama motoru
- Gerçek ödeme sistemi
- Mikroservis mimarisi
- Çoklu dil desteği
- Çoklu yönetici rolleri
- Gerçek eksper entegrasyonu

---

# 8. Teknoloji

Backend
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT
- FluentValidation
- Mapster
- Serilog

Dashboard
- React
- TypeScript
- Vite
- TanStack Query
- React Router
- Tailwind CSS
- shadcn/ui

Mobile
- React Native
- Expo
- NativeWind
- TanStack Query

DevOps
- Docker
- Docker Compose

---

# 9. MVP Hedefi

Staj sonunda;

- çalışan bir mobil uygulama,
- çalışan bir yönetim paneli,
- temiz mimariye sahip bir backend,
- gerçek iş akışlarını modelleyen bir domain,
- Docker ile ayağa kaldırılabilen tam entegre bir sistem

teslim edilmesi hedeflenmektedir.
