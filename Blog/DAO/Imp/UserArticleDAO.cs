using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Blog.Helper;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO.Imp
{
    public class UserArticleDAO : IUserArticleDao<string, string>
    {

        private readonly ArticleContext _articleContext = null;

        public UserArticleDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddArticle(Article article)
        {
            try
            {
                _articleContext.Articles.Add(article);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateArticle(Article article)
        {
            try
            {
                Article temp = _articleContext.Articles
                    .Where(a => a.PageId == article.PageId)
                    .Single();

                Article article1 = new Article();
                article1.Id = temp.Id;
                article1.PageId = article.PageId;
                article1.UserId = article.UserId;
                article1.CreateTime = article.CreateTime;
                article1.UpdateTime = article.UpdateTime;
                article1.Title = article.Title;
                article1.Author = article.Author;
                article1.Description = article.Description;
                article1.Categories = article.Categories;
                article1.Like = article.Like;
                article1.Reads = article.Reads;
                article1.Comments = article.Comments;
                article1.WordCount = article.WordCount;
                article1.IsOriginal = article.IsOriginal;

                _articleContext.Articles.Update(article1);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int CountComments(string userid)
        {
            try
            {
                return GetMostComments(userid).Comments;
            }
            catch
            {
                throw;
            }
        }

        public int CountLike(string userid)
        {
            try
            {
                return GetMostLike(userid).Like;
            }
            catch
            {
                throw;
            }
        }

        public int CountRead(string userid)
        {
            try
            {
                return GetMostRead(userid).Reads;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteArticle(Article article)
        {
            try
            {
                Article temp = _articleContext.Articles
                    .Where<Article>(a => a.PageId == article.PageId)
                    .First<Article>();
                _articleContext.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }        
        }

        public Article GetArticleById(string userid, string articleid)
        {
            try
            {
                return _articleContext.Articles
                    .Single(a => (a.UserId == userid) && (a.PageId == articleid));
            }
            catch
            {
                throw;
            }
        }

        #region 根据用户id进行查询和分页

        public List<Article> GetArticlesById(string userid)
        {
            try
            {
                List<Article> articles = _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .ToList();
                return articles;
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesById(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region 根据用户id查询原创文章

        public List<Article> GetOriginal(string userid)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid && a.IsOriginal == true)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesByOriginal(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid && a.IsOriginal == true)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region 排序查询和分页

        public List<Article> GetArticlesSortByComments(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Comments)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesSortByDate(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.CreateTime)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesSortByLike(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Like)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesSortByRead(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Reads)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesSortByWord(string userid, int page, int count)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.WordCount)
                    .Skip(page)
                    .Take(count)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region 获取相关参数最大值

        public Article GetMostComments(string userid)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Comments)
                    .First();
            }
            catch
            {
                throw;
            }
        }

        public Article GetMostLike(string userid)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Like)
                    .First();
            }
            catch
            {
                throw;
            }
        }

        public Article GetMostRead(string userid)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Reads)
                    .First();
            }
            catch
            {
                throw;
            }
        }

        public Article GetMostWord(string userid)
        {
            try
            {
                return _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.WordCount)
                    .First();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public async Task<Article> GetArticleByIdAsync(string userid, string articleid)
        {
            try
            {
                return await _articleContext.Articles
                    .SingleAsync(a => (a.UserId == userid) && (a.PageId == articleid));
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesByIdAsync(string userid)
        {
            try
            {
                List<Article> articles = await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .ToListAsync();
                return articles;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteArticleAsync(Article article)
        {
            try
            {
                Article temp = _articleContext.Articles
                    .Where<Article>(a => a.PageId == article.PageId)
                    .First<Article>();
                _articleContext.Remove(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateArticleAsync(Article article)
        {
            try
            {
                Article temp = _articleContext.Articles
                    .Where(a => a.PageId == article.PageId)
                    .Single();

                Article article1 = new Article();
                article1.Id = temp.Id;
                article1.PageId = article.PageId;
                article1.UserId = article.UserId;
                article1.CreateTime = article.CreateTime;
                article1.UpdateTime = article.UpdateTime;
                article1.Title = article.Title;
                article1.Author = article.Author;
                article1.Description = article.Description;
                article1.Categories = article.Categories;
                article1.Like = article.Like;
                article1.Reads = article.Reads;
                article1.Comments = article.Comments;
                article1.WordCount = article.WordCount;
                article1.IsOriginal = article.IsOriginal;

                _articleContext.Articles.Update(article1);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddArticleAsync(Article article)
        {
            try
            {
                _articleContext.Articles.Add(article);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Article> GetMostLikeAsync(string userid)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Like)
                    .FirstAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Article> GetMostReadAsync(string userid)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Reads)
                    .FirstAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Article> GetMostWordAsync(string userid)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.WordCount)
                    .FirstAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Article> GetMostCommentsAsync(string userid)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Comments)
                    .FirstAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CountLikeAsync(string userid)
        {
            try
            {
                return (await GetMostLikeAsync(userid)).Like;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CountReadAsync(string userid)
        { 
            try
            {
                return (await GetMostReadAsync(userid)).Reads;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CountCommentsAsync(string userid)
        {
            try
            {
                return (await GetMostCommentsAsync(userid)).Comments;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetOriginalAsync(string userid)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid && a.IsOriginal == true)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesSortByDateAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.CreateTime)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesSortByReadAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Reads)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesSortByLikeAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Like)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesSortByWordAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.WordCount)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesSortByCommentsAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .OrderByDescending(a => a.Comments)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Article>> GetArticlesByOriginalAsync(string userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid && a.IsOriginal == true)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public List<Article> GetArticlesBySearch(string userid, SearchArgument searchArgument)
        {
            if (searchArgument.IsNull())
                return null;

            IQueryable<Article> q = _articleContext.Articles
                .Where(a => a.UserId == userid);
            if (searchArgument.Author != null)
            {
                q = q.Where(a => a.Author.Contains(searchArgument.Author));
            }
            if (searchArgument.Title != null)
            {
                q = q.Where(a => a.Title == searchArgument.Title);
            }
            if (searchArgument.BeingTime != null)
            {
                q = q.Where(a => a.CreateTime >= searchArgument.BeingTime);
            }
            if (searchArgument.EndTime != null)
            {
                q = q.Where(a => a.CreateTime <= searchArgument.EndTime);
            }
            if(searchArgument.Categories != null)
            {
                foreach(string s in searchArgument.Categories)
                {
                    q = q.Where(a => a.Categories.Contains(s));
                }
            }

            return q.ToList();
        }

        public List<Article> GetArticlesBySearch(string userid, SearchArgument searchArgument, int page, int count)
        {
            if (searchArgument.IsNull())
                return null;

            IQueryable<Article> q = _articleContext.Articles
                .Where(a => a.UserId == userid);
            if (searchArgument.Author != null)
            {
                q = q.Where(a => a.Author.Contains(searchArgument.Author));
            }
            if (searchArgument.Title != null)
            {
                q = q.Where(a => a.Title == searchArgument.Title);
            }
            if (searchArgument.BeingTime != null)
            {
                q = q.Where(a => a.CreateTime >= searchArgument.BeingTime);
            }
            if (searchArgument.EndTime != null)
            {
                q = q.Where(a => a.CreateTime <= searchArgument.EndTime);
            }
            if (searchArgument.Categories != null)
            {
                foreach (string s in searchArgument.Categories)
                {
                    q = q.Where(a => a.Categories.Contains(s));
                }
            }

            return q.ToList()
                .Skip(page)
                .Take(count)
                .ToList();
        }

        public async Task<List<Article>> GetArticlesBySearchAsync(string userid, SearchArgument searchArgument)
        {
            if (searchArgument.IsNull())
                return null;

            IQueryable<Article> q = _articleContext.Articles
                .Where(a => a.UserId == userid);
            if (searchArgument.Author != null)
            {
                q = q.Where(a => a.Author.Contains(searchArgument.Author));
            }
            if (searchArgument.Title != null)
            {
                q = q.Where(a => a.Title == searchArgument.Title);
            }
            if (searchArgument.BeingTime != null)
            {
                q = q.Where(a => a.CreateTime >= searchArgument.BeingTime);
            }
            if (searchArgument.EndTime != null)
            {
                q = q.Where(a => a.CreateTime <= searchArgument.EndTime);
            }
            if (searchArgument.Categories != null)
            {
                foreach (string s in searchArgument.Categories)
                {
                    q = q.Where(a => a.Categories.Contains(s));
                }
            }

            return await q.ToListAsync();
        }

        public async Task<List<Article>> GetArticlesBySearchAsync(string userid, SearchArgument searchArgument, int page, int count)
        {
            if (searchArgument.IsNull())
                return null;

            IQueryable<Article> q = _articleContext.Articles
                .Where(a => a.UserId == userid);
            if (searchArgument.Author != null)
            {
                q = q.Where(a => a.Author.Contains(searchArgument.Author));
            }
            if (searchArgument.Title != null)
            {
                q = q.Where(a => a.Title == searchArgument.Title);
            }
            if (searchArgument.BeingTime != null)
            {
                q = q.Where(a => a.CreateTime >= searchArgument.BeingTime);
            }
            if (searchArgument.EndTime != null)
            {
                q = q.Where(a => a.CreateTime <= searchArgument.EndTime);
            }
            if (searchArgument.Categories != null)
            {
                foreach (string s in searchArgument.Categories)
                {
                    q = q.Where(a => a.Categories.Contains(s));
                }
            }

            return await q.Skip(page)
                .Take(count)
                .ToListAsync();
        }
    }
}
