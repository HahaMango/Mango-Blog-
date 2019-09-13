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
                .HasIndex(a =>  a.CreateTime );

            modelBuilder.Entity<Article>()
                .HasOne(a => a.ArticleStatistic)
                .WithOne(a => a.Article)
                .HasForeignKey<ArticleStatistic>(f => f.PageId)
                .HasPrincipalKey<Article>(u => u.PageId);

            modelBuilder.Entity<ArticleContent>()
                .HasIndex(a => a.PageId)
                .IsUnique();

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.CommentId)
                .IsUnique();

            modelBuilder.Entity<CommandUser>()
                .HasIndex(c => c.CommandId)
                .IsUnique();

            modelBuilder.Entity<CommandPage>()
                .HasIndex(c => c.CommandId)
                .IsUnique();

            modelBuilder.Entity<UserArticleAnalysis>()
                .HasIndex(c => c.UserId)
                .IsUnique();

            modelBuilder.Entity<ArticleStatistic>()
                .HasIndex(a => a.Like);
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleContent> ArticleContents { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommandUser> CommandUsers { get; set; }

        public DbSet<CommandPage> CommandPages { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<UserArticleAnalysis> UserArticleAnalyses { get; set; }

        public DbSet<ArticleStatistic> ArticleStatistics { get; set; }
    }
}
