﻿using System;
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

        public async Task AddArticleAsync(ArticleInfoModel article, ArticleContentModel articleContent)
        {
            if(article == null || articleContent == null || article.Id == null || articleContent.Id == null)
            {
                throw new NullReferenceException();
            }
            if(article.Id != articleContent.Id)
            {
                throw new ApplicationException();
            }
            await _articleDao.AddArticleAsync(article,articleContent);

        }

        public async Task<int> ArticleCountAsync()
        {
            return await _articleDao.ArticleCountAsync();
        }

        public async Task DecIncLikeActionAsync(string id, bool inc)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            await _articleDao.DecIncLikeAsync(id, inc);
        }

        public async Task DeleteArticleAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            await _articleDao.DeleteArticleById(id);
        }

        public async Task<ArticleInfoModel> GetArticleByIdAsync(string id)
        {
            if(id == null)
            {
                throw new NullReferenceException("文章id为空");
            }
            return await _articleDao.GetArticleInfoAsync(id);
        }

        public async Task<ArticleContentModel> GetArticleContentByIdAsync(string id)
        {
            if(id == null)
            {
                throw new NullReferenceException();            
            }
            return await _articleDao.GetArticleContentAsync(id);
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int startCount, int count)
        {
            return await _articleDao.GetArticleInfosAsync(startCount, count);
        }

        public async Task<IList<ArticleInfoModel>> GetArticleInfosAsync()
        {
            return await _articleDao.GetArticleInfosAsync();
        }

        public async Task IncViewActionAsync(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            await _articleDao.IncViewAsync(id);
        }

        public async Task UpdateArticleAsync(ArticleInfoModel article,ArticleContentModel articleContent)
        {
            if(article == null || article.Id == null)
            {
                throw new NullReferenceException();
            }
            await _articleDao.UpdateArticleAsync(article,articleContent);
        }
    }
}
