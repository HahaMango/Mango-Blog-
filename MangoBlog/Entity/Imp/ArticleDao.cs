using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoBlog.Model;
using MangoBlog.Helper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MangoBlog.Exception;

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

        public async Task AddArticleAsync(ArticleInfoModel article,ArticleContentModel articleContentModel)
        {
            if(article == null || articleContentModel == null)
            {
                throw new ArgumentNullException();
            }
            using (var trans = _dBContext.Database.BeginTransaction())
            {
                try
                {
                    string category = article.Category;
                    var categoryEntity = await _dBContext.Categories.Where(c => c.CategoryName == category).SingleOrDefaultAsync();
                    if(categoryEntity == null)
                    {
                        categoryEntity = new CategoryEntity
                        {
                            CategoryName = category
                        };
                    }
                    var entity = ModelEntityHelper.ArticleM2E(article);
                    var content = ModelEntityHelper.ContentM2E(articleContentModel);
                    entity.ArticleContent = content;
                    entity.Category = categoryEntity;

                    await _dBContext.Articles.AddAsync(entity);
                    await _dBContext.SaveChangesAsync();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        public async Task<int> ArticleCountAsync()
        {
            int count = 0;
            count = await _dBContext.Articles.CountAsync();
            return count;
        }

        public async Task DecIncLikeAsync(string id, bool inc)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            var article = await _dBContext.Articles.Where(a => a.Id == int.Parse(id)).SingleOrDefaultAsync();
            if (article == null)
            {
                throw new NotFoundException($"没找到id为：{id} 的文章");
            }
            if (inc)
                article.Like++;
            else
                article.Like--;
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteArticleById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var article = await _dBContext.Articles
                .Include(a=>a.ArticleContent)
                .Include(a=>a.Comments)
                .Where(a => a.Id == int.Parse(id))
                .SingleOrDefaultAsync();
            if(article == null)
            {
                throw new NotFoundException($"没找到id为：{id} 的文章");
            }
            _dBContext.Articles.Remove(article);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<ArticleContentModel> GetArticleContentAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                var content = await _dBContext.ArticleContents.Where(c => c.ArticleId == int.Parse(id)).SingleOrDefaultAsync();
                if(content == null)
                {
                    throw new NotFoundException($"没找到id为：{id} 的文章");
                }
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
                throw new ArgumentNullException();
            }
            try
            {
                var article = await _dBContext.Articles.Where(c => c.Id == int.Parse(id)).SingleOrDefaultAsync();
                if(article == null)
                {
                    throw new NotFoundException($"没找到id为：{id} 的文章");
                }
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
                .Include(a=>a.Category)
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
                .Include(a=>a.Category)
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

        public async Task IncViewAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var article = await _dBContext.Articles.Where(a => a.Id == int.Parse(id)).SingleOrDefaultAsync();
            if(article == null)
            {
                throw new NotFoundException($"没找到id为：{id} 的文章");
            }
            article.Read++;
            await _dBContext.SaveChangesAsync();
        }

        public async Task UpdateArticleAsync(ArticleInfoModel article,ArticleContentModel articleContentModel)
        {
            if(article == null || articleContentModel == null)
            {
                throw new ArgumentNullException();
            }
            var ae = ModelEntityHelper.ArticleM2E(article);
            _dBContext.Articles.Update(ae);
            await _dBContext.SaveChangesAsync();
        }
    }
}
