using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;

namespace Blog.DAO.Imp
{
    public class UserCommentDAO : IUserCommentDAO<string, string>
    {
        private readonly ArticleContext _articleContext = null;

        public UserCommentDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public int DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByArticleId(string articleid)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByLike(string userid)
        {
            throw new NotImplementedException();
        }

        public int UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
