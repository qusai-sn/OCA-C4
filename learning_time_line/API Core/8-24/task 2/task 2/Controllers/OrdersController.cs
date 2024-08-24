using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using System.Linq;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Task_2 _context;

        public OrdersController(Task_2 context)
        {
            _context = context;
        }

        

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Orders.ToList();

            if (!orders.Any())
            {
                return NotFound("No orders found.");
            }

            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid order ID.");
            }

            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return Ok(order);
        }



        // GET: api/Orders/username/{username}
        [HttpGet("username/{username}")]
        public IActionResult GetOrderByName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username is required.");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound($"User with username '{username}' not found.");
            }

            var orders = _context.Orders
                .Where(order => order.UserId == user.UserId)
                .ToList();

            if (!orders.Any())
            {
                return NotFound($"No orders found for user '{username}'.");
            }

            return Ok(orders);
        }
    }
}
