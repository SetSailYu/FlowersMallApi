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

        // ����ע��ע��  �������� ����������Ϣ��
        //     IConfiguration ���ýӿ�
        private readonly IConfiguration _configuration;
        //     CORS ��������ӿ���������
        private readonly string MyAllowSpecificOrigins = "MyPolicy";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region ����
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        //builder.WithOrigins("https://localhost:44390", "http://0.0.0.0:3201").AllowAnyHeader();
                        //builder.WithOrigins(urls) // ������վ���������
                        //builder.WithOrigins("http://localhost:8081", "http://192.168.1.105:8081", "http://localhost:50607")
                        builder.WithOrigins("http://localhost:8081", "http://192.168.1.105:8081", "http://localhost:50607")
                                //.AllowAnyOrigin() // ��������վ���������net core2.2�汾�󽫲����ã�
                                .SetIsOriginAllowed(t => true) // ��������վ���������
                                .AllowAnyMethod() // �����������󷽷�
                                .AllowAnyHeader() // ������������ͷ
                                .AllowCredentials(); // ����Cookie��Ϣ
                    });
            });
            services.AddControllers();
            #endregion ����

            // ʹ��Dbcontext���ݿ����ӳ��������ݿ⣨����ע�룩
            //services.AddDbContextPool<AppDbContext>(
            //    options => options.UseSqlServer(_configuration.GetConnectionString("FlowerShopDBConnection"))
            //    );
            services.AddDbContext<Flower_ShopContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("FlowerShopDBConnection"))
                );

            /**
             *  A ����Endpoint��·���߼���.NET Core 3.x �°汾�ٷ��Ƽ�ʹ��MVC��ܷ���
             */
            services.AddControllersWithViews().AddXmlSerializerFormatters();
            //.AddXmlSerializerFormatters()��������������л�Ϊxml��ʽ

            /***
             *      ��������               ͬһ��Http����ķ�Χ��          �������ͬHttp����
             *    Scoped Service                ͬһ��ʵ��                       ��ʵ��
             *    Transient Service             ��ʵ��                           ��ʵ��
             *    Singleton Service             ͬһ��ʵ��                       ͬһ��ʵ��
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

            // ��Ӿ�̬�ļ��м�������������޷�����wwwroot�µ��ļ���
            app.UseStaticFiles();

            #region ����
            app.UseCors(MyAllowSpecificOrigins);
            #endregion

            // �����������·�ɾ���������ܵ��﷢����λ�ã�Ҳ�����������ѡ��˵�
            app.UseRouting();

            // �����֤�м��
            app.UseAuthorization();

            // �����������ѡ��õĶ˵�������ܵ���ʲô�ط���ִ��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
