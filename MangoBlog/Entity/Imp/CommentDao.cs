using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;
using MangoBlog.Helper;
using Microsoft.EntityFrameworkCore;
using MangoBlog.Exception;

namespace MangoBlog.Entity.Imp
{
    public class CommentDao : ICommentDao
    {

        private readonly MangoBlogDBContext _dBContext = null;

        public CommentDao(MangoBlogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddCommentAsync(string articleId, CommentModel comment)
        {
            if(comment == null || articleId == null)
            {
                throw new ArgumentNullException();
            }
            using (var trans = _dBContext.Database.BeginTransaction())
            {
                try
                {
                    var commentEntity = ModelEntityHelper.CommentM2E(comment);
                    var articleEntity = await _dBContext.Articles.Where(a => a.Id == int.Parse(articleId)).SingleOrDefaultAsync();
                    if (articleEntity == null)
                    {
                        throw new NotFoundException($"没找到id为：{articleId}的文章");
                    }
                    articleEntity.Comment++;
                    commentEntity.ArticleId = (articleId != null) ? int.Parse(articleId) : 0;
                    _dBContext.Comments.Add(commentEntity);
                    await _dBContext.SaveChangesAsync();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        public async Task DeleteCommentAsync(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            var coment = await _dBContext.Comments.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
            if(coment == null)
            {
                throw new NotFoundException($"没找到id为：{id}的评论");
            }
            _dBContext.Comments.Remove(coment);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<CommentModel> GetCommentAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var comment = await _dBContext.Comments.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
            if(comment == null)
            {
                throw new NotFoundException($"没找到id为：{id}的评论");
            }
            return ModelEntityHelper.CommentE2M(comment);
        }

        public async Task<IList<CommentModel>> GetCommentsAsync(string articleId, int start, int count)
        {
            if(articleId == null)
            {
                throw new ArgumentNullException();
            }
            IList<CommentModel> commentModels = new List<CommentModel>();
            var commentsByArticleId = await _dBContext.Comments.Where(c => c.ArticleId == int.Parse(articleId)).ToListAsync();
            if(commentsByArticleId == null)
            {
                throw new NotFoundException($"没找到id为：{articleId} 的文章");
            }
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
