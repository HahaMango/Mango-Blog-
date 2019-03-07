using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.APIControllers
{
    [Route("mango/blog/[controller]")]
    //[Produces("application/json")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult<List<string>> Hello()
        {
            List<string> list = new List<string>();
            return list;
        }
    }
}