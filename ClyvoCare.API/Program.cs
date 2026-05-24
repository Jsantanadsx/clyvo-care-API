using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ClyvoCare.API.Data;
using ClyvoCare.API.Services;
using ClyvoCare.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Oracle Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(
        builder.Configuration.GetConnectionString("OracleConnection")
    )
);

// Services
builder.Services.AddScoped<TutorService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ClyvoCare.API",
        Version = "v1",
        Description = "API de gestão veterinária inteligente da plataforma ClyvoCare"
    });
});

var app = builder.Build();

// Swagger Middleware
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClyvoCare.API v1");
});

// HTTPS
app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Authorization
app.UseAuthorization();

// Controllers Mapping
app.MapControllers();

app.Run();