using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Blog.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.DAO.Imp
{
    public class UserArticleDAO : IUserArticleDAO<int, int>
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
                    .SingleOrDefault();

                temp.UpdateTime = article.UpdateTime;
                temp.Title = article.Title;
                temp.Author = article.Author;
                temp.Description = article.Description;
                temp.Categories = article.Categories;
                temp.Like = article.Like;
                temp.Reads = article.Reads;
                temp.Comments = article.Comments;
                temp.WordCount = article.WordCount;
                temp.IsOriginal = article.IsOriginal;

                _articleContext.Articles.Update(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int CountComments(int userid)
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

        public int CountLike(int userid)
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

        public int CountRead(int userid)
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
                    .SingleOrDefault<Article>();
                _articleContext.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }        
        }

        public Article GetArticleById(int userid, int articleid)
        {
            try
            {
                return _articleContext.Articles
                    .SingleOrDefault(a => (a.UserId == userid) && (a.PageId == articleid));
            }
            catch
            {
                throw;
            }
        }

        #region 根据用户id进行查询和分页

        public List<Article> GetArticlesById(int userid)
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

        public List<Article> GetArticlesById(int userid, int page, int count)
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

        public List<Article> GetOriginal(int userid)
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

        public List<Article> GetArticlesByOriginal(int userid, int page, int count)
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

        public List<Article> GetArticlesSortByComments(int userid, int page, int count)
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

        public List<Article> GetArticlesSortByDate(int userid, int page, int count)
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

        public List<Article> GetArticlesSortByLike(int userid, int page, int count)
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

        public List<Article> GetArticlesSortByRead(int userid, int page, int count)
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

        public List<Article> GetArticlesSortByWord(int userid, int page, int count)
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

        public Article GetMostComments(int userid)
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

        public Article GetMostLike(int userid)
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

        public Article GetMostRead(int userid)
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

        public Article GetMostWord(int userid)
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

        public async Task<Article> GetArticleByIdAsync(int userid, int articleid)
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

        public async Task<List<Article>> GetArticlesByIdAsync(int userid)
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
                    .SingleOrDefault();
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
                    .SingleOrDefault();

                temp.UpdateTime = article.UpdateTime;
                temp.Title = article.Title;
                temp.Author = article.Author;
                temp.Description = article.Description;
                temp.Categories = article.Categories;
                temp.Like = article.Like;
                temp.Reads = article.Reads;
                temp.Comments = article.Comments;
                temp.WordCount = article.WordCount;
                temp.IsOriginal = article.IsOriginal;

                _articleContext.Articles.Update(temp);

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

        public async Task<Article> GetMostLikeAsync(int userid)
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

        public async Task<Article> GetMostReadAsync(int userid)
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

        public async Task<Article> GetMostWordAsync(int userid)
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

        public async Task<Article> GetMostCommentsAsync(int userid)
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

        public async Task<int> CountLikeAsync(int userid)
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

        public async Task<int> CountReadAsync(int userid)
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

        public async Task<int> CountCommentsAsync(int userid)
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

        public async Task<List<Article>> GetOriginalAsync(int userid)
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

        public async Task<List<Article>> GetArticlesSortByDateAsync(int userid, int page, int count)
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

        public async Task<List<Article>> GetArticlesSortByReadAsync(int userid, int page, int count)
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

        public async Task<List<Article>> GetArticlesSortByLikeAsync(int userid, int page, int count)
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

        public async Task<List<Article>> GetArticlesSortByWordAsync(int userid, int page, int count)
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

        public async Task<List<Article>> GetArticlesSortByCommentsAsync(int userid, int page, int count)
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

        public async Task<List<Article>> GetArticlesByOriginalAsync(int userid, int page, int count)
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

        public List<Article> GetArticlesBySearch(int userid, SearchArgument searchArgument)
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
                q = q.Where(a => MatchCategories(a.Categories, searchArgument.Categories));
            }

            return q.ToList();
        }

        public List<Article> GetArticlesBySearch(int userid, SearchArgument searchArgument, int page, int count)
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
                q = q.Where(a => MatchCategories(a.Categories, searchArgument.Categories));
            }

            return q.ToList()
                .Skip(page)
                .Take(count)
                .ToList();
        }

        public async Task<List<Article>> GetArticlesBySearchAsync(int userid, SearchArgument searchArgument)
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
                q = q.Where(a => MatchCategories(a.Categories, searchArgument.Categories));
            }

            return await q.ToListAsync();
        }

        public async Task<List<Article>> GetArticlesBySearchAsync(int userid, SearchArgument searchArgument, int page, int count)
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
                q = q.Where(a => MatchCategories(a.Categories, searchArgument.Categories));
            }

            return await q.Skip(page)
                .Take(count)
                .ToListAsync();
        }


        //私有方法，筛选分类字段。
        private bool MatchCategories(string source,string[] categories)
        {
            bool flag = false;
            foreach(string s in categories)
            {
                flag = flag || source.Contains(s);
            }
            return flag;
        }

        public async Task<List<Article>> GetArticlesByIdAsync(int userid, int page, int count)
        {
            try
            {
                return await _articleContext.Articles
                    .Where(a => a.UserId == userid)
                    .Skip(page)
                    .Take(count)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
