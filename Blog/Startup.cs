using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Blog.Helper;
using Blog.Service;
using Blog.Models;
using Blog.Service.lmp;
using Blog.DAO;
using Blog.DAO.Imp;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }    

        // 配置需要添加进DI的服务
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddDataAnnotations()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);                   

            //配置API资源
            services.AddAuthentication("Bearer")                
                .AddJwtBearer("Bearer", options =>
                {
                    //授权服务器地址
                    options.Authority = _configuration["IdentityService"];
                    options.RequireHttpsMetadata = false;

                    options.Audience = _configuration["mango.blog"];
                });

            services.AddDbContext<ArticleContext>(op => 
            {
                op.UseLazyLoadingProxies();
                op.UseMySql(_configuration.GetConnectionString("BlogContextConnection"));
            });

            //添加服务到DI容器
            services.AddSingleton<ICategoryService<string>,CategoryService>();
            services.AddSingleton<IArticleBaseService<string, string>,ArticleBaseService>();
            services.AddSingleton<ICommentService<string, string, string>,CommentService>();

            //添加DAO层到DI容器
            services.AddSingleton<IArticleCategoryDAO<int>,ArticleCategoryDAO>();
            services.AddSingleton<IArticleContentDAO<int>, ArticleContentDAO>();
            services.AddSingleton<IUserArticleAnalysisDAO<int>,UserArticleAnalysisDAO>();
            services.AddSingleton<IUserArticleDAO<int,int>,UserArticleDAO>();
            services.AddSingleton<IUserCommentDAO<int,int,int>,UserCommentDAO>();
            services.AddSingleton<DAOTransaction>();

            //添加用户哈希服务
            services.AddSingleton<IHash,HashByRedis>();
        }

        // 配置HTTP管道中间件
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {         
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
