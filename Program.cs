using FluentValidation;
using FluentValidation.AspNetCore;
using TEST.Data;
using Microsoft.EntityFrameworkCore;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;
using TEST.Services;
using TEST.Validations;
using TEST.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MiData>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());
builder.Services.AddScoped<ICommonRepository<Tabla1>, Tabla1Repository>();
builder.Services.AddScoped<ICommonRepository<Tabla2>, Tabla2Repository>();
builder.Services.AddScoped<ICommonRepository<Tabla3>, Tabla3Repository>();
builder.Services.AddScoped<ICommonService<Tabla1Dto>, Tabla1Service>();
builder.Services.AddScoped<ICommonService<Tabla2Dto>, Tabla2Service>();
builder.Services.AddScoped<ITabla3Service, Tabla3Service>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Tabla3Dto>, Tabla3Validation>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    var key = builder.Configuration["Jwt:Key"];
    if (key != null)
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    }
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    //var tokenService = context.RequestServices.GetRequiredService<TokenValidateService>();
    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    var ip = context.Connection.RemoteIpAddress?.ToString();

    if (token != null)
    {
    //    // Realizar la validación del token utilizando el servicio TokenValidateService
    //    // Esto es un ejemplo y debes adaptarlo según la lógica de validación que requieras
    //    bool tokenValido = tokenService.Validate(token, ip);
    //    if (!tokenValido)
    //    {
    //        context.Response.StatusCode = 401; // Unauthorized
    //        await context.Response.WriteAsync("Token no válido");
    //        return;
    //    }
    }

    // Llamar al siguiente middleware en el pipeline
    await next();
});
app.MapControllers();
app.Run();
