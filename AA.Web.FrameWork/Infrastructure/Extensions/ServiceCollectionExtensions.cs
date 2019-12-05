using AA.AspNetCore;
using AA.AspNetCore.Infrastructure;
using AA.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.FrameWork.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureServices(this IServiceCollection services,
             IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //添加 accessor 到httpcontext 
            services.AddHttpContextAccessor();

            //配置 默认 file provider
            CommonHelper.DefaultFileProvider = new AAFileProvider(hostingEnvironment);

            //创建engine 配置服务提供者
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureServices(services,configuration);
            return serviceProvider;
        }
    }
}
