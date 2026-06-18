using CatalogoWeb.Data;
using CatalogoWeb.Business;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Conexion a la Base de Datos con SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registro de dependencias Scoped para Base de Datos
builder.Services.AddScoped<IContenidoRepository, ContenidoSqlRepository>();
builder.Services.AddScoped<IContenidoService, ContenidoService>();

// Forza al servidor a escuchar en el puerto local 5000 sin cerrarse
builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(5000));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();