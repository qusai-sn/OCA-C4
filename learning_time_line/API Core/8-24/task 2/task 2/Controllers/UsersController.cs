using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using System.Linq;

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
        public IActionResult GetUserByName( string name)
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
    }
}
