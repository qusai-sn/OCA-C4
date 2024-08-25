using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using System.Linq;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Task_2 _context;

        public ProductsController(Task_2 context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var result = _context.Products.ToList();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetProductById(int id)
        {
            var result = _context.Products.Find(id);

            if (result == null)
            {
                return NotFound("Product not found");
            }

            return Ok(result);
        }

        [HttpGet("byname")]
        public ActionResult GetProductByName(string name)
        {
            var result = _context.Products.FirstOrDefault(n => n.ProductName == name);

            if (result == null)
            {
                return NotFound("Product not found with the specified name");
            }

            return Ok(result);
        }

        [HttpGet("ProductbyCategory")]
        public ActionResult GetProductByCategory(string name)
        {
            var category = _context.Categories.FirstOrDefault(record => record.CategoryName == name);

            if (category == null)
            {
                return NotFound("Category not found with the specified name");
            }

            var result = _context.Products.Where(product => product.CategoryId == category.CategoryId).ToList();

            if (!result.Any())
            {
                return NotFound("No products found for the specified category");
            }

            return Ok(result);
        }

        [HttpGet("category/{categoryId:int}")]
        public ActionResult GetProductsByCategoryId(int categoryId)
        {
            var result = _context.Products.Where(p => p.CategoryId == categoryId).ToList();

            if (!result.Any())
            {
                return NotFound("No products found for the specified category");
            }

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteProduct(int id)
        {
            var result = _context.Products.Find(id);

            if (result == null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
