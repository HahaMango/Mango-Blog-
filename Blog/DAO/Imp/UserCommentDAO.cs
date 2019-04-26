using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _articleContext.Comments.Add(comment);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddCommentAsync(Comment comment)
        {
            try
            {
                _articleContext.Comments.Add(comment);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public int DeleteComment(Comment comment)
        {
            try
            {
                Comment temp = _articleContext.Comments.Where(c => c.CommentId == comment.CommentId)
                    .Single();

                _articleContext.Comments.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCommentAsync(Comment comment)
        {
            try
            {
                Comment temp = _articleContext.Comments.Where(c => c.CommentId == comment.CommentId)
                    .Single();

                _articleContext.Comments.Remove(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public List<Comment> GetCommentsByArticleId(string articleid)
        {
            try
            {
                return _articleContext.Comments
                    .Where(c => c.PageId == articleid)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comment>> GetCommentsByArticleIdAsync(string articleid)
        {
            try
            {
                return await _articleContext.Comments
                    .Where(c => c.PageId == articleid)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public List<Comment> GetCommentsSortByLike(string userid)
        {
            try
            {
                return _articleContext.Comments
                    .Where(c => c.UserId == userid)
                    .OrderByDescending(c => c.Like)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comment>> GetCommentsSortByLikeAsync(string userid)
        {
            try
            {
                return await _articleContext.Comments
                    .Where(c => c.UserId == userid)
                    .OrderByDescending(c => c.Like)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public List<Comment> GetCommentsSortByTime(string articleid)
        {
            try
            {
                return _articleContext.Comments
                    .Where(c => c.PageId == articleid)
                    .OrderByDescending(c => c.CreateTime)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comment>> GetCommentsSortByTimeAsync(string articleid)
        {
            try
            {
                return await _articleContext.Comments
                    .Where(c => c.PageId == articleid)
                    .OrderByDescending(c => c.CreateTime)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateComment(Comment comment)
        {
            try
            {
                Comment temp = _articleContext.Comments
                    .Where(c => c.CommentId == comment.CommentId)
                    .Single();

                temp.Content = comment.Content;
                temp.Like = comment.Like;

                _articleContext.Comments.Update(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateCommentAsync(Comment comment)
        {
            try
            {
                Comment temp = _articleContext.Comments
                    .Where(c => c.CommentId == comment.CommentId)
                    .Single();

                temp.Content = comment.Content;
                temp.Like = comment.Like;

                _articleContext.Comments.Update(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
