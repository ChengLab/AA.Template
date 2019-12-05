using AA.AspNetCore.Infrastructure;
using Admin.FrameWork.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.FrameWork.Infrastructure
{
    public class AAErrorHandlerStartUp : IAAStartup
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
      
        }

        public void Configure(IApplicationBuilder application)
        {
            ////exception handling
            application.UseAAExceptionHandler();
            //400(bad request)
            //404 (not found)
        }
        public int Order => 0;//error handlers 应该第一个被加载
    }
}
