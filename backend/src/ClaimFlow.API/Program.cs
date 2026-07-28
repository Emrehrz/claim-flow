using ClaimFlow.Application.Interfaces;
using ClaimFlow.Infrastructure;
using ClaimFlow.Application.Interfaces.Authentication;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Infrastructure.Data.Repositories;
using ClaimFlow.Application.Services;
using ClaimFlow.Infrastructure.Authentication;
using ClaimFlow.Application.Interfaces.Storage;
using ClaimFlow.Application.Interfaces.Ai;
using ClaimFlow.Infrastructure.Services.Storage;
using ClaimFlow.Infrastructure.Services.Ai;
using Serilog;
using Microsoft.OpenApi.Models; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
              ValidAudience = builder.Configuration["JwtSettings:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"] ?? throw new InvalidOperationException("JWT Secret not found")))
          };
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

// --- 2. DEĞİŞEN VEYA GENİŞLETİLEN KISIM BAŞLANGICI ---
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClaimFlow API", Version = "v1" });

    // JWT Bearer Güvenlik Tanımı
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Örnek: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
// --- GÜNCELLENEN KISIM BİTİŞİ ---

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalClients", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IPolicyService, PolicyService>();
builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IAiService, MockAiService>();

builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowLocalClients");

app.UseStaticFiles(); // Bu satır wwwroot klasörünü dışarıya açar

app.UseRouting();

// KİMLİK DOĞRULAMA VE YETKİLENDİRME SIRASI ÖNEMLİDİR:
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();