using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_2.DTO;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly Task_2 _context;
        private  TokenGenerator _tokenGenerator;
        public userController(Task_2 context, TokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm] Login_DTOs input)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == input.username && u.Password == input.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var roles = new List<string> { "User" }; // Retrieve roles from database or assign default roles
            var token = _tokenGenerator.GenerateToken(user.Username, roles);

            return Ok(new { Token = token });
         }
    }
}
