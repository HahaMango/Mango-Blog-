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

        [HttpGet("user/{userid}/article/{pageid}")]
        public ActionResult GetPageByPageid(string userid,string pageid)
        {
            return null;
        }

        //根据请求过滤筛选
        [HttpGet("user/{userid}/articles")]
        public ActionResult GetPage(string userid,string title,string createtime,int commentcount,int like)
        {
            //...
            return null;
        }

        //具体请求类型再定义
        [HttpPost]
        [Authorize]
        public ActionResult AddArticle(string userid)
        {
            //...
            return null;
        }

        //删除文章 用户id和文章id作参数
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteArticle(string userid,string pageid)
        {
            //...
            return null;
        }

        //删除文章 用户id和文章标题作参数
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteArticleByTitle(string userid,string title)
        {
            //...
            return null;
        }

        //编辑文章 用户id和文章id作参数
        [HttpPut]
        [Authorize]
        public ActionResult EditArticle(string userid,string pageid)
        {
            //...
            return null;
        }

        //编辑文章 用户id和文章标题作参数
        [HttpPut]
        [Authorize]
        public ActionResult EditArticleByTitle(string userid,string title)
        {
            //...
            return null;
        }
    }
}