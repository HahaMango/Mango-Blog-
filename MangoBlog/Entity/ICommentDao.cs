using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Entity
{
    public interface ICommentDao
    {
        Task<bool> AddCommentAsync(CommentModel comment);
        Task<bool> DeleteCommentAsync(string id);
        Task<IList<CommentModel>> GetCommentsAsync(string articleId,int start,int count);
        Task<CommentModel> GetCommentAsync(string id);
    }
}
