using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helper
{
    /// <summary>
    /// 根据用户名返回对应的哈希，该哈希作为用户名对应的用户Id，并且建立数据库索引
    /// </summary>
    public interface IHash
    {
        int GetUserNameHash(string username);

        int GenerateArticleId(string username);

        int GenerateArticleId(string username, string pageid);

        int GenerateCommentId(string username, string pageid);
    }
}
