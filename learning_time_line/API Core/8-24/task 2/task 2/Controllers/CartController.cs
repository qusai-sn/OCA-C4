using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Task_2 _context;

        public CartController(Task_2 context)
        {
            _context = context;
        }


    }
}
