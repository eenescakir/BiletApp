# Projeyi Arkadaşlarınızla Paylaşma

Bu dosya, projeyi arkadaşlarınızla paylaşmak için gerekli adımları içerir.

## 📦 Paylaşım Yöntemleri

### Yöntem 1: Git Repository (Önerilen)

1. **GitHub/GitLab/Bitbucket'da repository oluşturun**
   - GitHub: https://github.com/new
   - GitLab: https://gitlab.com/projects/new
   - Bitbucket: https://bitbucket.org/repo/create

2. **Projeyi Git'e ekleyin**
   ```bash
   cd BiletApp
   git init
   git add .
   git commit -m "Initial commit"
   git remote add origin <repository-url>
   git push -u origin main
   ```

3. **Arkadaşlarınız klonlasın**
   ```bash
   git clone <repository-url>
   cd BiletApp
   ```

### Yöntem 2: ZIP Dosyası

1. **Gereksiz dosyaları temizleyin**
   ```bash
   # Build dosyalarını temizle
   dotnet clean
   ```

2. **ZIP oluşturun** (şu klasörleri hariç tutun):
   - `bin/`
   - `obj/`
   - `*.db` (veritabanı dosyaları)
   - `.vs/` (varsa)

3. **ZIP'i paylaşın**

### Yöntem 3: Cloud Storage

- Google Drive, Dropbox, OneDrive gibi servislere yükleyin
- **ÖNEMLİ:** `biletapp.db` dosyasını paylaşmayın (herkes kendi veritabanını oluşturacak)

## ✅ Paylaşmadan Önce Kontrol Listesi

- [ ] `biletapp.db` dosyası `.gitignore`'da
- [ ] `bin/` ve `obj/` klasörleri `.gitignore`'da
- [ ] `Migrations/` klasörü dahil edildi
- [ ] `README.md` güncel
- [ ] `SETUP.md` dosyası mevcut
- [ ] `appsettings.json` connection string doğru
- [ ] Gereksiz dosyalar temizlendi

## 📋 Arkadaşlarınızın Yapması Gerekenler

1. Projeyi indirin (Git veya ZIP)
2. `SETUP.md` dosyasındaki adımları takip edin
3. `.NET SDK` yükleyin
4. `dotnet restore` çalıştırın
5. `dotnet ef database update` ile veritabanını oluşturun
6. `dotnet run` ile projeyi başlatın

## 🔧 Gerekli Dosyalar

Projeyi paylaşırken şu dosyaların mutlaka olması gerekir:

```
BiletApp/
├── Controllers/          ✅ Gerekli
├── Models/              ✅ Gerekli
├── Views/               ✅ Gerekli
├── ViewModels/          ✅ Gerekli
├── Data/                ✅ Gerekli
├── Migrations/           ✅ Gerekli (VERİTABANI İÇİN)
├── wwwroot/             ✅ Gerekli
├── Program.cs           ✅ Gerekli
├── BiletApp.csproj      ✅ Gerekli
├── appsettings.json     ✅ Gerekli
├── .gitignore           ✅ Gerekli
├── README.md            ✅ Gerekli
└── SETUP.md             ✅ Gerekli
```

## ❌ Paylaşılmayacak Dosyalar

- `biletapp.db` - Herkes kendi veritabanını oluşturmalı
- `bin/` - Build çıktıları
- `obj/` - Geçici build dosyaları
- `.vs/` - Visual Studio ayarları
- `*.user` - Kullanıcı özel ayarlar

## 🎯 Hızlı Paylaşım Komutu

Git kullanıyorsanız:

```bash
# Tüm dosyaları ekle (gitignore'a göre)
git add .

# Commit yap
git commit -m "BiletApp projesi - paylaşım için hazır"

# Push yap
git push
```

## 📝 Notlar

- Veritabanı dosyası (`biletapp.db`) paylaşılmamalı çünkü:
  - Her kullanıcı kendi veritabanını oluşturmalı
  - Migration'lar zaten mevcut, `dotnet ef database update` ile oluşturulabilir
  - Dosya boyutu büyüyebilir

- Migration dosyaları mutlaka paylaşılmalı çünkü:
  - Veritabanı yapısını oluşturmak için gerekli
  - `Migrations/` klasöründeki tüm dosyalar dahil edilmeli

