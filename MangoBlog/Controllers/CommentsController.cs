using Microsoft.AspNetCore.Mvc;
using MangoBlog.Service;
using System.Threading.Tasks;
using MangoBlog.Exception;
using MangoBlog.Model;
using Microsoft.AspNetCore.Diagnostics;

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

        [HttpGet("article/{id}/{start}/{count}")]
        public async Task<IActionResult> GetComments(string id,int start,int count)
        {
            try
            {
                var comments = await _commentService.GetCommentsAsync(id, start, count);
                return Ok(comments);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("article/{id}")]
        public async Task<IActionResult> AddComment(string id,CommentModel commentModel)
        {
            try
            {
                await _commentService.ReplyActionAsync(id, commentModel);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}