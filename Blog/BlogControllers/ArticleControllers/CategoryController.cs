using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Blog.BlogControllers.ArticleControllers
{
    [Route("mango/blog/article/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController()
        {

        }

        [HttpGet]
        public ActionResult<List<string>> GetCategory(string userid)
        {
            //...
            return null;
        }

        //请求类型待定义
        [HttpPut]
        [Authorize]
        public ActionResult UpdateCategory(string userid)
        {
            //...
            return null;
        }

        //请求类型待定义
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCategory(string userid)
        {
            //...
            return null;
        }

        //请求类型待定义
        [HttpPost]
        [Authorize]
        public ActionResult EditCategory(string userid)
        {
            //...
            return null;
        }
    }
}
