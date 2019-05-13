using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;

namespace Blog.Service.lmp
{
    public class CommentService : ICommentService<string, string, string>
    {
        public Resultion AddCommentToArticle(string userid, string articleid, CommentJSON comment)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> AddCommentToArticleAsync(string userid, string articleid, CommentJSON comment)
        {
            throw new NotImplementedException();
        }

        public Resultion DeleteComment(string userid, string commentid)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> DeleteCommentAsync(string userid, string commentid)
        {
            throw new NotImplementedException();
        }

        public CommentJSON GetCommentById(string userid, string commentid)
        {
            throw new NotImplementedException();
        }

        public Task<CommentJSON> GetCommentByIdAsync(string userid, string commentid)
        {
            throw new NotImplementedException();
        }

        public List<CommentJSON> GetComments(string userid)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentJSON>> GetCommentsAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public Resultion UpdateComment(string userid, string commentid, CommentJSON comment)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> UpdateCommentAsync(string userid, string commentid, CommentJSON comment)
        {
            throw new NotImplementedException();
        }
    }
}
