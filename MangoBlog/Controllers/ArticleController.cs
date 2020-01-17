using MangoBlog.Model;
using MangoBlog.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService = null;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleModel article)
        {
            ArticleInfoModel articleInfo = article.ToArticleInfoModel();
            ArticleContentModel articleContent = article.ToArticleContentModel();
            await _articleService.AddArticleAsync(articleInfo,articleContent);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(string id)
        {
            ArticleInfoModel articleInfo = await _articleService.GetArticleByIdAsync(id);
            return Ok(articleInfo);
        }

        [HttpGet("{start}/{count}")]
        public async Task<IActionResult> GetArticles(int start,int count)
        {
            var list = default(IList<ArticleInfoModel>);
            list = await _articleService.GetArticleInfosAsync(start, count);
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var list = default(IList<ArticleInfoModel>);
            list = await _articleService.GetArticleInfosAsync();
            return Ok(list);
        }

        [HttpGet("content/{id}")]
        public async Task<IActionResult> GetContent(string id)
        {
            ArticleContentModel articleContent = null;
            articleContent = await _articleService.GetArticleContentByIdAsync(id);
            return Ok(articleContent);
        }

        [HttpPut("like/{id}")]
        public async Task<IActionResult> Like(string id)
        {
            await _articleService.DecIncLikeActionAsync(id, true);
            return Ok();
        }

        [HttpPut("read/{id}")]
        public async Task<IActionResult> Read(string id)
        {
            await _articleService.IncViewActionAsync(id);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            await _articleService.DeleteArticleAsync(id);
            return Ok();
        }
    }
}