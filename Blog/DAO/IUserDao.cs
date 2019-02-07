using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.Users;

namespace Blog.DAO
{
    interface IUserDao
    {
        //
        IList<User> GetUserById(int[] userId);

        User GetUserByName(string userName);

        User GetUser(User user);

        Role GetRoleById(User user);

        //该id为主动方id
        Relation GetRelation(User user);

        UserInfo GetUserInfo(User user);

        UserStatistics GetUserStatistics(User user);

        OAuthUser GetOAuthUser(User user);

        int AddUser(User user);

        int UpdateUser(User user);

        int DeleteUser(User user);


    }
}
