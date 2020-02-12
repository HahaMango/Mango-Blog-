using Microsoft.EntityFrameworkCore;

namespace MangoBlog.Entity
{
    public class MangoBlogDBContext : DbContext
    {    
        public MangoBlogDBContext(DbContextOptions<MangoBlogDBContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleEntity>()
                .HasMany(ae => ae.Comments)
                .WithOne()
                .HasForeignKey(ce => ce.ArticleId);           
        }

        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<ArticleContentEnttiy> ArticleContents { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
