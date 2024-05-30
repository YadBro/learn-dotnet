using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace NZWalks.API.Repositories
{
  public class TokenRepository : ITokenRepository
  {
    private readonly IConfiguration _configuration;

    public TokenRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string CreateJWTToken(IdentityUser user, List<string> roles)
    {
      // Create claims
      var claims = new List<Claim>
      {
          new(ClaimTypes.Email, user.Email)
      };

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetJwtKey(_configuration["Jwt:Key"])));

      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

      var securityToken = new JwtSecurityTokenHandler().WriteToken(token);

      return securityToken;
    }

    public string GetJwtKey(string path)
    {
      return Convert.ToBase64String(File.ReadAllBytes(path));
    }
  }
}