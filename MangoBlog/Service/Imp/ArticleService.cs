using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;
using MangoBlog.Entity;

namespace MangoBlog.Service.Imp
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleDao _articleDao = null;

        public ArticleService(IArticleDao articleDao)
        {
            _articleDao = articleDao;
        }

        public async Task<int> ArticleCountAsync()
        {
            return await _articleDao.ArticleCountAsync();
        }

        public Task<ArticleContentModel> GetArticleContentAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int startCount, int count)
        {
            return await _articleDao.GetArticleInfosAsync(startCount, count);
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync()
        {
            return await _articleDao.GetArticleInfosAsync();
        }

        public Task<bool> LikeActionAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
