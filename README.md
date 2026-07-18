# ClaimFlow

ClaimFlow, hasar/claim yönetimi için tasarlanmış bir proje iskeletidir. Bu depo üç ana bileşenden oluşur:

- `backend` — API sunucusu ve iş mantığı
- `dashboard` — Yönetim paneli (web)
- `mobile` — Mobil istemci

Tüm proje kararları ve detaylı açıklamalar `docs/` klasöründe dökümante edilmiştir.

**Hızlı Bakış**
- Amaç: Hasar taleplerinin kaydı, işlenmesi, değerlendirilmesi ve takibi.
- Dokümantasyon: `docs/` içinde projenin kapsamı, ER diyagramları, API spesleri ve kullanıcı hikayeleri bulunur.

**Klasör Yapısı**

- `backend/` — Sunucu kodu, servisler, migration ve DB modelleri
- `dashboard/` — Yönetici arayüzü kaynak kodu
- `mobile/` — Mobil uygulama kaynakları
- `docker/` — Docker Compose ve container yapılandırmaları
- `docs/` — Proje belgeleri (01-11 arası markdown dosyaları)

**Hızlı Başlangıç (genel)**

1. `docs/01-project-overview.md` dosyasını okuyarak projenin amaç ve kapsamını öğrenin.
2. Docker Compose yapılandırması varsa aşağıdaki komut kök dizinden çalıştırılabilir:

```bash
docker compose up --build
```

3. Bileşenleri ayrı başlatmak isterseniz ilgili klasördeki README veya start betiklerini kontrol edin.

**Geliştiriciler İçin Notlar**

- API ile ilgili ayrıntılar: `docs/05-api-spec.md`
- Veri model tasarımı: `docs/04-erd.md`
- Kodlama standartları: `docs/11-coding-standards.md`