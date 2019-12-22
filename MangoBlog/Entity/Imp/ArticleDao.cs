using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoBlog.Model;
using MangoBlog.Helper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MangoBlog.Entity.Imp
{
    /// <summary>
    /// 文章数据访问层
    /// </summary>
    public class ArticleDao : IArticleDao
    {
        private readonly MangoBlogDBContext _dBContext = null;

        public ArticleDao(MangoBlogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<bool> AddArticleAsync(ArticleInfoModel article)
        {
            if(article == null)
            {
                throw new NullReferenceException();
            }
            var entity = ModelEntityHelper.ArticleM2E(article);
            int changRow = 0;
            try
            {
                await _dBContext.Articles.AddAsync(entity);
                changRow = await _dBContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return (changRow > 0) ? true : false;
        }

        public async Task<bool> AddArticleContentAsync(ArticleContentModel articleContent)
        {
            if(articleContent == null)
            {
                throw new NullReferenceException();
            }
            var content = ModelEntityHelper.ContentM2E(articleContent);
            int changRow = 0;
            try
            {
                await _dBContext.ArticleContents.AddAsync(content);
                changRow = await _dBContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return (changRow > 0) ? true : false;
        }

        public async Task<int> ArticleCountAsync()
        {
            int count = 0;
            count = await _dBContext.Articles.CountAsync();
            return count;
        }

        public async Task<bool> DecIncLikeAsync(string id, bool inc)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var article = await _dBContext.Articles.Where(a => a.Id == int.Parse(id)).SingleOrDefaultAsync();
                if (inc)
                    article.Like++;
                else
                    article.Like--;
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException e)
            {
                return false;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteArticleById(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var article = await _dBContext.Articles.Where(a => a.Id == int.Parse(id)).SingleOrDefaultAsync();
                _dBContext.Articles.Remove(article);
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

        public async Task<ArticleContentModel> GetArticleContentAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var content = await _dBContext.ArticleContents.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
                return ModelEntityHelper.ContentE2M(content);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ArticleInfoModel> GetArticleInfoAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var article = await _dBContext.Articles.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
                return ModelEntityHelper.ArticleE2M(article);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int start, int count)
        {
            var articles = await _dBContext.Articles
                .OrderByDescending(a => a.Id)
                .Skip(start)
                .Take(count)
                .ToListAsync();
            IList<ArticleInfoModel> result = new List<ArticleInfoModel>();
            foreach(ArticleEntity ae in articles)
            {
                var temp = ModelEntityHelper.ArticleE2M(ae);
                result.Add(temp);
            }
            return result;
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync()
        {
            var articles = await _dBContext.Articles
                .OrderByDescending(a => a.Id)
                .ToListAsync();
            IList<ArticleInfoModel> result = new List<ArticleInfoModel>();
            foreach (ArticleEntity ae in articles)
            {
                var temp = ModelEntityHelper.ArticleE2M(ae);
                result.Add(temp);
            }
            return result;
        }

        public async Task<bool> IncViewAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var article = await _dBContext.Articles.Where(a => a.Id == int.Parse(id)).SingleOrDefaultAsync();
                article.Read++;
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

        public async Task<bool> UpdateArticleAsync(ArticleInfoModel article)
        {
            if(article == null)
            {
                throw new NullReferenceException();
            }
            int changRow = 0;
            try
            {
                var ae = ModelEntityHelper.ArticleM2E(article);
                _dBContext.Articles.Update(ae);
                changRow = await _dBContext.SaveChangesAsync();
                return (changRow > 0) ? true : false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateArticleContentAsync(ArticleContentModel articleContent)
        {
            if (articleContent == null)
            {
                throw new NullReferenceException();
            }
            int changRow = 0;
            try
            {
                var c = ModelEntityHelper.ContentM2E(articleContent);
                _dBContext.ArticleContents.Update(c);
                changRow = await _dBContext.SaveChangesAsync();
                return (changRow > 0) ? true : false;
            }
            catch
            {
                throw;
            }
        }
    }
}
