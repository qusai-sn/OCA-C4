using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        // Helper method to upload images
        private async Task<string> UploadImageAsync(ProductDTO2 dto)
        {
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var imageFile = Path.Combine(uploadFolder, dto.ProductImage.FileName);

            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                await dto.ProductImage.CopyToAsync(stream);
            }

            return dto.ProductImage.FileName;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _context.Products.OrderByDescending(x => x.Price).ToListAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // GET: api/Products/byname?name=ProductName
        [HttpGet("byname")]
        public async Task<ActionResult> GetProductByName(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(n => n.ProductName == name);

            if (product == null)
            {
                return NotFound("Product not found with the specified name");
            }

            return Ok(product);
        }

        // GET: api/Products/ProductbyCategory?name=CategoryName
        [HttpGet("ProductbyCategory")]
        public async Task<ActionResult> GetProductByCategory(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);

            if (category == null)
            {
                return NotFound("Category not found with the specified name");
            }

            var products = await _context.Products.Where(p => p.CategoryId == category.CategoryId).ToListAsync();

            if (!products.Any())
            {
                return NotFound("No products found for the specified category");
            }

            return Ok(products);
        }

        // GET: api/Products/category/5
        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult> GetProductsByCategoryId(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();

            if (!products.Any())
            {
                return NotFound("No products found for the specified category");
            }

            return Ok(products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromForm] ProductDTO2 productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is null");
            }

            var imageName = await UploadImageAsync(productDto);

            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                ProductImage = imageName,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm] ProductDTO2 productDto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            if (productDto.ProductImage != null)
            {
                var imageName = await UploadImageAsync(productDto);
                product.ProductImage = imageName;
            }

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products/category/5
        [HttpPost("category/{categoryId:int}")]
        public async Task<ActionResult> AddProductToCategory(int categoryId, [FromForm] ProductDTO2 productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is null");
            }

            var imageName = await UploadImageAsync(productDto);

            var product = new Product
            {
                CategoryId = categoryId,
                Description = productDto.Description,
                Price = productDto.Price,
                ProductName = productDto.ProductName,
                ProductImage = imageName
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        



    }
}

