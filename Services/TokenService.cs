
using TEST.Services;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

internal sealed class TokenService : ITokenService
{
    private readonly string _secretKey;
    private readonly string _dbPath;
    public TokenService(IConfiguration configuration)
    {
        Server = "";
        UserName = "";
        Password = "";
        _configuration = configuration;
        IConfigurationSection seccion = _configuration.GetSection("Security");
        _secretKey = seccion.GetValue("SecretKey", "") ?? "";
        seccion = _configuration.GetSection("Groupjson");
        _dbPath = seccion.GetValue("path", "") ?? "";

    }
    private readonly IConfiguration _configuration;
    public string Server { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool Validate(string token, string ip)
    {
        token = token.Replace("Bearer ", "");
        string secretKey = _secretKey;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        this.Server = _dbPath;
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        string tokenip = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "ip")?.Value ?? string.Empty;
        this.UserName = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "user")?.Value ?? string.Empty;
        this.Password = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "token")?.Value ?? string.Empty;

        if (tokenip != ip) return false;
        return true;
    }
    public (bool, string) Create(string ip, string user, string pass)
    {
        string token = GenerarToken(ip, user, pass);
        return (true, token);
    }
    private string GenerarToken(string ip, string user, string payload)
    {
        DateTime expiracion = DateTime.UtcNow.AddHours(8); // El token expira en 8 hora
        string secretKey = _secretKey;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("ip", ip),
            new Claim("user", user),
            new Claim("payload", payload),
            new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expiracion).ToUnixTimeSeconds().ToString("N",new CultureInfo("es-ES")))
        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: expiracion,
            signingCredentials: creds
        );
        return tokenHandler.WriteToken(token);
    }
}