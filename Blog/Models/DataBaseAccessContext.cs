using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;
using Blog.Models.Users;

namespace Blog.Models
{
    public class DataBaseAccessContext: DbContext
    {
        public DataBaseAccessContext(DbContextOptions<DataBaseAccessContext> contextOptions) : base(contextOptions)
        {

        }

        //user Set
        public DbSet<OAuthUser> OAuthUsers { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserStatistics> UserStatistics { get; set; }

        //article set
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleStatistics> ArticleStatistics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
    }
}
