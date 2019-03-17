using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Blog.Helper;

namespace Blog.BlogControllers.Category
{
    [Route("mango/blog/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private DefaultCategory _defaultCategory;

        public CategoryController(DefaultCategory defaultCategory)
        {
            this._defaultCategory = defaultCategory;
        }

        [HttpGet]
        public ActionResult<List<string>> GetCategory()
        {
            return _defaultCategory.Categorys();
        }


    }
}