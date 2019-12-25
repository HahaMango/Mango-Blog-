using MangoBlog.Model;
using MangoBlog.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoBlog.Exception;

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
            try
            { 
                await _articleService.AddArticleAsync(articleInfo,articleContent);
            }
            catch(System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(articleInfo);
        }

        [HttpGet("{start}/{count}")]
        public async Task<IActionResult> GetArticles(int start,int count)
        {
            var list = default(IList<ArticleInfoModel>);
            try
            {
                list = await _articleService.GetArticleInfosAsync(start,count);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var list = default(IList<ArticleInfoModel>);
            try
            {
                list = await _articleService.GetArticleInfosAsync();
            }
            catch(System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(list);
        }

        [HttpGet("content/{id}")]
        public async Task<IActionResult> GetContent(string id)
        {
            ArticleContentModel articleContent = null;
            try
            {
                articleContent = await _articleService.GetArticleContentByIdAsync(id);
            }
            catch(System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(articleContent);
        }

        [HttpPut("like/{id}")]
        public async Task<IActionResult> Like(string id)
        {
            try
            {
                await _articleService.DecIncLikeActionAsync(id, true);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }catch(System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("read/{id}")]
        public async Task<IActionResult> Read(string id)
        {
            try
            {
                await _articleService.IncViewActionAsync(id);
                return Ok();
            }catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }catch(System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}