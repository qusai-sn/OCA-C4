using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using task_2.Models;
using task_2.DTO;
using Microsoft.AspNetCore.Identity;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Task_2 _db;

        public UsersController(Task_2 context)
        {
            _db = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] usersDTOs model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            byte[] passwordHash, passwordSalt;

            HashingClass.CreatePassword(model.Password, out passwordHash, out passwordSalt);

            var user1 = new User
            {
                Username = model.username,
                Password = "password",
                HashedPassword = passwordHash,
                Salt = passwordSalt,
                Email = model.Email,

            };

            _db.Users.Add(user1);
            _db.SaveChanges();


            return Ok();
        }


        [HttpPost("Login")]
        public IActionResult Login([FromForm] Login_DTOs user)
        {


            var record = _db.Users.FirstOrDefault(u => u.Username == user.username);

            if (record != null && record.HashedPassword != null)
            {

                var result = HashingClass.VerifyPassword(user.Password, record.HashedPassword, record.Salt);

                if (result == true)
                {
                    return Ok(record);
                }
                else
                {
                    return Unauthorized("password uncorrect");
                }

            }


            return BadRequest("user not exist");

        }

    }

}
