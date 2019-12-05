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
    public class AADbStartup : IAAStartup
    {
        
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
        public void Configure(IApplicationBuilder application)
        {
            application.UseAADapperFluentMap();
            application.UseAAAutoMapper();
        }
        public int Order => 10;
    }
}
