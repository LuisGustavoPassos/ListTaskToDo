using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;

Env.Load(); // Carrega variáveis do .env

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
    ?? throw new InvalidOperationException("DB_CONNECTION_STRING não configurada");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);        
        
var app = builder.Build();

app.MapControllers();   

app.Run();
