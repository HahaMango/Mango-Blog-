using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogControllers.User.Category
{
    [Route("mango/blog")]
    [ApiController]
    public class CategoryController : ControllerBase
    {        

        [HttpGet("user/{userid}/categories")]
        public ActionResult<List<string>> Get(string userid)
        {
            return null;
        }

    }
}