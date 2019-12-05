using AA.AspNetCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.FrameWork.Infrastructure
{
    public class AACommonStartup : IAAStartup
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseCookiePolicy();
        }

        public int Order => 100;//common services should be loaded after error handlers
    }
}
