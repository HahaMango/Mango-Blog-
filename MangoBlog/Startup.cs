using MangoBlog.Entity;
using MangoBlog.Entity.Imp;
using MangoBlog.Service;
using MangoBlog.Service.Imp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Security.Claims;

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
            services.AddDbContext<MangoBlogDBContext>(options => options.UseMySql(Configuration.GetConnectionString("BloggingDatabase")));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                //options.KnownProxies.Add(IPAddress.Parse("192.168.99.100"));
            });

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

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                 {
                     config.Authority = Configuration["AuthorityServer"];
                     config.RequireHttpsMetadata = false;

                     config.Audience = "mangoblogApi";

                     config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                     {
                         NameClaimType = "name",
                         RoleClaimType = ClaimTypes.Role
                     };
                 });

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleDao, ArticleDao>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentDao, CommentDao>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDao, CategoryDao>();

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseCors("all");
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
