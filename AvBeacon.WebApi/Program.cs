
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using AvBeacon.Application;
using AvBeacon.Infrastructure.Configuration;
using AvBeacon.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
builder.Host.UseSerilog((context, loggerConfiguration) => {
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// Añadir servicios de layers
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException());

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//     };
// })
// .AddGoogle(options =>
// {
//     options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//     options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
// });

// // Añadir CORS
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAngularApp",
//         b => b
//             .AllowAnyOrigin()
//             .AllowAnyHeader()
//             .AllowAnyMethod());
// });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
