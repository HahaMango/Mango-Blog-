using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.JSONEntity;
using Blog.Helper;

namespace Blog.Service
{
    public interface ICommentService<UserType,ArticleType,CommentType>
    {
        Comment_JSON GetCommentById(UserType userid,CommentType commentid);
        List<Comment_JSON> GetComments(UserType userid);

        Resultion DeleteComment(UserType userid, CommentType commentid);
        Resultion UpdateComment(UserType userid, CommentType commentid,Comment_JSON comment);
        Resultion AddCommentToArticle(UserType userid, ArticleType articleid,Comment_JSON comment);
    }
}
