using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text;
using TEST.Data;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;
using TEST.Services;
using TEST.Validations;
using TEST.Mappers;
using TEST.Middleware;

var builder = WebApplication.CreateBuilder(args);
// cargar una configuracion de un nodo del fichero appsettings.json en una clase
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
// pasa esa clase como argumento a un servicio 
// builder.Services.Configure<JwtSettingsDTO>(jwtSettingsSection);
// con eso cuando se instancie un JwtSettingsDTO, ya tendrá esos valores inicializados
builder.Services.AddDbContext<MiData>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());

builder.Services.AddScoped<ICommonRepository<Tabla1>, Tabla1Repository>();
builder.Services.AddScoped<ICommonRepository<Tabla2>, Tabla2Repository>();
builder.Services.AddScoped<ICommonRepository<Tabla3>, Tabla3Repository>();

builder.Services.AddScoped<ICommonService<Tabla1Dto>, Tabla1Service>();
builder.Services.AddScoped<ICommonService<Tabla2Dto>, Tabla2Service>();
builder.Services.AddScoped<ITabla3Service, Tabla3Service>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Tabla3Dto>, Tabla3Validation>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TEST API", Version = "v1" });
    // Agrega la seguridad del token de autenticación
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    var key = jwtSettingsSection["SecretKey"]??"";
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettingsSection["ValidIssuer"],
        ValidAudience = jwtSettingsSection["ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
//definir politica de cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin() // Permitir cualquier origen
                            .AllowAnyMethod() // Permitir cualquier método HTTP
                            .AllowAnyHeader() // Permitir cualquier encabezado
                            //.AllowCredentials() // Permitir credenciales si es necesario, no compatible con AllowAnyOrigin
                        ;
                    });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAnyOrigin");//permitir cruce de dominios en las peticiones mediante cors
app.UseMiddleware<DemoMiddleware>();
//app.Use(async (context, next) =>
//{
//    //var tokenService = context.RequestServices.GetRequiredService<TokenValidateService>();
//    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
//    var ip = context.Connection.RemoteIpAddress?.ToString();

//    if (token != null)
//    {
//    //    // Realizar la validación del token utilizando el servicio TokenValidateService
//    //    // Esto es un ejemplo y debes adaptarlo según la lógica de validación que requieras
//    //    bool tokenValido = tokenService.Validate(token, ip);
//    //    if (!tokenValido)
//    //    {
//    //        context.Response.StatusCode = 401; // Unauthorized
//    //        await context.Response.WriteAsync("Token no válido");
//    //        return;
//    //    }
//    }

//    // Llamar al siguiente middleware en el pipeline
//    await next();
//});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
