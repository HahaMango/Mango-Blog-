using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO.Imp
{
    public class ArticleContentDAO : IArticleContentDAO<int>
    {

        private readonly ArticleContext _articleContext = null;

        public ArticleContentDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddContent(ArticleContent articleContent)
        {
            try
            {
                _articleContext.ArticleContents.Add(articleContent);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddContentAsync(ArticleContent articleContent)
        {
            try
            {
                _articleContext.ArticleContents.Add(articleContent);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public int DeleteContent(ArticleContent articleContent)
        {
            try
            {
                ArticleContent temp = _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleContent.PageId)
                    .Single();

                _articleContext.ArticleContents.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteContentAsync(ArticleContent articleContent)
        {
            try
            {
                ArticleContent temp = _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleContent.PageId)
                    .Single();

                _articleContext.ArticleContents.Remove(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public ArticleContent GetArticleContent(int articleid)
        {
            try
            {
                return _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleid)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ArticleContent> GetArticleContentAsync(int articleid)
        {
            try
            {
                return await _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleid)
                    .SingleAsync();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateContent(ArticleContent articleContent)
        {
            try
            {
                ArticleContent temp = _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleContent.PageId)
                    .Single();

                temp.Content = articleContent.Content;

                _articleContext.ArticleContents.Update(temp);

                return _articleContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateContentAsync(ArticleContent articleContent)
        {
            try
            {
                ArticleContent temp = _articleContext.ArticleContents
                    .Where(ac => ac.PageId == articleContent.PageId)
                    .Single();

                temp.Content = articleContent.Content;

                _articleContext.ArticleContents.Update(temp);

                return await _articleContext.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }
    }
}
