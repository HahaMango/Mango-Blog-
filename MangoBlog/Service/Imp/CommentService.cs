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

        public async Task DeleteCommentAsync(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            await _commentDao.DeleteCommentAsync(id);
        }

        public async Task<IList<CommentModel>> GetCommentsAsync(string articleId, int startCount, int count)
        {
            if(articleId == null)
            {
                throw new ArgumentNullException();
            }
            return await _commentDao.GetCommentsAsync(articleId, startCount, count);
        }

        public Task<IList<CommentModel>> GetCommentsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task ReplyActionAsync(string artcileId, CommentModel comment)
        {
            if(artcileId == null || comment == null)
            {
                throw new ArgumentNullException();
            }
            await _commentDao.AddCommentAsync(artcileId, comment);          
        }
    }
}
