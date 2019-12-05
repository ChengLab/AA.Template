using AA.AspNetCore.Infrastructure;
using Admin.FrameWork.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.FrameWork.Infrastructure
{
    public class AAMvcStartup : IAAStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseAAMvc();
        }
        public int Order => 1000;//MVC 应该放到最后
    }
}
