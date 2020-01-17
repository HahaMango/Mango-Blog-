using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Entity
{
    public interface ICommentDao
    {
        Task AddCommentAsync(string articleId,CommentModel comment);
        Task DeleteCommentAsync(string id);
        Task<IList<CommentModel>> GetCommentsAsync(string articleId,int start,int count);
        Task<CommentModel> GetCommentAsync(string id);
    }
}
