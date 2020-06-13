using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using FlowersMallApi.Models;

namespace FlowersMallApi
{
    public class Startup
    {

        // 依赖注入注册  （可用于 访问配置信息）
        //     IConfiguration 配置接口
        private readonly IConfiguration _configuration;
        //     CORS 跨域请求接口名称设置
        private readonly string MyAllowSpecificOrigins = "MyPolicy";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region 跨域
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        //builder.WithOrigins("https://localhost:44390", "http://0.0.0.0:3201").AllowAnyHeader();
                        //builder.WithOrigins(urls) // 允许部分站点跨域请求
                        //builder.WithOrigins("http://localhost:8081", "http://192.168.1.105:8081", "http://localhost:50607")
                        builder.WithOrigins("http://localhost:8081", "http://192.168.1.105:8081", "http://localhost:50607")
                                //.AllowAnyOrigin() // 允许所有站点跨域请求（net core2.2版本后将不适用）
                                .SetIsOriginAllowed(t => true) // 允许所有站点跨域请求
                                .AllowAnyMethod() // 允许所有请求方法
                                .AllowAnyHeader() // 允许所有请求头
                                .AllowCredentials(); // 允许Cookie信息
                    });
            });
            services.AddControllers();
            #endregion 跨域

            // 使用Dbcontext数据库连接池连接数据库（依赖注入）
            //services.AddDbContextPool<AppDbContext>(
            //    options => options.UseSqlServer(_configuration.GetConnectionString("FlowerShopDBConnection"))
            //    );
            services.AddDbContext<Flower_ShopContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("FlowerShopDBConnection"))
                );

            /**
             *  A 基于Endpoint的路由逻辑，.NET Core 3.x 新版本官方推荐使用MVC框架方法
             */
            services.AddControllersWithViews().AddXmlSerializerFormatters();
            //.AddXmlSerializerFormatters()将请求的数据序列化为xml格式

            /***
             *      服务类型               同一个Http请求的范围内          横跨多个不同Http请求
             *    Scoped Service                同一个实例                       新实列
             *    Transient Service             新实列                           新实列
             *    Singleton Service             同一个实列                       同一个实列
             * 
             */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/Error");
            }

            // 添加静态文件中间件（少了它将无法访问wwwroot下的文件）
            app.UseStaticFiles();

            #region 跨域
            app.UseCors(MyAllowSpecificOrigins);
            #endregion

            // 它是用来标记路由决策在请求管道里发生的位置，也就是在这里会选择端点
            app.UseRouting();

            // 身份验证中间件
            app.UseAuthorization();

            // 它是用来标记选择好的端点在请求管道的什么地方来执行
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
