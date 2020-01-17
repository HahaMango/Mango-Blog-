using Microsoft.AspNetCore.Mvc;
using MangoBlog.Service;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService = null;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel category)
        {            
            await _categoryService.AddCategoryAsync(category.CategoryName);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cs = await _categoryService.GetCategoriesAsync();
            return Ok(cs);
        }

        [HttpGet("articles/{articleId}")]
        public async Task<IActionResult> GetCategoryByArticleId(string articleId)
        {
            string categoryName = await _categoryService.GetCategoryByArticleIdAsync(articleId);
            return Ok(categoryName);
        }
    }
}