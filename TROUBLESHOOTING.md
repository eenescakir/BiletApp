# Sorun Giderme Kılavuzu

## HTTP 403 Hatası Çözümü

### 1. Static Dosyalar Sorunu
Eğer "403 Forbidden" hatası alıyorsanız, aşağıdaki adımları deneyin:

#### Çözüm 1: CDN Kullanımı
Bootstrap ve jQuery kütüphaneleri artık CDN'den yükleniyor. Eğer internet bağlantınız yoksa, kütüphaneleri manuel olarak indirip `wwwroot/lib` klasörüne ekleyin.

#### Çözüm 2: wwwroot İzinleri
Terminal'de şu komutu çalıştırın:
```bash
chmod -R 755 wwwroot/
```

#### Çözüm 3: Projeyi Yeniden Başlatın
```bash
dotnet clean
dotnet build
dotnet run
```

### 2. Veritabanı Bağlantı Sorunu

#### macOS'ta SQL Server LocalDB
macOS'ta SQL Server LocalDB çalışmaz. Alternatifler:

**Seçenek 1: SQLite Kullanın**
1. `BiletApp.csproj` dosyasına ekleyin:
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
```

2. `Program.cs` dosyasında:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=biletapp.db"));
```

**Seçenek 2: Docker ile SQL Server**
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

**Seçenek 3: InMemory Database (Test için)**
1. `BiletApp.csproj` dosyasına ekleyin:
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
```

2. `Program.cs` dosyasında:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BiletAppDb"));
```

### 3. Port Sorunu
Eğer belirli bir portta çalışmıyorsa, `Properties/launchSettings.json` dosyasını kontrol edin.

### 4. Migration Sorunu
Veritabanı oluşturmak için:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Eğer `dotnet ef` komutu çalışmıyorsa:
```bash
dotnet tool install --global dotnet-ef
```

## Hızlı Test

Projeyi çalıştırdıktan sonra şu URL'leri test edin:
- http://localhost:5000 (Ana sayfa)
- http://localhost:5000/Category (Kategoriler)
- http://localhost:5000/Event (Etkinlikler)

Eğer hala 403 hatası alıyorsanız, tarayıcı konsolunu (F12) kontrol edin ve hangi dosyaların yüklenemediğini görün.

