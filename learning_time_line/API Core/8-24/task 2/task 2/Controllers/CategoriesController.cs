using Microsoft.AspNetCore.Mvc;
using task_2.Models;  // Ensure your models are correctly referenced
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Task_2 _context;

        public CategoriesController(Task_2 context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _context.Categories.ToList();
            return Ok(result);
        }


        [HttpGet("{id:int:min(5)}")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _context.Categories.Find(id);
            if (result == null)
            {
                return NotFound("Category not found");
            }
            return Ok(result);
        }




        [HttpGet("byname")]
        public IActionResult GetCategoryByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is required");
            }

            var result = _context.Categories.FirstOrDefault(n => n.CategoryName == name);
            if (result == null)
            {
                return NotFound("Category not found");
            }
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var result = _context.Categories.Find(id);
            if (result == null)
            {
                return NotFound("Category not found");
            }

            _context.Categories.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            Category ct = new Category {

                CategoryImage = category.CategoryImage,
                CategoryName = category.CategoryName,

            };

            _context.Categories.Add(ct);
            _context.SaveChanges();


            return Ok(ct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] CategoryDTO category, int id)
        {
            var record = _context.Categories.Find(id);
            if (record == null)
            {
                return BadRequest();
            }

            record.CategoryImage = category.CategoryImage;
            record.CategoryName = category.CategoryName;

            _context.SaveChanges();

            return Ok(record);

        } 
    }

    }
