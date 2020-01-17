using MangoBlog.Entity;
using MangoBlog.Entity.Imp;
using MangoBlog.Service;
using MangoBlog.Service.Imp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangoBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MangoBlogDBContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("BloggingDatabase")));

            services.AddCors(config =>
            {
                config.AddPolicy("all", p =>
                {
                    p.SetIsOriginAllowed(op => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleDao, ArticleDao>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentDao, CommentDao>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDao, CategoryDao>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("all");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
