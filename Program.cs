using Microsoft.EntityFrameworkCore;
using WebAPI.Context;

// Inicializa o construtor da aplicação
var builder = WebApplication.CreateBuilder(args);

// Configura os serviços essenciais para a aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura a string de conexão com o banco de dados PostgreSQL
string postgreSQLConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "DefaultConnectionString";

// Registra o contexto do banco de dados com suporte ao PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(postgreSQLConnectionString)
);

// Configuração de política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Constrói a aplicação
var app = builder.Build();

// Disponibiliza a documentação da API com Swagger durante o desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
    });
}

// Configura redirecionamento de HTTP para HTTPS em ambientes que não sejam de desenvolvimento
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Aplica o middleware de CORS utilizando a política configurada
app.UseCors("AllowAngular");

// Configura o middleware para autenticação e autorização
app.UseAuthorization();

// Configura o roteamento para os controllers da API
app.MapControllers();

// Inicia a execução da aplicação
app.Run();
