using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;
using Blog.DAO;
using Blog.Models.ArticleModels;
using Microsoft.Extensions.Logging;

namespace Blog.Service.lmp
{
    /// <summary>
    ///  文章服务，对文章进行增删查改
    ///  （增加和删除文章会更新用户的博客信息记录，例如总文章数，总评论数等）
    /// </summary>
    //查询文章并不会更新文章的阅读数，阅读数和评论数等是通过另一个服务来进行更新。

    public class ArticleBaseService : IArticleBaseService<string, string>
    {
        
        private readonly IUserArticleDAO<int, int> _userArticleDao = null;

        private readonly IArticleContentDAO<int> _articleContentDao = null;

        private readonly IArticleCategoryDAO<int> _articleCategoryDAO = null;

        private readonly IUserArticleAnalysisDAO<int> _userArticleAnalysis = null;

        private readonly DAOTransaction _daoTransaction = null;

        private readonly ILogger _logger = null;

        /// <summary>
        /// 
        /// 以构造函数方式进行依赖注入持久层。
        /// 
        /// </summary>
        public ArticleBaseService(
            IUserArticleDAO<int, int> userArticleDAO,
            IArticleContentDAO<int> articleContentDAO,
            IArticleCategoryDAO<int> articleCategoryDAO,
            IUserArticleAnalysisDAO<int> userArticleAnalysis,
            ILogger<ArticleBaseService> logger,
            DAOTransaction daoTransaction)
        {
            this._userArticleDao = userArticleDAO;
            this._articleContentDao = articleContentDAO;
            this._articleCategoryDAO = articleCategoryDAO;
            this._userArticleAnalysis = userArticleAnalysis;
            this._logger = logger;
            this._daoTransaction = daoTransaction;           
        }

        /// <summary>
        ///     添加文章
        ///     （添加文章简要信息，添加文章内容，更新当前用户文章总数）
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public Resultion AddArticle(string username, ArticleJSON article)
        {
            _logger.LogDebug(nameof(AddArticle)+"添加文章 用户名：{username}",username);

            int articlerow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = (username + "A" + DateTime.Now.ToString()).GetHashCode().ToString();
            Article articlemodel = JMConvert.ArticleJ2M(article);

            ArticleContent articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);

            UserArticleAnalysis userArticleAnalysis = null;

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = _userArticleDao.AddArticle(articlemodel);               
                    contentrow = _articleContentDao.AddContent(articleContentmodel);

                    userArticleAnalysis = _userArticleAnalysis.GetArticleAnalysis(article.UserName.GetHashCode());
                    if (userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = username.GetHashCode(),
                            TotalLike = 0,
                            TotalComment = 0,
                            TotalArticle = 0,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        analysisrow = _userArticleAnalysis.AddArticleAnalysis(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalArticle;
                        if (article.IsOriginal)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = _userArticleAnalysis.UpdateArticleAnalysis(userArticleAnalysis);
                    }

                    _logger.LogDebug("添加文章到数据库，操作条目数目：{articlerow}", articlerow);
                    _logger.LogDebug("添加文章内容到数据库，操作条目数目：{contentrow}", contentrow);
                    _logger.LogDebug("添加用户博客信息记录，操作条目数目：{analysisrow}", analysisrow);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    _logger.LogError(nameof(AddArticle)+"发生异常，异常信息：{e}"+e);               
                    transaction.Rollback();

                    _logger.LogError("执行事务回滚");
                    return resultion;
                }
            }

            resultion.IsSuccess = true;
            resultion.Value = article;
            _logger.LogDebug(nameof(AddArticle) + "添加文章成功 用户名：{username}", username);

            return resultion;
        }

        /// <summary>
        ///     添加文章
        ///     （添加文章简要信息，添加文章内容，更新当前用户文章总数）
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task<Resultion> AddArticleAsync(string username, ArticleJSON article)
        {
            _logger.LogDebug(nameof(AddArticle) + "添加文章 用户名：{username}", username);

            int articlerow = 0;
            int contentrow = 0;
            int analysisrow = 0;

            article.Create_Time = DateTime.Now;
            article.Update_Time = DateTime.Now;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            article.Page_id = (username + "A" + DateTime.Now.ToString()).GetHashCode().ToString();
            Article articlemodel = JMConvert.ArticleJ2M(article);

            ArticleContent articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);

            UserArticleAnalysis userArticleAnalysis = null;

            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = await _userArticleDao.AddArticleAsync(articlemodel);
                    contentrow = await _articleContentDao.AddContentAsync(articleContentmodel);

                    userArticleAnalysis = await _userArticleAnalysis.GetArticleAnalysisAsync(article.UserName.GetHashCode());
                    if (userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = article.UserName.GetHashCode(),
                            TotalLike = 0,
                            TotalComment = 0,
                            TotalArticle = 0,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        analysisrow = await _userArticleAnalysis.AddArticleAnalysisAsync(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalArticle;
                        if (article.IsOriginal)
                            ++userArticleAnalysis.TotalOriginal;
                        analysisrow = await _userArticleAnalysis.UpdateArticleAnalysisAsync(userArticleAnalysis);
                    }

                    _logger.LogDebug("添加文章到数据库，操作条目数目：{articlerow}", articlerow);
                    _logger.LogDebug("添加文章内容到数据库，操作条目数目：{contentrow}", contentrow);
                    _logger.LogDebug("添加用户博客信息记录，操作条目数目：{analysisrow}", analysisrow);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    _logger.LogError(nameof(AddArticle) + "发生异常，异常信息：{e}" + e);
                    transaction.Rollback();

                    _logger.LogError("执行事务回滚");
                    return resultion;
                }
            }

            resultion.IsSuccess = true;
            resultion.Value = article;
            _logger.LogDebug(nameof(AddArticle) + "添加文章成功 用户名：{username}", username);

            return resultion;
        }

        /// <summary>
        /// 
        ///     删除文章
        ///     （删除文章简要信息，删除文章内容，更新用户文章总数）
        ///     同步方法
        ///     
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public Resultion DeleteArticle(string username, ArticleJSON article)
        {
            _logger.LogDebug(nameof(DeleteArticle)+"删除文章 用户名：{username}",username);

            int articlerow = 0;
            int contentrow = 0;
            int analysisrow = 0;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            Article articlemodel = JMConvert.ArticleJ2M(article);

            ArticleContent articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);
            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = _userArticleDao.DeleteArticle(articlemodel);
                    contentrow = _articleContentDao.DeleteContent(articleContentmodel);
                    UserArticleAnalysis userArticleAnalysis = _userArticleAnalysis.GetArticleAnalysis(username.GetHashCode());
                    --userArticleAnalysis.TotalArticle;
                    analysisrow = _userArticleAnalysis.UpdateArticleAnalysis(userArticleAnalysis);

                    _logger.LogDebug("删除文章，操作条目数目：{articlerow}", articlerow);
                    _logger.LogDebug("删除文章内容，操作条目数目：{articlerow}", contentrow);
                    _logger.LogDebug("更新用户博客信息记录，操作条目数目：{analysisrow}", analysisrow);

                    transaction.Commit();
                } catch (Exception e)
                {
                    _logger.LogError(nameof(AddArticle) + "发生异常，异常信息：{e}" + e);
                    transaction.Rollback();

                    _logger.LogError("执行事务回滚");
                    return resultion;
                }
            }
            resultion.IsSuccess = true;
            _logger.LogDebug(nameof(DeleteArticle) + "成功删除文章 用户名：{username}", username);

            return resultion;
        }

        /// <summary>
        /// 
        ///     删除文章
        ///     （删除文章简要信息，删除文章内容，更新用户文章总数）
        ///     异步方法
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task<Resultion> DeleteArticleAsync(string username, ArticleJSON article)
        {
            int articlerow = 0;
            int contentrow = 0;
            int analysisrow = 0;
            article.UserName = (article.UserName == null) ? username : article.UserName;
            Article articlemodel = JMConvert.ArticleJ2M(article);

            ArticleContent articleContentmodel = JMConvert.ArticleContentJ2M(article.PageContent);
            Resultion resultion = new Resultion(false, "", null);

            using (var transaction = _daoTransaction.BeginTransaction())
            {
                try
                {
                    articlerow = await _userArticleDao.DeleteArticleAsync(articlemodel);
                    contentrow = await _articleContentDao.DeleteContentAsync(articleContentmodel);
                    UserArticleAnalysis userArticleAnalysis = await _userArticleAnalysis.GetArticleAnalysisAsync(username.GetHashCode());
                    --userArticleAnalysis.TotalArticle;
                    analysisrow = await _userArticleAnalysis.UpdateArticleAnalysisAsync(userArticleAnalysis);

                    Console.WriteLine("article操作行数：" + articlerow);
                    Console.WriteLine("content操作行数：" + contentrow);
                    Console.WriteLine("analysis操作行数：" + analysisrow);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Server ERROR:" + e);
                    Console.WriteLine("执行回滚动作...");
                    transaction.Rollback();

                    return resultion;
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
        public ArticleJSON GetArticleDetail(string username, string articleId)
        {
            Article article = null;
            ArticleContent articleContent = null;

            ArticleJSON articleJSON = null;
            ArticleContentJSON articleContentJSON = null;
            try
            {
                article = _userArticleDao.GetArticleById(username.GetHashCode(), int.Parse(articleId));

                articleContent = _articleContentDao.GetArticleContent(int.Parse(articleId));
            }
            catch
            {
                return null;
            }

            if (article == null || articleContent == null)
            {
                return null;
            }

            articleJSON = JMConvert.ArticleM2J(article);
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
        public async Task<ArticleJSON> GetArticleDetailAsync(string username, string articleId)
        {
            Article article = null;
            ArticleContent articleContent = null;

            ArticleJSON articleJSON = null;
            ArticleContentJSON articleContentJSON = null;
            try
            {
                article = await _userArticleDao.GetArticleByIdAsync(username.GetHashCode(), int.Parse(articleId));

                articleContent = await _articleContentDao.GetArticleContentAsync(int.Parse(articleId));
            }
            catch
            {
                return null;
            }

            if (article == null || articleContent == null)
            {
                return null;
            }

            articleJSON = JMConvert.ArticleM2J(article);
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
        public ArticleJSON GetArticleInfo(string username, string articleId)
        {
            Article article = null;

            ArticleJSON articleJSON = null;
            try
            {
                article =  _userArticleDao.GetArticleById(username.GetHashCode(), int.Parse(articleId));
            }
            catch
            {
                return null;
            }

            if (article == null)
            {
                return null;
            }
            articleJSON = JMConvert.ArticleM2J(article);

            return articleJSON;
        }

        /// <summary>
        ///     获取一篇文章的简要信息
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public async Task<ArticleJSON> GetArticleInfoAsync(string username, string articleId)
        {
            Article article = null;

            ArticleJSON articleJSON = null;
            try
            {
                article = await _userArticleDao.GetArticleByIdAsync(username.GetHashCode(), int.Parse(articleId));
            }
            catch
            {
                return null;
            }

            if (article == null)
            {
                return null;
            }
            articleJSON = JMConvert.ArticleM2J(article);

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
        public List<ArticleJSON> GetArticles(string username,int page,int count)
        {
            List<ArticleJSON> articleJSONs = null;
            List<Article> articles = null;
            try
            {
                articles = _userArticleDao.GetArticlesById(username.GetHashCode(), page, count);
            }
            catch
            {
                return null;
            }
            if(articles!=null&&articles.Count > 0)
            {
                articleJSONs = new List<ArticleJSON>();
                foreach(Article article in articles)
                {
                    var temp = JMConvert.ArticleM2J(article);
                    articleJSONs.Add(temp);
                }
            }
            return articleJSONs;
        }

        public Task<List<ArticleJSON>> GetArticlesAsync(string username,int page,int count)
        {
            throw new NotImplementedException();
        }

        public List<ArticleJSON> GetArticleSortByRead(string username,int page,int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleJSON>> GetArticleSortByReadAsync(string username,int page,int count)
        {
            throw new NotImplementedException();
        }

        public List<ArticleJSON> GetArticlesWithPara(string username, SearchArgument searchPara,int page,int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleJSON>> GetArticlesWithParaAsync(string username, SearchArgument searchPara,int page,int count)
        {
            throw new NotImplementedException();
        }

        public ArticleJSON GetArticleWithContent(string username, string articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleJSON> GetArticleWithContentAsync(string username, string articleId)
        {
            throw new NotImplementedException();
        }

        public ArticleContentJSON GetContent(string username, string articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleContentJSON> GetContentAsync(string username, string articleId)
        {
            throw new NotImplementedException();
        }

        public Resultion UpdateArticle(string username, ArticleJSON article)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> UpdateArticleAsync(string username, ArticleJSON article)
        {
            throw new NotImplementedException();
        }
    }
}
