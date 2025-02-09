using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EHRBS_backend.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using EHRBS_backend.Persistence.Repositories;
using EHRBS_backend.Persistence.Interfaces;
using EHRBS_backend.Application.Commands;

using MediatR;
using System.Reflection;
using EHRBS_backend.Infrastructure.Security;
using EHRBS_backend.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// 🔹 Add MediatR (for CQRS)
builder.Services.AddMediatR(typeof(RegisterUserHandler).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// 🔹 Add HttpContextAccessor (Required for accessing HttpContext)
builder.Services.AddHttpContextAccessor();

// 🔹 Add Session Support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "EHRBS_Session";
    options.IdleTimeout = TimeSpan.FromHours(3); // Set session timeout
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 🔹 Register Services
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<JwtService>(); // ✅ Use Scoped, Not Singleton

// 🔹 Configure Authentication & JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

// 🔹 Add Swagger for API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// 🔹 Enable Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔹 Ensure Session is Configured BEFORE Middleware Uses It
app.UseSession();

// 🔹 Apply Custom Middleware for Session Authentication (Only After Session Is Set)
//app.UseMiddleware<SessionJwtMiddleware>();

// 🔹 Enable Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Map Controllers
app.MapControllers();

app.Run();
