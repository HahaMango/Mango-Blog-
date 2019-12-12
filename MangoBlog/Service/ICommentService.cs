using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Service
{
    public interface ICommentService
    {
        Task<IList<CommentModel>> GetCommentsAsync(string id,int startCount,int count);
        Task<IList<CommentModel>> GetCommentsAsync(string id);
        Task<bool> ReplyActionAsync(string artcileId, CommentModel comment);
    }
}
