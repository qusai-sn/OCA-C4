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
            var result = _context.Products.OrderByDescending(x => x.Price).ToList();


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





        [HttpPost]
        public ActionResult AddProduct([FromForm] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }




        [HttpPost("add Product 2")]
        public ActionResult AddProduct2([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }





        [HttpPost("addProductWithDTO")]
        public ActionResult AddProduct_DTO([FromForm] ProductDTO2 product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }

            var uploadfolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadfolder))
            {
                Directory.CreateDirectory(uploadfolder);
            }

            var imageFile = Path.Combine(uploadfolder, product.ProductImage.FileName);

            using( var stream = new FileStream(imageFile, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }

            Product new_product = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ProductImage = product.ProductImage.FileName,
            };


            _context.Products.Add(new_product);
            _context.SaveChanges();

            return Ok(new_product);
        }




        [HttpPut("{id:int}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductDTO updatedProduct)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }

            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.ProductImage = updatedProduct.ProductImage;

            _context.SaveChanges();

            return NoContent();
        }




        [HttpPut("Update/{id}")]
        public ActionResult UpdateProduct_new(int id, [FromForm] ProductDTO product_dto)
        {
            var record = _context.Products.Find(id);

            if (record == null) {
                return NotFound();
            }
            record.ProductName = product_dto.ProductName;
            record.Description = product_dto.Description;
            record.Price = product_dto.Price;
            record.ProductImage = product_dto.ProductImage;

            _context.SaveChanges();

            return Ok(record);
        }

    }
}
