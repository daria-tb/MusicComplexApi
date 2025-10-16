using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using MusicComplexRepositories;
using MusicComplexModels.Entities;

namespace MusicComplexApi.Controllers
{
    [ApiController]
    [Route("signin-google")]
    public class GoogleAuthController : ControllerBase
    {
        private readonly MusicDbContext _dbContext;

        public GoogleAuthController(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> HandleGoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return Unauthorized();

            var userClaims = result.Principal;
            var googleId = userClaims.FindFirst(c => c.Type == "sub")?.Value;
            var email = userClaims.FindFirst(c => c.Type == "email")?.Value;
            var fullName = userClaims.FindFirst(c => c.Type == "name")?.Value;

            if (googleId == null) return BadRequest("GoogleId not found");

            var user = _dbContext.Users.FirstOrDefault(u => u.GoogleId == googleId);
            if (user == null)
            {
                user = new User
                {
                    GoogleId = googleId,
                    Email = email,
                    FullName = fullName,
                    Username = email ?? fullName
                };
                _dbContext.Users.Add(user);
            }
            else
            {
                user.Email = email;
                user.FullName = fullName;
            }
            await _dbContext.SaveChangesAsync();

            return Redirect("/swagger");
        }
    }
}