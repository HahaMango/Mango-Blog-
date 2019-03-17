using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogControllers.Article
{
    [Route("mango/blog/article/[controller]")]
    [ApiController]
    public class PageContextController : ControllerBase
    {
        public PageContextController()
        {

        }

        [HttpGet]
        public ActionResult GetContextById(string userid,string pageid)
        {
            return null;
        }

        public ActionResult GetContextByTitle(string userid,string title)
        {
            return null;
        }
    }
}