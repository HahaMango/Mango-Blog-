using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Blog.Helper;
using Microsoft.AspNetCore.Http;

namespace Blog.BlogControllers.Category
{
    [Route("/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private DefaultCategory _defaultCategory;

        public CategoryController(DefaultCategory defaultCategory)
        {
            this._defaultCategory = defaultCategory;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Blog.JSONEntity.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Blog.JSONEntity.Category>> GetCategory()
        {
            List<Blog.JSONEntity.Category> categories = _defaultCategory.Categorys();
            if(categories == null)
            {
                return NotFound();
            }
            return categories;
        }


    }
}