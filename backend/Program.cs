using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Application.Interfaces;  // Para `IProductoService`
using Infrastructure.Services; // Para `ProductoService`

var builder = WebApplication.CreateBuilder(args);

// 🔹 1️⃣ Configurar la cadena de conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 2️⃣ Configurar CORS correctamente
var corsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder =>
    {
        builder.AllowAnyOrigin() // 🔥 Permitir cualquier origen temporalmente para pruebas
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// 🔹 3️⃣ Registrar los servicios
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// 🔹 4️⃣ Agregar Swagger a la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRUD2 API",
        Version = "v1",
        Description = "API para manejar productos en CRUD2"
    });
});

var app = builder.Build();

// 🔹 5️⃣ Aplicar middleware en el orden correcto
app.UseCors(corsPolicy); // 📌 Habilitar CORS ANTES de todo
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 🔹 6️⃣ Ruta de prueba para validar la API
app.MapGet("/test", () => "¡La API está funcionando correctamente! 🚀")
    .WithName("TestAPI");

app.Run();