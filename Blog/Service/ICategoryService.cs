using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.JSONEntity;
using Blog.Helper;

namespace Blog.Service
{
    public interface ICategoryService<UserIdType>
    {
        Resultion Add(UserIdType userid,Category_JSON category);
        Resultion Replace(UserIdType userid,Category_JSON category);
        Resultion Delete(UserIdType userid,Category_JSON category);
        List<Category_JSON> GetCategories(UserIdType id);
        List<Category_JSON> GetCategories(UserIdType id, int count);
        Category_JSON GetCategory(UserIdType userid, int id);
    }
}
