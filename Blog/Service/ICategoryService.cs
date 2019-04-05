using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.JSONEntity;

namespace Blog.Service
{
    public interface ICategoryService<UserIdType>
    {
        bool Add(UserIdType userid,Category category);
        bool Replace(UserIdType userid,Category category);
        bool Delete(UserIdType userid,Category category);
        List<Category> GetCategories(UserIdType id);
        List<Category> GetCategories(UserIdType id, int count);
        Category GetCategory(UserIdType userid, int id);
    }
}
