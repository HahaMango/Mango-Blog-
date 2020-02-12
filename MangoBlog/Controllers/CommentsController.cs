using MangoBlog.Model;
using MangoBlog.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MangoBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService = null;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("article/{id}/{date}/{count}")]
        public async Task<IActionResult> GetComments(string id,string date,int count)
        {
            var comments = await _commentService.GetCommentsAsync(id, date, count);
            return Ok(comments);
        }

        [HttpPost("article/{id}")]
        public async Task<IActionResult> AddComment(string id,CommentModel commentModel)
        {
            await _commentService.ReplyActionAsync(id, commentModel);
            return Ok();
        }
    }
}