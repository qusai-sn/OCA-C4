using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserDataController : ControllerBase
    {
        private readonly Task_2 _context;

        public GetUserDataController(Task_2 context)
        {
            _context = context;
        }

        [HttpPost("getUserByName")]
        public IActionResult GetUserData([FromForm] string name)
        {   

            var record = _context.Users.FirstOrDefault( u => u.Username == name);

            if(record != null)
            {
                return Ok(record);
            }
            return NoContent();
        }
    }
}
