using Microsoft.EntityFrameworkCore;

namespace MangoBlog.Entity
{
    public class MangoBlogDBContext : DbContext
    {
        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<ArticleContentEnttiy> ArticleContents { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
