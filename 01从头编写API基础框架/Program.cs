using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _01从头编写API基础框架
{
    public class Program
    {
        //方法调用顺序  Main--> ConfigurationServices-->  Configure
        public static void Main(string[] args)
        {
            //这里.Net Core Application本质上就是一个控制台程序，它是一个调用.Net Core相关库的Console Application
            //因为.Net Core Web应用程序需要一个宿主，所以会调用BuildWebHost 来创建一个宿主对象
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //在CreateDefaultBuilder源代码中  默认调用Kestrel server
            //但是在开发中 使用的是IIS Express,调用UserIISIntegration()方法是启用IIS作为Kestrel的Reverse Proxy Server来使用

            //请求管道：那些处理 http requests 并返回responses的代码就组成了request pipeline
            //中间件：我们可以做的就是使用一些程序来配置那些请求管道request pipeline以便处理request和response，每层中间件接到
            //请求后都可以直接返回或调用下一个中间件，例：在第一层调用Authentication验证中间件，如果验证失败，则直接返回一个
            //表示请求未授权的response

            //CreateDefaultBuilder 方法是2.0中新增的，其内部实现 主要做了6件事
            //1、注册Kestrel中间件 指定webhost要使用的Server（HTTP服务器）
            //2、设置Content根目录，将当前项目的跟目录作为ContentRoot的目录
            //3、读取appsetting.json 配置文件，开发环境下的UserSecrets以及环境变量和命令行参数
            //4、读取配置文件中的Logging节点，对日志系统进行配置
            //5、添加IISIntegrated中间件
            
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
