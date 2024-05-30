
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
      _userManager = userManager;
      _tokenRepository = tokenRepository;
    }

    // POST: /api/auth/register
    [HttpPost("Register")]
    public async Task<ActionResult<RegisterAuthDto>> Register(RegisterAuthDto registerAuthDto)
    {
      var identityUser = new IdentityUser
      {
        UserName = registerAuthDto.Username,
        Email = registerAuthDto.Username,
      };

      var identityResult = await _userManager.CreateAsync(identityUser, registerAuthDto.Password);

      if (identityResult.Succeeded)
      {
        // Add roles to this user

        if (registerAuthDto.Roles != null && registerAuthDto.Roles.Any())
        {
          identityResult = await _userManager.AddToRolesAsync(identityUser, registerAuthDto.Roles);

          if (identityResult.Succeeded)
          {
            return Ok("User was registered! Please Login.");
          }
        }
      }

      return BadRequest(identityResult);
    }

    // POST: /api/auth/login
    [HttpPost("Login")]
    public async Task<ActionResult<LoginRequestDto>> Login(LoginRequestDto loginRequestDto)
    {
      var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

      if (user != null)
      {
        var isUserPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

        if (isUserPasswordCorrect)
        {
          var roles = await _userManager.GetRolesAsync(user);

          if (roles != null && roles.Any())
          {
            // Create Token
            var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

            return Ok(new
            {
              success = true,
              message = "Successfully login.",
              tokens = new
              {
                accessToken = jwtToken
              }
            });
          }

        }
      }

      return BadRequest(new
      {
        message = "Username or Password incorrect.",
        user,
      });
    }
  }
}