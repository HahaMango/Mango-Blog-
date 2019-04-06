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
        Resultion Add(UserIdType userid,Category category);
        Resultion Replace(UserIdType userid,Category category);
        Resultion Delete(UserIdType userid,Category category);
        List<Category> GetCategories(UserIdType id);
        List<Category> GetCategories(UserIdType id, int count);
        Category GetCategory(UserIdType userid, int id);
    }
}
