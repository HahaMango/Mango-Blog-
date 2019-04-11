using Blog.JSONEntity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.BlogControllers.ArticleController
{
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private const string UrlPrefix = "/user";

        public ArticleController()
        {
            
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpGet]
        public ActionResult<PageContent_JSON> GetContent(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpGet]
        public ActionResult<PageInfo_JSON> GetInfo(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpGet]
        public ActionResult<Article_JSON> GetArticle(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/articles")]
        [HttpGet]
        public ActionResult<List<PageInfo_JSON>> GetArticles(string userid)
        {
            return null;
        }

        [Route(UrlPrefix +"/{userid}/articles")]
        [HttpPost]
        [Authorize]
        public ActionResult AddArticle(string userid,Article_JSON article)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteArticle(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateArticle(string userid,string id)
        {
            return null;
        }
    }
}