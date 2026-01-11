# Projeyi Çalıştırma Adımları

## 1. .NET SDK Kurulumu

Terminal'de şu komutu çalıştırın (şifre isteyecektir):

```bash
brew install --cask dotnet-sdk
```

Kurulum tamamlandıktan sonra terminal'i yeniden başlatın veya:

```bash
export PATH="$PATH:$HOME/.dotnet"
```

Kurulumu kontrol edin:

```bash
dotnet --version
```

## 2. Projeyi Çalıştırma

.NET SDK kurulduktan sonra:

```bash
cd /Users/enescakir/Projects/BiletApp

# Paketleri yükle
dotnet restore

# Entity Framework Tools yükle (eğer yoksa)
dotnet tool install --global dotnet-ef

# PATH'e ekle (eğer gerekirse)
export PATH="$PATH:$HOME/.dotnet/tools"

# Veritabanı migration'larını oluştur
dotnet ef migrations add InitialCreate

# Veritabanını oluştur
dotnet ef database update

# Projeyi çalıştır
dotnet run
```

## 3. Tarayıcıda Açın

Proje çalıştıktan sonra tarayıcıda şu adrese gidin:

```
http://localhost:5000
```

## Hızlı Başlangıç (Tek Komut)

Eğer .NET SDK zaten kuruluysa:

```bash
cd /Users/enescakir/Projects/BiletApp && dotnet restore && dotnet tool install --global dotnet-ef && export PATH="$PATH:$HOME/.dotnet/tools" && dotnet ef migrations add InitialCreate && dotnet ef database update && dotnet run
```

