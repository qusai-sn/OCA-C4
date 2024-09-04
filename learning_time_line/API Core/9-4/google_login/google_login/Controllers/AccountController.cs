using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var props = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleResponse", "Account")   
        };
        return Challenge(props, GoogleDefaults.AuthenticationScheme);   
    }

    [HttpGet("GoogleResponse")]
    public async Task<IActionResult> GoogleResponse()
    {
         var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

         if (result?.Principal == null)
        {
            return BadRequest("Google authentication failed.");
        }

         var claimsIdentity = result.Principal.Identity as ClaimsIdentity;
        var name = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
        var email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
        var givenName = claimsIdentity.FindFirst(ClaimTypes.GivenName)?.Value;
        var surname = claimsIdentity.FindFirst(ClaimTypes.Surname)?.Value;
 
        return Ok(new
        {
            Name = name,
            GivenName = givenName,
            Surname = surname,
            Email = email
        });
    }
}
