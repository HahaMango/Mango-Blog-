﻿using Blog.JSONEntity;
using Blog.Service;
using Blog.Helper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.BlogControllers.ArticleController
{
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private const string UrlPrefix = "/user";

        private readonly IArticleBaseService<string, string> _articleBaseService;

        public ArticleController(IArticleBaseService<string,string> articleBaseService)
        {
            this._articleBaseService = articleBaseService;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpGet]
        public ActionResult<PageContent_JSON> GetContent(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();

            PageContent_JSON content = null;
            content = _articleBaseService.GetContent(userid, id);
            if (content == null)
                return NotFound();
            return content;
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpGet]
        public ActionResult<Article_JSON> GetInfo(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();

            Article_JSON article = null;
            article = _articleBaseService.GetArticleInfo(userid, id);
            if (article == null)
                return NotFound();
            return article;
        }

        [Route(UrlPrefix+ "/{userid}/article/{id}/detail")]
        [HttpGet]
        public ActionResult<Article_JSON> GetArticle(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();

            Article_JSON article = null;
            article = _articleBaseService.GetArticleWithContent(userid, id);
            if (article == null)
                return NotFound();
            return article;
        }

        [Route(UrlPrefix+"/{userid}/articles")]
        [HttpGet]
        public ActionResult<List<Article_JSON>> GetArticles(string userid)
        {
            if (userid == null)
                return BadRequest();

            List<Article_JSON> articles = null;
            articles = _articleBaseService.GetArticles(userid);
            if (articles == null)
                return NotFound();
            return articles;
        }

        [Route(UrlPrefix +"/{userid}/articles")]
        [HttpPost]
        [Authorize]
        public ActionResult AddArticle(string userid,Article_JSON article)
        {
            if (userid == null || article == null)
                return BadRequest();

            if (article.User_id == null)
                article.User_id = userid;

            Resultion resultion = _articleBaseService.AddArticle(userid, article);
            if (resultion.IsSuccess)
            {
                return CreatedAtAction(nameof(AddArticle), resultion.Value);
            }
            return NotFound();
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteArticle(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();
            Resultion resultion = _articleBaseService.DeleteArticle(userid, id);
            if (resultion.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

        [Route(UrlPrefix+"/{userid}/article/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateArticle(string userid,string id,Article_JSON article)
        {
            if (userid == null || id == null)
                return BadRequest();

            if (article.User_id == null)
                article.User_id = userid;

            if (article.Page_id == null)
                article.Page_id = id;

            Resultion resultion = _articleBaseService.UpdateArticle(userid, article);
            if(resultion.IsSuccess)
            {
                return CreatedAtAction(nameof(UpdateArticle), resultion.Value);
            }
            return NotFound();
        }
    }
}