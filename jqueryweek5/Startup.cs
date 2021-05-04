using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jqueryweek5.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using jqueryweek5.DataRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace jqueryweek5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IProductRepository, SqlProductRepository>();
            services.AddScoped<ISaleRepository, SqlSaleRepository>();
            services.AddScoped<ISaledetailRepository, SqlSaledetailRepository>();
            services.AddScoped<IAdminRepository, SqlAdminRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    //登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径
                    o.LoginPath = new PathString("/Account/Login");
                    //禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
                    o.AccessDeniedPath = new PathString("/Home/Index");
                });

            //MySql
            string connectionsString = _configuration.GetConnectionString("MySqlConnection");
            services.AddDbContextPool<jquerytestContext>(options =>
                options.UseMySql(connectionsString, MySqlOptions =>
                    MySqlOptions.ServerVersion("8.0.21-mysql")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//认证//身份验证中间件
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
