using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Task1CoreContext _context;

        public ProductsController(Task1CoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet("getAllProducts")]
        public    List<Product> GetAllProducts()
        {
            return   _context.Products.ToList();
        }

        // GET: api/Products/{id}
        [HttpGet("getProductById/{id}")]
        public Product GetProductById(int id)
        {
            var product = _context.Products.Find(id);

            return product;
        }
    }
}

