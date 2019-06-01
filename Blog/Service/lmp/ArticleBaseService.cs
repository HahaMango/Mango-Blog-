using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;
using Blog.DAO;
using Blog.Models.ArticleModels;
using Microsoft.Extensions.Logging;
using Blog.MQ;
using Blog.Models.PSModel;

namespace Blog.Service.lmp
{
    /// <summary>
    ///  文章服务，对文章进行增删查改
    ///  （增加和删除文章会更新用户的博客信息记录，例如总文章数，总评论数等）
    /// </summary>
    
    //更新备注：在获取文章内容的同时更新阅读数。
    public class ArticleBaseService : IArticleBaseService<string, string>
    {
        
        private readonly IUserArticleDAO<int, int> _userArticleDao = null;

        private readonly IArticleStatisticDAO<int> _articleStatisticDAO = null;

        private readonly IArticleContentDAO<int> _articleContentDao = null;

        private readonly IArticleCategoryDAO<int> _articleCategoryDAO = null;

        private readonly IUserArticleAnalysisDAO<int> _userArticleAnalysis = null;

        private readonly DAOTransaction _daoTransaction = null;

        private readonly IHash _hash = null;

        /// <summary>
        /// 
        /// 以构造函数方式进行依赖注入持久层。
        /// 
        /// </summary>
        public ArticleBaseService(
            IUserArticleDAO<int, int> userArticleDAO,
            IArticleStatisticDAO<int> articleStatisticDAO,
            IArticleContentDAO<int> articleContentDAO,
            IArticleCategoryDAO<int> articleCategoryDAO,
            IUserArticleAnalysisDAO<int> userArticleAnalysis,
            IHash hash,
            DAOTransaction daoTransaction)
        {
            this._userArticleDao = userArticleDAO;
            this._articleStatisticDAO = articleStatisticDAO;
            this._articleContentDao = articleContentDAO;
            this._articleCategoryDAO = articleCategoryDAO;
            this._userArticleAnalysis = userArticleAnalysis;
            this._hash = hash;
            this._daoTransaction = daoTransaction;
        }

        /// <summary>
        ///     添加文章
        ///     （添加文章简要信息，添加文章内容，添加文章统计信息，更新当前用户文章总数）
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual Resultion AddArticle(string username, ArticleJSON article)
        {

            int articlerow = 0;
            int statisticrow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            int pageid = _hash.GenerateArticleId(username);

            Article articlemodel;
            ArticleStatistic articleStatistic;
            ArticleContent articleContentmodel;
            UserArticleAnalysis userArticleAnalysis;
            Resultion resultion = new Resultion(false, "", null);

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = pageid.ToString();
            articlemodel = JMConvert.ArticleJ2M(article);
            articlemodel.UserId = userid;

            articleStatistic = new ArticleStatistic();
            articleStatistic.PageId = pageid;
            
            articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);
            
            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = _userArticleDao.AddArticle(articlemodel);
                    statisticrow = _articleStatisticDAO.AddArticleStatistic(articleStatistic);
                    contentrow = _articleContentDao.AddContent(articleContentmodel);

                    userArticleAnalysis = _userArticleAnalysis.GetArticleAnalysis(userid);
                    if (userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = userid,
                            TotalLike = 0,
                            TotalComment = 0,
                            TotalArticle = 1,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        if (article.IsOriginal == true)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = _userArticleAnalysis.AddArticleAnalysis(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalArticle;
                        if (article.IsOriginal)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = _userArticleAnalysis.UpdateArticleAnalysis(userArticleAnalysis);
                    }

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }

            resultion.IsSuccess = true;
            resultion.Value = article;

            return resultion;
        }

        /// <summary>
        ///     添加文章
        ///     （添加文章简要信息，添加文章内容，添加文章统计信息，更新当前用户文章总数）
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> AddArticleAsync(string username, ArticleJSON article)
        {

            int articlerow = 0;
            int statisticrow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            int pageid = _hash.GenerateArticleId(username);

            Article articlemodel;
            ArticleStatistic articleStatistic;
            ArticleContent articleContentmodel;
            UserArticleAnalysis userArticleAnalysis;
            Resultion resultion = new Resultion(false, "", null);

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = pageid.ToString();
            articlemodel = JMConvert.ArticleJ2M(article);
            articlemodel.UserId = userid;

            articleStatistic = new ArticleStatistic();
            articleStatistic.PageId = pageid;

            articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = await _userArticleDao.AddArticleAsync(articlemodel);
                    statisticrow = await _articleStatisticDAO.AddArticleStatisticAsync(articleStatistic);
                    contentrow = await _articleContentDao.AddContentAsync(articleContentmodel);

                    userArticleAnalysis = await _userArticleAnalysis.GetArticleAnalysisAsync(userid);
                    if (userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = userid,
                            TotalLike = 0,
                            TotalComment = 0,
                            TotalArticle = 0,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        if (article.IsOriginal == true)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = await _userArticleAnalysis.AddArticleAnalysisAsync(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalArticle;
                        if (article.IsOriginal)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = await _userArticleAnalysis.UpdateArticleAnalysisAsync(userArticleAnalysis);
                    }
                
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }

            resultion.IsSuccess = true;
            resultion.Value = article;

            return resultion;
        }

        /// <summary>
        ///     点赞文章操作
        ///     （增加文章点赞数记录，增加文章作者的总点赞数）
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual Resultion AddLike(string username, string articleId)
        {

            int articlestatisticrow = 0;
            int useranalysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlestatisticrow = _articleStatisticDAO.IncLike(pageid);
                    useranalysisrow = _userArticleAnalysis.IncTotalLike(userid);

                    transaction.Commit();
                }
                catch (Exception e)
                {                    
                    transaction.Rollback();
                    throw e;
                }
            }
            resultion.IsSuccess = true;
            return resultion;
        }

        /// <summary>
        ///     点赞文章操作
        ///     （增加文章点赞数记录，增加文章作者的总点赞数）
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> AddLikeAsync(string username, string articleId)
        {

            int articlestatisticrow = 0;
            int useranalysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlestatisticrow = await _articleStatisticDAO.IncLikeAsync(pageid);
                    useranalysisrow = await _userArticleAnalysis.IncTotalLikeAsync(userid);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
            resultion.IsSuccess = true;
            return resultion;
        }

        /// <summary>
        /// 
        ///     删除文章
        ///     （删除文章简要信息，删除文章内容，删除文章统计，更新用户文章总数）
        ///     同步方法
        ///     
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual Resultion DeleteArticle(string username, string articleid)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleid);

            int articlerow = 0;
            int statisticrow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    Article article = _userArticleDao.GetArticleById(userid, pageid);
                    articlerow = _userArticleDao.DeleteArticle(pageid);
                    statisticrow = _articleStatisticDAO.DeleteArticleStatistic(pageid);
                    contentrow = _articleContentDao.DeleteContent(pageid);

                    UserArticleAnalysis userArticleAnalysis = _userArticleAnalysis.GetArticleAnalysis(userid);
                    --userArticleAnalysis.TotalArticle;
                    if (article.IsOriginal)
                    {
                        --userArticleAnalysis.TotalOriginal;
                    }
                    analysisrow = _userArticleAnalysis.UpdateArticleAnalysis(userArticleAnalysis);

                    transaction.Commit();
                } catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
            resultion.IsSuccess = true;

            return resultion;
        }

        /// <summary>
        /// 
        ///     删除文章
        ///     （删除文章简要信息，删除文章内容，删除文章统计，更新用户文章总数）
        ///     异步方法
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> DeleteArticleAsync(string username, string articleid)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleid);

            int articlerow = 0;
            int statisticrow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    Article article = await _userArticleDao.GetArticleByIdAsync(userid, pageid);
                    articlerow = await _userArticleDao.DeleteArticleAsync(pageid);
                    statisticrow = await _articleStatisticDAO.DeleteArticleStatisticAsync(pageid);
                    contentrow = await _articleContentDao.DeleteContentAsync(pageid);

                    UserArticleAnalysis userArticleAnalysis = await _userArticleAnalysis.GetArticleAnalysisAsync(userid);
                    --userArticleAnalysis.TotalArticle;
                    if (article.IsOriginal)
                    {
                        --userArticleAnalysis.TotalOriginal;
                    }
                    analysisrow = await _userArticleAnalysis.UpdateArticleAnalysisAsync(userArticleAnalysis);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }
            resultion.IsSuccess = true;

            return resultion;
        }

        /// <summary>
        ///     获取一篇文章，包括文章内容
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual ArticleJSON GetArticleDetail(string username, string articleId)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Article article = null;
            ArticleStatistic articleStatistic = null;
            ArticleContent articleContent = null;
            ArticleJSON articleJSON = null;
            ArticleContentJSON articleContentJSON = null;
            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    article = _userArticleDao.GetArticleById(userid, pageid);
                    articleStatistic = _articleStatisticDAO.GetArticleStatistic(pageid);
                    articleContent = _articleContentDao.GetArticleContent(pageid);

                    _articleStatisticDAO.IncRead(pageid);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }

            if (article == null || articleContent == null)
            {
                return null;
            }

            articleJSON = JMConvert.ArticleM2J(article,articleStatistic);
            articleContentJSON = JMConvert.ArticleContentM2J(articleContent);
            articleJSON.PageContent = articleContentJSON;

            return articleJSON;
        }

        /// <summary>
        ///     获取一篇文章，包括文章内容
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual async Task<ArticleJSON> GetArticleDetailAsync(string username, string articleId)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Article article = null;
            ArticleContent articleContent = null;
            ArticleStatistic articleStatistic = null;
            ArticleJSON articleJSON = null;
            ArticleContentJSON articleContentJSON = null;

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    article = await _userArticleDao.GetArticleByIdAsync(userid, pageid);
                    articleStatistic = await _articleStatisticDAO.GetArticleStatisticAsync(pageid);
                    articleContent = await _articleContentDao.GetArticleContentAsync(pageid);

                    await _articleStatisticDAO.IncReadAsync(pageid);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }

            if (article == null || articleContent == null)
            {
                return null;
            }

            articleJSON = JMConvert.ArticleM2J(article,articleStatistic);
            articleContentJSON = JMConvert.ArticleContentM2J(articleContent);
            articleJSON.PageContent = articleContentJSON;

            return articleJSON;
        }

        /// <summary>
        ///     获取一篇文章的简要信息
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual ArticleJSON GetArticleInfo(string username, string articleId)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Article article = null;
            ArticleStatistic articleStatistic = null;
            ArticleJSON articleJSON = null;
            try
            {
                article =  _userArticleDao.GetArticleById(userid, int.Parse(articleId));
                articleStatistic = _articleStatisticDAO.GetArticleStatistic(pageid);
            }
            catch(Exception e)
            {
                throw e;
            }

            if (article == null)
            {
                return null;
            }
            articleJSON = JMConvert.ArticleM2J(article,articleStatistic);

            return articleJSON;
        }

        /// <summary>
        ///     获取一篇文章的简要信息
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual async Task<ArticleJSON> GetArticleInfoAsync(string username, string articleId)
        {

            int userid = _hash.GetUserNameHash(username);
            int pageid = int.Parse(articleId);

            Article article = null;
            ArticleStatistic articleStatistic = null;
            ArticleJSON articleJSON = null;
            try
            {
                article = await _userArticleDao.GetArticleByIdAsync(userid, int.Parse(articleId));
                articleStatistic = await _articleStatisticDAO.GetArticleStatisticAsync(pageid);
            }
            catch(Exception e)
            {
                throw e;
            }

            if (article == null)
            {
                return null;
            }
            articleJSON = JMConvert.ArticleM2J(article,articleStatistic);

            return articleJSON;
        }

        /// <summary>
        ///     获取用户的文章列表（不包含文章内容）
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual List<ArticleJSON> GetArticles(string username,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<ArticleJSON> articleJSONs = null;
            List<Article> articles = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;

            try
            {
                articles = _userArticleDao.GetArticlesById(userid, page, count);
            }
            catch(Exception e)
            {
                throw e;
            }

            if(articles!=null&&articles.Count > 0)
            {
                List<int> pageidlist = articles.Select(a => a.PageId).ToList();
                int[] pageids = pageidlist.ToArray();

                try
                {
                    articleStatistics = _articleStatisticDAO.GetArticleStatistics(pageids);
                }
                catch (Exception e)
                {
                    throw e;
                }

                articleJSONs = new List<ArticleJSON>();
                foreach(Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article,articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     获取用户文章列表（不包含文章内容）
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<List<ArticleJSON>> GetArticlesAsync(string username,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<ArticleJSON> articleJSONs = null;
            List<Article> articles = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;

            try
            {
                articles = await _userArticleDao.GetArticlesByIdAsync(userid, page, count);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (articles != null && articles.Count > 0)
            {
                List<int> pageidlist = articles.Select(a => a.PageId).ToList();
                int[] pageids = pageidlist.ToArray();

                try
                {
                    articleStatistics = await _articleStatisticDAO.GetArticleStatisticsAsync(pageids);
                }
                catch (Exception e)
                {
                    throw e;
                }

                articleJSONs = new List<ArticleJSON>();
                foreach (Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article, articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     获取按阅读量排序的文章
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual List<ArticleJSON> GetArticleSortByRead(string username,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<Article> articles = null;            
            List<ArticleJSON> articleJSONs = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;
            try
            {
                articles = _userArticleDao.GetArticlesSortByRead(userid, page, count);
            }catch (Exception e)
            {
                throw e;
            }
            if (articles != null && articles.Count > 0)
            {
                int[] pageids = articles.Select(a => a.PageId).ToArray();
                try
                {
                    articleStatistics = _articleStatisticDAO.GetArticleStatistics(pageids);
                }
                catch(Exception e)
                {
                    throw e;
                }

                articleJSONs = new List<ArticleJSON>();
                foreach (Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article, articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     获取按阅读量排序的文章
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<List<ArticleJSON>> GetArticleSortByReadAsync(string username,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<Article> articles = null;
            List<ArticleJSON> articleJSONs = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;
            try
            {
                articles = await _userArticleDao.GetArticlesSortByReadAsync(userid, page, count);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (articles != null && articles.Count > 0)
            {
                int[] pageids = articles.Select(a => a.PageId).ToArray();
                try
                {
                    articleStatistics = await _articleStatisticDAO.GetArticleStatisticsAsync(pageids);
                }
                catch (Exception e)
                {
                    throw e;
                }

                articleJSONs = new List<ArticleJSON>();
                foreach (Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article, articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     实现高级搜索
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="searchPara"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual List<ArticleJSON> GetArticlesWithPara(string username, SearchArgument searchPara,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<Article> articles = null;
            List<ArticleJSON> articleJSONs = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;

            try
            {
                articles = _userArticleDao.GetArticlesBySearch(userid, searchPara, page, count);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (articles != null && articles.Count > 0)
            {
                int[] pageids = articles.Select(a => a.PageId).ToArray();
                try
                {
                    articleStatistics = _articleStatisticDAO.GetArticleStatistics(pageids);
                }
                catch(Exception e)
                {
                    throw e;
                }
                articleJSONs = new List<ArticleJSON>();
                foreach (Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article, articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     实现高级搜索
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="searchPara"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<List<ArticleJSON>> GetArticlesWithParaAsync(string username, SearchArgument searchPara,int page,int count)
        {

            int userid = _hash.GetUserNameHash(username);

            List<Article> articles = null;
            List<ArticleJSON> articleJSONs = null;
            Dictionary<int, ArticleStatistic> articleStatistics = null;

            try
            {
                articles = await _userArticleDao.GetArticlesBySearchAsync(userid, searchPara, page, count);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (articles != null && articles.Count > 0)
            {
                int[] pageids = articles.Select(a => a.PageId).ToArray();
                try
                {
                    articleStatistics = await _articleStatisticDAO.GetArticleStatisticsAsync(pageids);
                }
                catch (Exception e)
                {
                    throw e;
                }
                articleJSONs = new List<ArticleJSON>();
                foreach (Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article, articleStatistics[article.PageId]);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        /// <summary>
        ///     获取用户文章内容
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual ArticleContentJSON GetContent(string username, string articleId)
        {

            ArticleContent articleContent = null;
            ArticleContentJSON articleContentJSON = null;
            try
            {
                articleContent = _articleContentDao.GetArticleContent(int.Parse(articleId));
            }catch(Exception e)
            {
                throw e;
            }
            if(articleContent != null)
            {
                articleContentJSON = JMConvert.ArticleContentM2J(articleContent);
            }
            return articleContentJSON;
        }

        /// <summary>
        ///     获取用户文章内容
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public virtual async Task<ArticleContentJSON> GetContentAsync(string username, string articleId)
        {

            ArticleContent articleContent = null;
            ArticleContentJSON articleContentJSON = null;
            try
            {
                articleContent = await _articleContentDao.GetArticleContentAsync(int.Parse(articleId));
            }
            catch (Exception e)
            {
                throw e;
            }
            if (articleContent != null)
            {
                articleContentJSON = JMConvert.ArticleContentM2J(articleContent);
            }
            return articleContentJSON;
        }

        /// <summary>
        ///     更新文章和内容
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual Resultion UpdateArticle(string username, ArticleJSON article)
        {

            int userid = _hash.GetUserNameHash(username);

            int articlerow = 0;
            int contentrow = 0;

            Resultion resultion = new Resultion(false, "", null);

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = _hash.GenerateArticleId(username).ToString();
            Article articlemodel = JMConvert.ArticleJ2M(article);
            articlemodel.UserId = userid;

            ArticleContent articleContent = null;
            if(article.PageContent != null)
            {
                articleContent = JMConvert.ArticleContentJ2M(article.PageContent);
            }

            using (var transcation = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = _userArticleDao.UpdateArticle(articlemodel);
                    if(articleContent != null)
                    {
                        contentrow = _articleContentDao.UpdateContent(articleContent);
                    }
                    transcation.Commit();
                }
                catch (Exception e)
                {
                    transcation.Rollback();
                    throw e;
                }
            }
            resultion.IsSuccess = true;
            resultion.Value = article;

            return resultion;
        }

        /// <summary>
        ///     更新文章和内容 
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> UpdateArticleAsync(string username, ArticleJSON article)
        {

            int userid = _hash.GetUserNameHash(username);

            int articlerow = 0;
            int contentrow = 0;

            Resultion resultion = new Resultion(false, "", null);

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = _hash.GenerateArticleId(username).ToString();
            Article articlemodel = JMConvert.ArticleJ2M(article);
            articlemodel.UserId = userid;

            ArticleContent articleContent = null;
            if (article.PageContent != null)
            {
                articleContent = JMConvert.ArticleContentJ2M(article.PageContent);
            }

            using (var transcation = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = await _userArticleDao.UpdateArticleAsync(articlemodel);
                    if (articleContent != null)
                    {
                        contentrow = await _articleContentDao.UpdateContentAsync(articleContent);
                    }
                    transcation.Commit();
                }
                catch (Exception e)
                {
                    transcation.Rollback();
                    throw e;
                }
            }
            resultion.IsSuccess = true;
            resultion.Value = article;

            return resultion;
        }
    }
}
