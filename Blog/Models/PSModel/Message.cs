using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.PSModel
{
    /// <summary>
    /// 推送消息操作类型枚举
    /// </summary>
    public enum ArticleOperation
    {
        ADDARTICLE,
        UPDATEARTICLE,
        LIKE,
        COMMENT,
        LIKECOMMENT
    }

    /// <summary>
    /// 推送消息结构定义
    /// </summary>
    public class Message
    {
        public string UserName { get; set; }
        public string Pageid { get; set; }
        public string TargetUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public ArticleOperation ArticleOperation { get; set; }
    }
}
