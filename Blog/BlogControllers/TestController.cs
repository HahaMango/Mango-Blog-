using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Blog.JSONEntity;

namespace Blog.BlogControllers
{
    [Route("mango/blog/[controller]")]
    //[Produces("application/json")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration configuration;

        public TestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public ActionResult Hello()
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}