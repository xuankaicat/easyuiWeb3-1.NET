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
                    //��¼·�������ǵ��û���ͼ������Դ��δ���������֤ʱ�����򽫻Ὣ�����ض���������·��
                    o.LoginPath = new PathString("/Account/Login");
                    //��ֹ����·�������û���ͼ������Դʱ����δͨ������Դ���κ���Ȩ���ԣ����󽫱��ض���������·����
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

            app.UseAuthentication();//��֤//�����֤�м��
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
