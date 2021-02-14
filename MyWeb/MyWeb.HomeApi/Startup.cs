using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeApi
{
    //coreMvc�� �ణ�� ���̴� ������. coreMvc startup.cs ������ ������ �ᵵ �����ϰ� ��� �ȴ�
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
            //Webapi������ AddControllers
            //CoreMvc����  AddControllersWithViews()���� �Ǿ��ִ� ���̰� �ִ�.
            services.AddControllers();

            //CORS�� �����غ���.
            //���񽺿� �߰��ϸ� Configure���� ����� ����� �Ѵ�.
            services.AddCors((options) => {
                options.AddDefaultPolicy((policy) =>
                {
                    //��ü ����ϱ�
                    //policy.AllowAnyOrigin();

                    policy.AllowAnyMethod();
                    //�Ϻ� ����ϱ�
                    policy.WithOrigins("https://localhost:5001");                
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //default�� �߰������� �״�� ����ȴ�.
            app.UseCors();

            //default�� �ƴ϶�� policyName �־������
            //app.UseCors("policyName");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //coreMvc���� MapControllerRoute()�޼����̴�.
                endpoints.MapControllers();
            });
        }
    }
}
