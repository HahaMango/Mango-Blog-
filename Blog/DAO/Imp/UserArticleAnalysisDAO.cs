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
        public int AddArticleAnalysis(UserArticleAnalysis userArticleAnalysis)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis)
        {
            throw new NotImplementedException();
        }

        public int DeleteArticleAnalysis(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteArticleAnalysisAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public UserArticleAnalysis GetArticleAnalysis(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<UserArticleAnalysis> GetArticleAnalysisAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int IncTotalArticle(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncTotalArticleAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int IncTotalComment(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncTotalCommentAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int IncTotalLike(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncTotalLikeAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int IncTotalOriginal(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncTotalOriginalAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int IncTotalRead(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncTotalReadAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public int UpdateArticleAnalysis(UserArticleAnalysis userArticleAnalysis)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis)
        {
            throw new NotImplementedException();
        }
    }
}
