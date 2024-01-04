using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Models.DTO;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
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
                    // create token


                    return Ok();
                }
            }

            return BadRequest("Username or password is incorrect");
        }
    }
}
