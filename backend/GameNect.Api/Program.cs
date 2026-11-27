using System.Text;
using GameNect.Api.Context;
using GameNect.Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameNectDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();

// Gestione logger 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Gestione jwt 
var jwtSection = builder.Configuration.GetSection("Jwt");

var issuer = jwtSection["Issuer"]
             ?? throw new InvalidOperationException("Configurazione Jwt:Issuer mancante.");

var audience = jwtSection["Audience"]
               ?? throw new InvalidOperationException("Configurazione Jwt:Audience mancante.");

var signingKey = jwtSection["SigningKey"]
                 ?? throw new InvalidOperationException("Configurazione Jwt:SigningKey mancante.");

if (Encoding.UTF8.GetByteCount(signingKey) < 32)
    throw new InvalidOperationException(
        "Jwt:SigningKey deve contenere almeno 32 byte.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            // Token deve provenire dall'emittente atteso, che deve corrispondere all'Issuer
            ValidateIssuer = true,
            ValidIssuer = issuer,

            // Verifica del token che deve essere destinato all'API corretta, quindi corrispondente ad Audience
            ValidateAudience = true,
            ValidAudience = audience,

            // Verifica del token che deve essere stato firmato da chi possiede la chiave 
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(signingKey)),

            // Rifiuto dei token scaduti
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),

            // Quale claim del token deve trattare come nome dell’utente 
            NameClaimType = "sub"
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.Run();