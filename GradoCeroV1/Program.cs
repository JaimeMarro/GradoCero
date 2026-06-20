using GradoCeroV1.Data;
using GradoCeroV1.Components;
using GradoCeroV1.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (builder.Environment.IsProduction())
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    // Convertir URL de PostgreSQL a cadena de conexión
    var uri = new Uri(databaseUrl!);
    var userInfo = uri.UserInfo.Split(':');
    var connectionStringPg = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionStringPg));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
builder.Services.AddScoped<TransposicionService>();
builder.Services.AddScoped<EstadoSesion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();