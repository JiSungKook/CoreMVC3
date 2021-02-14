using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWeb.HomeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb
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
            //System.Text.Json ���� �ʰ� -> Newtonsoft.JsonConverter �� ����ʹٰ� ������.
            //������ ���� ���������� �ξ� �����Ӱ� ����� �ſ� ���ؼ� ������ ���� ����Ѵ�. 
            //�ھ� 3.0���� ����ũ�� ����Ʈ���� ������ ���̱����� System.Text.Json �̰� ����ϴ���.
            //3.0���ϴ� Newtonsoft.JsonConverter �� ����.
            //��ġ����� ���ٿ��� Microsoft.AspNetcore.MVC.NEwtonsoftJson�� ��ġ����
            //��ġ�ϸ� services.AddControllersWithViews(); �ش� �Լ��� AddNewtonsoftJson��� Ȯ��޼��尡 �����.

            //����
            // services.AddControllersWithViews();

            //ī�����̽� �ɼ� ������ ���� option => {option.serializerSettings.ContractResolver = null;}

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = null;
            });


            //���⿡�� ��Ű������ �ϰڴٴ°� �����ؾ� �Ѵ�.

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                //�α����� �� �������� �α��� �������� �����.
                options.LoginPath = "/login";

                options.EventsType = typeof(CustomCookieAuthenticationEvents);

            });

            //���� �۾��� ���������� customcookie...�� ȣ���Ѵ�.
            services.AddScoped<CustomCookieAuthenticationEvents>();
        }

        //�� ��ü�� ���� �߰��ϰ� ���� ������ �ִٸ� Configure
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //exceptionPage�� ���� �Ҷ���.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //�Խ�(release)�� �ϰԵǸ�
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //http�κ��� https�� ���Բ� ���ִ� �Լ�
            app.UseHttpsRedirection();

            // �⺻������ 200��� �ϴ� �������ϵ��� �������ְڴٶ�� �ǹ�. wwwroot�� �ִ� css, js, lib ���
            app.UseStaticFiles();

            // ��Ʈ���� ���� ������� �ϰڴ�.
            app.UseRouting();
            
            // �α��� ������ ����ϰڴ�.
            app.UseAuthentication();

            // ������ ���ڴٶ�� �ǹ�
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                //��Ʈ�ѷ��� ������ Ȩ��Ʈ�ѷ�(Ŭ����)�� �⺻���� ����, �׼��� ������ �⺻���� �ε��� �޼��尡 ���ٴ� �ǹ�
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
