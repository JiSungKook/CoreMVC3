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
        {   //���ʷ� �����Ǹ� ������ ���ؼ� ���𰡰� ��������� run()�� �ȴ�.
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //������ �Ǹ� ���� StartUp�� ȣ���Ѵ�.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
