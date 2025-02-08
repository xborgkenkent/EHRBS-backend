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

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add MediatR
builder.Services.AddMediatR(typeof(RegisterUserHandler).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "YouCanSetACookieNameHere";
    options.IdleTimeout = TimeSpan.FromHours(3); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//context.Response.Cookies.Append("JwtToken", token, new CookieOptions
//{
//    HttpOnly = true,
//    Secure = true,
//    SameSite = SameSiteMode.Strict,
//    Expires = DateTime.UtcNow.AddHours(3)
//});

builder.Services.AddScoped<JwtService>(); // Ensure JwtService is available

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<JwtService>();

// Add authentication
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


builder.Services.AddSingleton<JwtService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();  // ✅ Ensure session is set before middleware

app.UseMiddleware<SessionJwtMiddleware>();  // ✅ This should be AFTER session is set

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
