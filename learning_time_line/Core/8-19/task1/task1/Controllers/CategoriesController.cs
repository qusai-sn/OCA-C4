using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace WepAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Task1CoreContext _context;

        public CategoriesController(Task1CoreContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet("getAllCategories")]
        public  List<Category> GetAllCategories()
        {
            return  _context.Categories.ToList();
        }

        // GET: api/Categories/{id}
        [HttpGet("getCategoryById/{id}")]
        public  Category GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
 

            return category;
        }
    }
}
