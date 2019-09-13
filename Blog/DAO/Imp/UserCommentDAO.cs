using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO.Imp
{
    public class UserCommentDAO : IUserCommentDAO<int, int, int>
    {
        public int AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }

        public int DeleteComment(int commentid)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCommentAsync(int commentid)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCommentByIdAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByArticleId(int articleid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentsByArticleIdAsync(int articleid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByUserid(int userid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentsByUseridAsync(int userid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsSortByLike(int userid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentsSortByLikeAsync(int userid, int page, int count)
        {
            throw new NotImplementedException();
        }

        public int IncLike(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncLikeAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public int UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
