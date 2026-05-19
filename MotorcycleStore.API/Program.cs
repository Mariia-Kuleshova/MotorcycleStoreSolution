using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using MotorcycleStore.Infrastructure.Data;
using MotorcycleStore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextFactory<StoreDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("MotorcycleStore.Infrastructure")
    )
);

builder.Services.AddTransient<InventoryRepository>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
        policy.WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Frontend");

// У Development не редіректимо на HTTPS — інакше браузер з localhost:5173 отримує CORS/мережеву помилку
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
