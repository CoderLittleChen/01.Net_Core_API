using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Net_Core_API.Entities;
using Net_Core_API.Repositories;
using Net_Core_API.Services;
using NLog.Extensions.Logging;

namespace _01从头编写API基础框架
{
    public class Startup
    {
        //声明对象 读取json配置文件
        public static IConfiguration _configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string conStr = _configuration["connectionstr:conStr"];

            services.AddDbContext<MyContext>(a => a.UseSqlServer(conStr));
            //ConfigureServices  这个方法是用来把services加入到container(asp.net core的容器)中

            //注册MVC到Container
            //.Net Core对于接口的返回数据  默认只实现了json，若是想要返回xml格式的数据，需要添加代码
            services.AddMvc()
                .AddMvcOptions(options =>
                {
                    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });

            //注册服务 这里Transient 的service是每次请求都会创建一个新的实例

            //这句话的意思是  当需要一个ILocalMailService实现的时候，Container就会提供一个LocalMailService的实例
            services.AddTransient<ILocalMailService, LocalMailService>();

            //
            services.AddScoped<IProductRepository, ProductRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,MyContext myContext)
        {
            loggerFactory.AddProvider(new NLogLoggerProvider());

            //Configure 方法是asp.net core用来具体指定如何处理每个http请求的，
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            myContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();

            //这里要注意顺序  
            app.UseMvc();

            app.Run(async (context) =>
            {
                //throw new Exception();
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
