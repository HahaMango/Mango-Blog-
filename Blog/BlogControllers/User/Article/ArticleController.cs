using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Blog.BlogControllers.Article
{
    [Route("mango/blog")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public ArticleController()
        {

        }

    }
}