using Microsoft.OpenApi;
using TtrpgManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Controllers (API classique)
builder.Services.AddControllers();

// Swagger (UI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TtrpgManager API",
        Version = "v1",
    });
});

// Infrastructure (DbContext, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// CORS (utile si tu gardes aussi un front web, sinon tu peux enlever)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DevCors");

// ⚠️ Tant que tu n'as pas configuré HTTPS, commente cette ligne
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
