using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Blog.JSONEntity;
using Blog.Service;
using Blog.Helper;

namespace Blog.BlogControllers.ArticleController
{

    [ApiController]
    public class CommentController : ControllerBase
    {
        private const string UrlPrefix = "/user";

        private readonly ICommentService<string, string, string> _commentService;

        public CommentController(ICommentService<string, string, string> commentService)
        {
            this._commentService = commentService;
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult<CommentJSON> GetComment(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();

            CommentJSON comment = null;
            comment = _commentService.GetCommentById(userid, id);
            if (comment == null)
                return NotFound();
            return comment;
        }

        [Route(UrlPrefix+"/{userid}/comments")]
        [HttpGet]
        [Authorize]
        public ActionResult<List<CommentJSON>> GetComments(string userid)
        {
            if (userid == null)
                return BadRequest();

            List<CommentJSON> comments = null;
            comments = _commentService.GetComments(userid);
            if (comments == null)
                return NotFound();
            return comments;
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteComment(string userid,string id)
        {
            if (userid == null || id == null)
                return BadRequest();

            Resultion resultion = _commentService.DeleteComment(userid,id);
            if (resultion.IsSuccess)
                return NoContent();
            return NotFound();
        }

        [Route(UrlPrefix+"/{userid}/comment/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateComment(string userid,string id,CommentJSON comment)
        {
            if (userid == null || id == null || comment == null)
                return BadRequest();

            Resultion resultion = _commentService.UpdateComment(userid, id, comment);
            if (resultion.IsSuccess)
                return CreatedAtAction(nameof(UpdateComment), resultion.Value);
            return NotFound();        
        }

        [Route(UrlPrefix+"/{userid}/article/{articleid}/comments")]
        [HttpPost]
        [Authorize]
        public ActionResult PostComment(string userid,string articleid,CommentJSON comment)
        {
            if (userid == null || articleid == null || comment == null)
                return BadRequest();

            Resultion resultion = _commentService.AddCommentToArticle(userid, articleid, comment);
            if (resultion.IsSuccess)
                return CreatedAtAction(nameof(PostComment), resultion.Value);
            return NotFound();
        }
    }
}