using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;
using Blog.DAO;
using Microsoft.Extensions.Logging;
using Blog.Models.ArticleModels;

namespace Blog.Service.lmp
{
    /// <summary>
    /// 评论服务，对评论进行增删查改
    /// (同时需要更新用户博客信息记录)
    /// </summary>
    public class CommentService : ICommentService<string, string, string>
    {
        private readonly IUserCommentDAO<int, int,int> _userCommentDAO = null;

        private readonly IUserArticleAnalysisDAO<int> _userArticleAnalysisDAO = null;

        private readonly DAOTransaction _transcation = null;

        private readonly IHash _hash = null;

        public CommentService(
            IUserCommentDAO<int,int,int> userCommentDAO,
            IUserArticleAnalysisDAO<int> userArticleAnalysisDAO,
            DAOTransaction dAOTransaction,
            IHash hash)
        {
            this._userCommentDAO = userCommentDAO;
            this._userArticleAnalysisDAO = userArticleAnalysisDAO;
            this._transcation = dAOTransaction;
            this._hash = hash;
        }

        /// <summary>
        ///     添加评论到文章
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pageid"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public virtual Resultion AddCommentToArticle(string username, string pageid, CommentJSON comment)
        {

            int commentrow = 0;
            int analysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            Resultion resultion = new Resultion(false, "", null);
            comment.Commend_id = _hash.GenerateCommentId(username, pageid).ToString();
            Comment commentModel = JMConvert.CommentJ2M(comment);
            commentModel.UserId = userid;
            
            using(var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    commentrow = _userCommentDAO.AddComment(commentModel);
                    UserArticleAnalysis userArticleAnalysis = _userArticleAnalysisDAO.GetArticleAnalysis(userid);
                    if(userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = userid,
                            TotalLike = 0,
                            TotalComment = 1,
                            TotalArticle = 0,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        analysisrow = _userArticleAnalysisDAO.AddArticleAnalysis(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalComment;
                        analysisrow = _userArticleAnalysisDAO.UpdateArticleAnalysis(userArticleAnalysis);
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
            resultion.Value = comment;

            return resultion;
        }

        /// <summary>
        ///     添加评论到文章
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pageid"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> AddCommentToArticleAsync(string username, string pageid, CommentJSON comment)
        {

            int commentrow = 0;
            int analysisrow = 0;

            int userid = _hash.GetUserNameHash(username);
            Resultion resultion = new Resultion(false, "", null);
            comment.Commend_id = _hash.GenerateCommentId(username, pageid).ToString();
            Comment commentModel = JMConvert.CommentJ2M(comment);
            commentModel.UserId = userid;            

            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    commentrow = await _userCommentDAO.AddCommentAsync(commentModel);
                    UserArticleAnalysis userArticleAnalysis = await _userArticleAnalysisDAO.GetArticleAnalysisAsync(userid);
                    if (userArticleAnalysis == null)
                    {
                        userArticleAnalysis = new UserArticleAnalysis
                        {
                            UserId = userid,
                            TotalLike = 0,
                            TotalComment = 1,
                            TotalArticle = 0,
                            TotalOriginal = 0,
                            TotalRead = 0
                        };
                        analysisrow = await _userArticleAnalysisDAO.AddArticleAnalysisAsync(userArticleAnalysis);
                    }
                    else
                    {
                        ++userArticleAnalysis.TotalComment;
                        analysisrow = await _userArticleAnalysisDAO.UpdateArticleAnalysisAsync(userArticleAnalysis);
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
            resultion.Value = comment;

            return resultion;
        }

        /// <summary>
        ///     删除评论
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual Resultion DeleteComment(string username, string commentid)
        {
            int commentrow = 0;
            Resultion resultion = new Resultion(false, "", null);
            int cid = int.Parse(commentid);
            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    commentrow = _userCommentDAO.DeleteComment(cid);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }

            return resultion;
        }

        /// <summary>
        ///     删除评论
        ///     异步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> DeleteCommentAsync(string username, string commentid)
        {

            int commentrow = 0;
            Resultion resultion = new Resultion(false, "", null);
            int cid = int.Parse(commentid);
            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    commentrow = await _userCommentDAO.DeleteCommentAsync(cid);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }

            return resultion;
        }

        /// <summary>
        ///     用评论id获取一条评论
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual CommentJSON GetCommentById(string username, string commentid)
        {
            CommentJSON commentJSON = null;
            Comment comment = null;
            int cid = int.Parse(commentid);

            try
            {
                comment = _userCommentDAO.GetCommentById(cid);                
            }catch(Exception e)
            {
                throw e;
            }
            commentJSON = JMConvert.CommentM2J(comment);

            return commentJSON;
        }

        /// <summary>
        ///     用评论id获取一条评论
        ///     异步评论
        /// </summary>
        /// <param name="username"></param>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual async Task<CommentJSON> GetCommentByIdAsync(string username, string commentid)
        {
            CommentJSON commentJSON = null;
            Comment comment = null;
            int cid = int.Parse(commentid);

            try
            {
                comment = await _userCommentDAO.GetCommentByIdAsync(cid);
            }
            catch (Exception e)
            {
                throw e;
            }
            commentJSON = JMConvert.CommentM2J(comment);

            return commentJSON;
        }

        /// <summary>
        ///     获取用户的评论列表
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual List<CommentJSON> GetComments(string username,int page,int count)
        {
            List<CommentJSON> commentJSONs = null;
            List<Comment> comments = null;
            int userid = _hash.GetUserNameHash(username);

            try
            {
                comments = _userCommentDAO.GetCommentsByUserid(userid, page, count);
            }
            catch(Exception e)
            {
                throw e;
            }

            commentJSONs = new List<CommentJSON>();

            foreach (Comment c in comments)
            {
                commentJSONs.Add(JMConvert.CommentM2J(c));
            }

            return commentJSONs;
        }

        /// <summary>
        ///     获取用户的评论列表   
        ///     异步方法
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<List<CommentJSON>> GetCommentsAsync(string username, int page, int count)
        {
            List<CommentJSON> commentJSONs = null;
            List<Comment> comments = null;
            int userid = _hash.GetUserNameHash(username);

            try
            {
                comments = await _userCommentDAO.GetCommentsByUseridAsync(userid, page, count);
            }
            catch (Exception e)
            {
                throw e;
            }

            commentJSONs = new List<CommentJSON>();

            foreach (Comment c in comments)
            {
                commentJSONs.Add(JMConvert.CommentM2J(c));
            }

            return commentJSONs;
        }

        /// <summary>
        ///     获取指定文章的评论，提供分页
        ///     同步方法
        /// </summary>
        /// <param name="articleid"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual List<CommentJSON> GetCommentsByArticle(string articleid, int page, int count)
        {
            List<CommentJSON> commentJSONs = null;
            List<Comment> comments = null;
            int pageid = int.Parse(articleid);

            try
            {
                comments = _userCommentDAO.GetCommentsByArticleId(pageid, page, count);

                commentJSONs = new List<CommentJSON>();
                foreach(Comment c in comments)
                {
                    int replyCommentId;
                    Comment replycomment = null;
                    if (c.IsReply)
                    {
                        replyCommentId = c.ReplyComId;
                        replycomment = comments.Where(com => com.ReplyComId == replyCommentId).FirstOrDefault();
                        if (replycomment == null)
                        {
                            replycomment = _userCommentDAO.GetCommentById(replyCommentId);
                        }
                        CommentJSON commentJSON = JMConvert.CommentM2J(c);
                        CommentJSON replyComment = JMConvert.CommentM2J(replycomment);
                        commentJSON.Reply = replyComment;
                        commentJSONs.Add(commentJSON);
                    }
                    commentJSONs.Add(JMConvert.CommentM2J(c));
                }
            }catch(Exception e)
            {
                throw e;
            }

            return commentJSONs;
        }

        /// <summary>
        ///     获取指定文章的评论，提供分页
        ///     异步方法
        /// </summary>
        /// <param name="articleid"></param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<List<CommentJSON>> GetCommentsByArticleAsync(string articleid, int page, int count)
        {
            List<CommentJSON> commentJSONs = null;
            List<Comment> comments = null;
            int pageid = int.Parse(articleid);

            try
            {
                comments = await _userCommentDAO.GetCommentsByArticleIdAsync(pageid, page, count);

                commentJSONs = new List<CommentJSON>();
                foreach (Comment c in comments)
                {
                    int replyCommentId;
                    Comment replycomment = null;
                    if (c.IsReply)
                    {
                        replyCommentId = c.ReplyComId;
                        replycomment = comments.Where(com => com.ReplyComId == replyCommentId).FirstOrDefault();
                        if (replycomment == null)
                        {
                            replycomment = await _userCommentDAO.GetCommentByIdAsync(replyCommentId);
                        }
                        CommentJSON commentJSON = JMConvert.CommentM2J(c);
                        CommentJSON replyComment = JMConvert.CommentM2J(replycomment);
                        commentJSON.Reply = replyComment;
                        commentJSONs.Add(commentJSON);
                    }
                    commentJSONs.Add(JMConvert.CommentM2J(c));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return commentJSONs;
        }

        /// <summary>
        ///     点赞评论
        ///     同步方法
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual Resultion LikeComment(string commentid)
        {
            int cid = int.Parse(commentid);

            Resultion resultion = new Resultion(false, null, null);

            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    _userCommentDAO.IncLike(cid);

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
        ///     点赞评论
        ///     异步方法
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> LikeCommentAsync(string commentid)
        {
            int cid = int.Parse(commentid);

            Resultion resultion = new Resultion(false, null, null);

            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    await _userCommentDAO.IncLikeAsync(cid);

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
        ///     更新某条评论
        ///     同步方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="commentid"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public virtual Resultion UpdateComment(string username, string commentid, CommentJSON comment)
        {
            int cid = int.Parse(commentid);
            int userid = _hash.GetUserNameHash(username);
            Comment commentmodle = JMConvert.CommentJ2M(comment);
            commentmodle.UserId = userid;

            Resultion resultion = new Resultion(false, null, null);

            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    _userCommentDAO.UpdateComment(commentmodle);

                    transaction.Commit();
                } catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }
            resultion.IsSuccess = true;
            resultion.Value = comment;

            return resultion;
        }

        /// <summary>
        ///     更新某条评论
        ///     异步方法
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="commentid"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public virtual async Task<Resultion> UpdateCommentAsync(string username, string commentid, CommentJSON comment)
        {
            int cid = int.Parse(commentid);
            int userid = _hash.GetUserNameHash(username);
            Comment commentmodle = JMConvert.CommentJ2M(comment);
            commentmodle.UserId = userid;

            Resultion resultion = new Resultion(false, null, null);

            using (var transaction = _transcation.BeginTransaction())
            {
                try
                {
                    await _userCommentDAO.UpdateCommentAsync(commentmodle);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }
            resultion.IsSuccess = true;
            resultion.Value = comment;

            return resultion;
        }
    }
}
