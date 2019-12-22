using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;
using MangoBlog.Helper;
using Microsoft.EntityFrameworkCore;

namespace MangoBlog.Entity.Imp
{
    public class CommentDao : ICommentDao
    {

        private readonly MangoBlogDBContext _dBContext = null;

        public CommentDao(MangoBlogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<bool> AddCommentAsync(CommentModel comment)
        {
            if(comment == null)
            {
                throw new NullReferenceException();
            }
            var commentEntity = ModelEntityHelper.CommentM2E(comment);
            int changRow = 0;
            try
            {
                _dBContext.Comments.Add(commentEntity);
                changRow = await _dBContext.SaveChangesAsync();
                return (changRow > 0) ? true : false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteCommentAsync(string id)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var coment = await _dBContext.Comments.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
                _dBContext.Comments.Remove(coment);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException e)
            {
                return false;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public async Task<CommentModel> GetCommentAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var comment = await _dBContext.Comments.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
                return ModelEntityHelper.CommentE2M(comment);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<CommentModel>> GetCommentsAsync(string articleId, int start, int count)
        {
            if(articleId == null)
            {
                throw new NullReferenceException();
            }
            IList<CommentModel> commentModels = new List<CommentModel>();
            var commentsByArticleId = await _dBContext.Comments.Where(c => c.ArticleId == int.Parse(articleId)).ToListAsync();
            commentsByArticleId = commentsByArticleId.OrderByDescending(c => c.Id).Skip(start).Take(count).ToList();
            foreach(CommentEntity ce in commentsByArticleId)
            {
                var cm = ModelEntityHelper.CommentE2M(ce);
                commentModels.Add(cm);
            }
            return commentModels;
        }
    }
}
