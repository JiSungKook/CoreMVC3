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
            //System.Text.Json 쓰지 않고 -> Newtonsoft.JsonConverter 를 쓰고싶다고 정하자.
            //성능은 조금 떨어지지만 훨씬 자유롭고 사용이 매우 편리해서 이쪽을 많이 사용한다. 
            //코어 3.0부턴 마이크로 소프트에서 성능을 높이기위해 System.Text.Json 이걸 사용하더라.
            //3.0이하는 Newtonsoft.JsonConverter 를 쓴다.
            //설치방법은 누겟에서 Microsoft.AspNetcore.MVC.NEwtonsoftJson을 설치하자
            //설치하면 services.AddControllersWithViews(); 해당 함수에 AddNewtonsoftJson라는 확장메서드가 생긴다.

            //기존
            // services.AddControllersWithViews();

            //카멜케이스 옵션 강제로 끄기 option => {option.serializerSettings.ContractResolver = null;}

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = null;
            });


            //여기에도 쿠키인증을 하겠다는걸 지정해야 한다.

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                //로그인이 안 돼있으면 로그인 페이지로 가즈아.
                options.LoginPath = "/login";

                options.EventsType = typeof(CustomCookieAuthenticationEvents);

            });

            //무언가 작업이 있을때마다 customcookie...를 호출한다.
            services.AddScoped<CustomCookieAuthenticationEvents>();
        }

        //앱 자체에 무언가 추가하고 싶은 내용이 있다면 Configure
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //exceptionPage는 개발 할때만.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //게시(release)를 하게되면
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //http로부터 https로 가게끔 해주는 함수
            app.UseHttpsRedirection();

            // 기본적으로 200몇갠가 하는 정적파일들을 서비스해주겠다라는 의미. wwwroot에 있는 css, js, lib 등등
            app.UseStaticFiles();

            // 컨트롤을 통해 라우팅을 하겠다.
            app.UseRouting();
            
            // 로그인 인증을 사용하겠다.
            app.UseAuthentication();

            // 인증을 쓰겠다라는 의미
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                //컨트롤러가 없으면 홈컨트롤러(클래스)가 기본으로 들어가고, 액션이 없으면 기본으로 인덱스 메서드가 들어간다는 의미
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
