using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Blog.Models;
using Blog.Models.ArticleModels;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO.Imp
{
    public class UserArticleAnalysisDAO : IUserArticleAnalysisDAO<int>
    {

        private readonly ArticleContext _articleContext = null;

        public UserArticleAnalysisDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddArticleAnalysis(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                _articleContext.UserArticleAnalyses.Add(userArticleAnalysis);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                _articleContext.UserArticleAnalyses.Add(userArticleAnalysis);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public int DeleteArticleAnalysis(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                UserArticleAnalysis temp = _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userArticleAnalysis.UserId)
                    .Single();

                _articleContext.UserArticleAnalyses.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                UserArticleAnalysis temp = _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userArticleAnalysis.UserId)
                    .Single();

                _articleContext.UserArticleAnalyses.Remove(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public UserArticleAnalysis GetArticleAnalysis(int userid)
        {
            try
            {
                return _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userid)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserArticleAnalysis> GetArticleAnalysisAsync(int userid)
        {
            try
            {
                return await _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userid)
                    .SingleOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateArticleAnalysis(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                UserArticleAnalysis temp = _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userArticleAnalysis.UserId)
                    .Single();

                userArticleAnalysis.Id = temp.Id;

                _articleContext.UserArticleAnalyses.Update(userArticleAnalysis);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis)
        {
            try
            {
                UserArticleAnalysis temp = _articleContext.UserArticleAnalyses
                    .Where(uaa => uaa.UserId == userArticleAnalysis.UserId)
                    .Single();

                userArticleAnalysis.Id = temp.Id;

                _articleContext.UserArticleAnalyses.Update(userArticleAnalysis);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
