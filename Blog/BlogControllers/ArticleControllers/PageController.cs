using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Blog.BlogControllers.ArticleControllers
{
    [Route("mango/blog/article/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        public PageController()
        {

        }

        [HttpGet]
        public ActionResult GetPageByTitle(string userid,string title)
        {
            //...
            return null;
        }

        [HttpGet]
        public ActionResult GetPageByPageid(string userid,string pageid)
        {
            return null;
        }

        //返回列表，具体类型再定义
        [HttpGet]
        public ActionResult GetPage(string userid)
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