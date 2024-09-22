using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using task_2.DTO;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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


        [HttpPost("AddToCart")]
        public async Task<ActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            var product = await _context.Products.FindAsync(addToCartDto.ProductId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Ensure that the cart exists for the user
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == addToCartDto.userId);

            if (cart == null)
            {
                // If no cart exists, create one without setting CartID manually
                cart = new Cart
                {
                    UserId = addToCartDto.userId
                };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == addToCartDto.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += addToCartDto.Quantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = addToCartDto.ProductId,
                    Quantity = addToCartDto.Quantity,
                    CartId = cart.CartId, // Use the auto-generated CartID
                    Price = product.Price , 
                    
                   
                };

                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            return Ok(existingCartItem );
        }


        [HttpPut("EditCartItemQuantity/{productId:int}/{userId:int}")]
        public async Task<ActionResult> EditCartItemQuantity(int productId, int userId , [FromForm] int newQuantity)
        {
            // Assuming user ID is 1 for demonstration purposes. Replace with actual user identification logic.
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound("Cart not found for the user.");
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == productId);

            if (cartItem == null)
            {
                return NotFound("Product not found in the cart.");
            }

            if (newQuantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }

            cartItem.Quantity = newQuantity;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                ProductId = cartItem.ProductId,
                NewQuantity = cartItem.Quantity,
                UpdatedTotalPrice = cartItem.Quantity * cartItem.Price
            });
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
        [Authorize]
        [HttpGet("ProductbyCategory")]
        public async Task<ActionResult> GetProductByCategory(string name)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

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
        [Authorize]
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

            // Return the full URL to the image
            var imageUrl = $"{Request.Scheme}://{Request.Host}/Images/{dto.ProductImage.FileName}";

            return imageUrl;

        }

        // POST: api/Products
        [HttpPost] //example
        public async Task<ActionResult> AddProduct([FromForm] ProductDTO2 productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is null");
            }

            //create Image folder path
            // check if exist 
            // combine it with the image path
            // create a stream then copy the image to te stream 
            // reformat the url then store the url in the database 

            var folder_path = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }

            var Image_path = Path.Combine( folder_path, productDto.ProductImage.FileName);

            using (var stream = new FileStream(Image_path, FileMode.Create))
            {
                await productDto.ProductImage.CopyToAsync(stream);
            }

            var image_url = $"{Request.Scheme}://{Request.Host}/Images/{productDto.ProductImage.FileName}";

                //var imageName = await UploadImageAsync(productDto);

                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    ProductImage = image_url,
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
                    ProductImage = imageName //image path
                };

            
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(product);
            }
         


        // GET: api/Cart
        [HttpGet("/getCartDetails/{id:int}")]
        public async Task<ActionResult> GetCartDetails(int id)
        {
            // Assuming user ID is 1 for demonstration purposes. Replace with actual user identification logic.
            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .ThenInclude(ci => ci.Product)
                                           .FirstOrDefaultAsync(c => c.UserId == id);

            if (cart == null)
            {
                return NotFound("Cart not found for the user.");
            }

            var cartDetails = cart.CartItems.Select(ci => new
            {
                ci.ProductId,
                ci.Product.ProductName,
                ci.Product.ProductImage, // Include the ProductImage
                ci.Quantity,
                ci.Price,
                TotalPrice = ci.Quantity * ci.Price
            }).ToList();

            return Ok(new
            {
                CartId = cart.CartId,
                Items = cartDetails,
                Total = cartDetails.Sum(cd => cd.TotalPrice)
            });
        }


        [HttpDelete("RemoveFromCart/{productId:int}/{userId:int}")]
        public async Task<ActionResult> RemoveFromCart(int productId , int userId)
        {
            // Assuming user ID is 1 for demonstration purposes. Replace with actual user identification logic.
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound("Cart not found for the user.");
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == productId);

            if (cartItem == null)
            {
                return NotFound("Product not found in the cart.");
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return Ok("Product removed from the cart successfully.");
        }

        public static string Solution(string str)
        {

            string result = "";

            for (int i = str.Length - 1; i <= 0; i--)
            { //qusai 
                result += str[i];
            }
            return result;
        }



    }


} 
    


