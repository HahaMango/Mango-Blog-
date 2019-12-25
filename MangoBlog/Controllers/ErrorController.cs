using MangoBlog.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MangoBlog.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exc = HttpContext.Features.Get<IExceptionHandlerFeature>();
            System.Exception e = exc.Error;

            if(e is NotFoundException)
            {
                return NotFound(e.Message);
            }
            else
            {
                return BadRequest(e.Message);
            }
        }
    }
}