using MangoBlog.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoBlog.Service
{
    public interface ICommentService
    {
        Task<IList<CommentModel>> GetCommentsAsync(string articleId,int startCount,int count);
        Task<IList<CommentModel>> GetCommentsAsync(string id);
        Task ReplyActionAsync(string artcileId, CommentModel comment);
        Task DeleteCommentAsync(string id);
    }
}
