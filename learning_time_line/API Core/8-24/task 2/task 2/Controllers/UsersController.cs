using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Task_2 _context;

        public UsersController(Task_2 context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        // GET: api/Users/byname?name={name}
        [HttpGet("byname")]
        public IActionResult GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is required");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == name);

            if (user == null)
            {
                return NotFound("User not found with the specified name");
            }
            return Ok(user);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult AddUser([FromForm] UserDTO user_dto)
        {
            if (user_dto == null)
            {
                return BadRequest("User is null");
            }

            User user = new User
            {
                 Email = user_dto.Email,
                 Username = user_dto.Username,
                 Password   = user_dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, [FromForm] UserDTO updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("User data is invalid");
            }

            var existingUser = _context.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            existingUser.Username = updatedUser.Username;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = HashPassword(updatedUser.Password); 

            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid login request");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == loginModel.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            if (VerifyPassword(loginModel.Password, user.Password))
            {
                // If you want to generate a token (e.g., JWT), this is where you would do it
                return Ok(new { message = "Login successful", user = user });
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }

        // Utility method to hash passwords
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        // Utility method to verify passwords
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            var parts = storedPassword.Split('.', 2);
            if (parts.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(parts[0]);
            string hashedEnteredPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedEnteredPassword == parts[1];
        }
    }

    // Login model to handle the login request
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
