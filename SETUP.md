# BiletApp - Kurulum Kılavuzu

Bu kılavuz, projeyi ilk kez çalıştırmak için gerekli adımları içerir.

## Gereksinimler

- .NET SDK 10.0 veya üzeri
- Git (projeyi klonlamak için)

## Kurulum Adımları

### 1. .NET SDK Kurulumu

#### Windows:
1. https://dotnet.microsoft.com/download adresine gidin
2. ".NET 10.0 SDK" indirin ve kurun

#### macOS:
```bash
brew install --cask dotnet-sdk
```

#### Linux (Ubuntu/Debian):
```bash
wget https://dot.net/v1/dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 10.0
export PATH="$PATH:$HOME/.dotnet"
```

### 2. Projeyi İndirin

```bash
# Git ile klonlayın veya ZIP olarak indirin
git clone <repository-url>
cd BiletApp
```

### 3. Paketleri Yükleyin

```bash
dotnet restore
```

### 4. Entity Framework Tools Yükleyin

```bash
dotnet tool install --global dotnet-ef
```

**Not:** Eğer `dotnet ef` komutu çalışmıyorsa, PATH'e ekleyin:
```bash
# Windows (PowerShell)
$env:PATH += ";$env:USERPROFILE\.dotnet\tools"

# macOS/Linux
export PATH="$PATH:$HOME/.dotnet/tools"
```

### 5. Veritabanını Oluşturun

```bash
# Migration'ları uygula (veritabanını oluşturur)
dotnet ef database update
```

Bu komut, `biletapp.db` adında bir SQLite veritabanı dosyası oluşturur.

### 6. Projeyi Çalıştırın

```bash
dotnet run
```

### 7. Tarayıcıda Açın

Proje çalıştıktan sonra tarayıcıda şu adrese gidin:

```
http://localhost:5000
```

## Hızlı Kurulum (Tek Komut)

Tüm adımları tek seferde yapmak için:

**Windows (PowerShell):**
```powershell
dotnet restore; dotnet tool install --global dotnet-ef; $env:PATH += ";$env:USERPROFILE\.dotnet\tools"; dotnet ef database update; dotnet run
```

**macOS/Linux:**
```bash
dotnet restore && dotnet tool install --global dotnet-ef && export PATH="$PATH:$HOME/.dotnet/tools" && dotnet ef database update && dotnet run
```

## İlk Kullanım

1. **Kategori Oluşturun**: Yönetim > Kategoriler menüsünden yeni kategori ekleyin
2. **Etkinlik Oluşturun**: Yönetim > Etkinlikler menüsünden etkinlik ekleyin
3. **Bilet Oluşturun**: Yönetim > Biletler menüsünden bilet türleri ekleyin
4. **Sipariş Oluşturun**: Yönetim > Siparişler menüsünden sipariş oluşturun

## Sorun Giderme

### "dotnet: command not found" hatası
- .NET SDK'nın yüklü olduğundan emin olun: `dotnet --version`
- Terminal'i yeniden başlatın
- PATH değişkenini kontrol edin

### "dotnet ef: command not found" hatası
```bash
dotnet tool install --global dotnet-ef
export PATH="$PATH:$HOME/.dotnet/tools"  # macOS/Linux
```

### Veritabanı hatası
- `biletapp.db` dosyasını silin ve tekrar `dotnet ef database update` çalıştırın
- Migration dosyalarının `Migrations/` klasöründe olduğundan emin olun

### Port zaten kullanılıyor
`Properties/launchSettings.json` dosyasında port numarasını değiştirin.

## Proje Yapısı

```
BiletApp/
├── Controllers/      # MVC Controller'ları
├── Models/          # Veritabanı modelleri
├── Views/           # Razor view dosyaları
├── ViewModels/      # View model sınıfları
├── Data/            # DbContext
├── Migrations/      # EF Core migration dosyaları
└── wwwroot/         # Statik dosyalar (CSS, JS, images)
```

## Destek

Sorun yaşarsanız:
1. `TROUBLESHOOTING.md` dosyasına bakın
2. Hata mesajını kontrol edin
3. .NET SDK versiyonunuzu kontrol edin: `dotnet --version`

