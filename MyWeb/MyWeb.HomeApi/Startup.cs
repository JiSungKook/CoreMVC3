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
    //coreMvc와 약간의 차이는 있지만. coreMvc startup.cs 파일을 가져다 써도 동일하게 사용 된다
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
            //Webapi에서는 AddControllers
            //CoreMvc에선  AddControllersWithViews()까지 되어있는 차이가 있다.
            services.AddControllers();

            //CORS를 설정해보자.
            //서비스에 추가하면 Configure에도 사용을 해줘야 한다.
            services.AddCors((options) => {
                options.AddDefaultPolicy((policy) =>
                {
                    //전체 허용하기
                    //policy.AllowAnyOrigin();

                    policy.AllowAnyMethod();
                    //일부 허용하기
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

            //default에 추가했으니 그대로 쓰면된다.
            app.UseCors();

            //default가 아니라면 policyName 넣어줘야함
            //app.UseCors("policyName");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //coreMvc에선 MapControllerRoute()메서드이다.
                endpoints.MapControllers();
            });
        }
    }
}
