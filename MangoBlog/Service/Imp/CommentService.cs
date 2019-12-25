using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Entity;
using MangoBlog.Model;

namespace MangoBlog.Service.Imp
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDao _commentDao = null;

        public CommentService(ICommentDao commentDao)
        {
            _commentDao = commentDao;
        }

        public Task<bool> DeleteCommentAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CommentModel>> GetCommentsAsync(string articleId, int startCount, int count)
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
