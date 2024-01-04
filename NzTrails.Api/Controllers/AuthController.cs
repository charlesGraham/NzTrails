using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Models.DTO;
using NzTrails.Api.Repositories.Interfaces;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepo _tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepo tokenRepo)
        {
            _tokenRepo = tokenRepo;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Username
            };

            // creates user
            var identityResult = await _userManager.CreateAsync(
                identityUser,
                registerRequest.Password
            );

            if (identityResult.Succeeded)
            {
                // add roles
                if (registerRequest.Roles is not null && registerRequest.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(
                        identityUser,
                        registerRequest.Roles
                    );

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered!");
                    }
                }
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            // find user
            var user = await _userManager.FindByEmailAsync(loginRequest.Username);

            if (user is not null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

                if (result)
                {
                    // get user roles
                    var userRoles = await _userManager.GetRolesAsync(user);

                    if (userRoles is not null)
                    {
                        // create token
                        var jwtToken = _tokenRepo.CreateJwtToken(user, userRoles.ToList());

                        var response = new LoginResponseDto { JwtToken = jwtToken };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password is incorrect");
        }
    }
}
