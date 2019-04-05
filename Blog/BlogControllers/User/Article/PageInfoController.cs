using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogControllers.Article
{
    [Route("mango/blog/article/[controller]")]
    [ApiController]
    public class PageInfoController : ControllerBase
    {
        public PageInfoController()
        {

        }

        /**
         *   获取指定用户的文章信息列表
         *   
         *   参数：用户id
         *   返回值：列表
         * */
        [HttpGet]
        public ActionResult GetInfo(string userid)
        {
            return null;
        }

        /**
         *   获取指定用户的文章信息列表
         *   
         *   参数：用户id，返回的记录数
         *   返回值：列表
         * */
        [HttpGet]
        public ActionResult GetInfoByLimit(string userid,int count)
        {
            return null;
        }

        /**
         *   获取指定用户的文章信息
         *   
         *   参数：用户id，文章id
         *   返回值：文章信息
         * */
        [HttpGet]
        public ActionResult GetInfoById(string userid, string pageid)
        {
            return null;
        }

        /**
         *   获取指定用户的文章信息
         *   
         *   参数：用户id，文章标题
         *   返回值：文章信息
         * */
        [HttpGet]
        public ActionResult GetInfoByTitle(string userid,string title)
        {
            return null;
        }

        /**
         *   获取经过排序的指定用户的文章信息列表
         *   
         *   参数：用户id，排序方式标识
         *   
         *   返回值：文章信息列表
         * */
        [HttpGet]
        public ActionResult GetInfoByTitle(string userid,int sortflag)
        {
            return null;
        }
    }
}