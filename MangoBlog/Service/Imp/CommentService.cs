using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Service.Imp
{
    public class CommentService : ICommentService
    {
        private readonly ICommentService _commentService = null;

        public CommentService(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public Task<IList<CommentModel>> GetCommentsAsync(string id, int startCount, int count)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CommentModel>> GetCommentsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplyActionAsync(string artcileId, CommentModel comment)
        {
            throw new NotImplementedException();
        }
    }
}
