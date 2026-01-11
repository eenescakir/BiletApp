# .NET SDK Kurulum Kılavuzu

## macOS için .NET SDK Kurulumu

### Yöntem 1: Homebrew ile (Önerilen)

```bash
# Homebrew yüklü değilse önce yükleyin:
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"

# .NET SDK'yı yükleyin:
brew install --cask dotnet-sdk
```

### Yöntem 2: Resmi Installer

1. https://dotnet.microsoft.com/download adresine gidin
2. ".NET 8.0 SDK" indirin (macOS için)
3. İndirilen .pkg dosyasını çalıştırın ve kurulumu tamamlayın

### Yöntem 3: Script ile

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0
```

## Kurulum Sonrası

Terminal'i yeniden başlatın veya şu komutu çalıştırın:

```bash
export PATH="$PATH:$HOME/.dotnet"
```

Kurulumu doğrulamak için:

```bash
dotnet --version
```

## Projeyi Çalıştırma

.NET SDK kurulduktan sonra:

```bash
cd /Users/enescakir/Projects/BiletApp

# Paketleri yükle
dotnet restore

# Entity Framework Tools yükle (eğer yoksa)
dotnet tool install --global dotnet-ef

# Veritabanı migration'larını oluştur
dotnet ef migrations add InitialCreate

# Veritabanını oluştur
dotnet ef database update

# Projeyi çalıştır
dotnet run
```

Tarayıcıda şu adrese gidin:
```
http://localhost:5000
```

## Sorun Giderme

### "dotnet: command not found" hatası
- Terminal'i yeniden başlatın
- PATH değişkenini kontrol edin: `echo $PATH`
- Homebrew ile yüklediyseniz: `brew link dotnet-sdk`

### Entity Framework Tools hatası
```bash
dotnet tool install --global dotnet-ef
export PATH="$PATH:$HOME/.dotnet/tools"
```

