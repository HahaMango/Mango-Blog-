using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.Models
{
    public class ArticleContext: DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasIndex(a => a.PageId)
                .IsUnique();

            modelBuilder.Entity<Article>()
                .HasIndex(a => new { a.Like, a.Comments, a.Reads, a.CreateTime });

            modelBuilder.Entity<ArticleContent>()
                .HasIndex(a => new {a.PageId})
                .IsUnique();
                

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.CommentId)
                .IsUnique();

            modelBuilder.Entity<UserArticleAnalysis>()
                .HasIndex(c => c.UserId)
                .IsUnique();
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleContent> ArticleContents { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<UserArticleAnalysis> UserArticleAnalyses { get; set; }
    }
}
