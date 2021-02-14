using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {   //최초로 생성되면 빌더를 통해서 무언가가 만들어지고 run()이 된다.
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //생성이 되면 최초 StartUp를 호출한다.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
