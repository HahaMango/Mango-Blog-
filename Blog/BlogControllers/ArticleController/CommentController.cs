using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Blog.JSONEntity;

namespace Blog.BlogControllers.ArticleController
{

    [ApiController]
    public class CommentController : ControllerBase
    {
        private const string UrlPrefix = "/user";

        public CommentController()
        {
            
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult<Comment_JSON> GetComment(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/comments")]
        [HttpGet]
        [Authorize]
        public ActionResult<List<Comment_JSON>> GetComments(string userid)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteComment(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateComment(string userid,string id)
        {
            return null;
        }

        [Route(UrlPrefix+"/{userid}/article/{articleid}/comments")]
        [HttpPost]
        [Authorize]
        public ActionResult PostComment(string userid,string articleid,Comment_JSON comment)
        {
            return null;
        }
    }
}