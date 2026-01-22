using ourstars_back.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Configuração de Serviços (Injeção de Dependência)
// ==========================================

// Adiciona suporte a Controllers (para suas APIs)
builder.Services.AddControllers();

// Configura o Swagger (Documentação automática da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o Banco de Dados (PostgreSQL / Supabase)
// Ele busca a string "DefaultConnection" dos User Secrets ou appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Configura o CORS (Permite que o Next.js acesse o backend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin() // Em produção, troque pela URL do Vercel
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ==========================================
// 2. Construção do App (Pipeline de Requisição)
// ==========================================
var app = builder.Build();

// Configura o Swagger UI (apenas em desenvolvimento para testar fácil)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplica o CORS configurado acima
app.UseCors("AllowFrontend");

// Redireciona HTTP para HTTPS (segurança)
app.UseHttpsRedirection();

// Mapeia os Controllers que você criar
app.MapControllers();

// Inicia o servidor
app.Run();
