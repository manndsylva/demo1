using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Web1.Models;
using Web1.Models.Authentication.Signup;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register register,
            string role)
        {
            var userExist = await _userManager.FindByNameAsync(register.email ??"");
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, value: new Web1.Models.Response
                {
                    status = "Error",
                    message = "User Already exists"
                });
            }
            IdentityUser user = new()
            {
                Email = register.email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(user, register.Password ?? "");
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created, new Web1.Models.Response
                {
                    status = "Success",
                    message = "User Created !"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Web1.Models.Response
                {
                    status = "Error",
                    message = "Failed to create user !"
                });
            }
        }
    }
}
