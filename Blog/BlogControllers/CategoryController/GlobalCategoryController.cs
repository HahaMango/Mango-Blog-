using Blog.Helper;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.BlogControllers.CategoryController
{
    [Route("/[controller]")]
    [ApiController]
    public class GlobalCategoryController : ControllerBase
    {
        private DefaultCategory _defaultCategory;

        public GlobalCategoryController(DefaultCategory defaultCategory)
        {
            this._defaultCategory = defaultCategory;
        }

        [HttpGet]
        //[ProducesResponseType(typeof(List<Blog.JSONEntity.Category>), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<JSONEntity.Category_JSON>> GetCategory(int? a,string d)
        {
            List<Blog.JSONEntity.Category_JSON> categories = _defaultCategory.Categorys();
            if(categories == null)
            {
                return NotFound();
            }
            return categories;
            
        }
    }
}