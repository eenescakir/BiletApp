using Microsoft.EntityFrameworkCore;
using BiletApp.Data;
using BiletApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = "Data Source=biletapp.db";
}

// Use SQLite for cross-platform compatibility (works on macOS, Linux, Windows)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

// Static files middleware - must be before UseRouting
app.UseStaticFiles();

// HTTPS redirection (commented out for HTTP access)
// app.UseHttpsRedirection();

app.UseRouting();

// Authorization is optional if no policies are defined
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

