using MangoBlog.Service;
using Microsoft.AspNetCore.Mvc;

namespace MangoBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService = null;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
    }
}