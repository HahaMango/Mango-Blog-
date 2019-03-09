using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Blog.APIControllers
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

        [HttpGet]
        public ActionResult<List<string>> Hello()
        {
            List<string> list = new List<string>();
            string n = configuration["IdentityService"];
            return list;
        }
    }
}