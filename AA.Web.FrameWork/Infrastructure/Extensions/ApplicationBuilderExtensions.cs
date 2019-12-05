using AA.AutoMapper;
using AA.FrameWork.ObjectMapping;
using AA.InitConfig;
using AA.InitConfig.Mapper;
using AA.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;

namespace Admin.FrameWork.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }
        /// <summary>
        /// Add exception handling
        /// </summary>
        /// <param name="application"></param>
        public static void UseAAExceptionHandler(this IApplicationBuilder application)
        {
           var env= EngineContext.Current.Resolve<IHostingEnvironment>();

            if (env.IsDevelopment())
            {
              
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Home/Error");
                application.UseHsts();
            }
        }


        /// <summary>
        /// Configure MVC routing
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseAAMvc(this IApplicationBuilder application)
        {
            application.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(
                    name: "default",
                    template: "{controller=Jobinfo}/{action=Index}/{id?}");
            });
        }

        public static IApplicationBuilder UseAADapperFluentMap(this IApplicationBuilder applicationBuilder)
        {
            FluentDBMapConf.Map();
            return applicationBuilder;
        }

        public static IApplicationBuilder UseAAAutoMapper(this IApplicationBuilder applicationBuilder)
        {
            var mapperConfig = new WebMapperConfigurations();
            AutoMapperConfiguration.Init(new List<Action<IMapperConfigurationExpression>> { mapperConfig.GetConfiguration() });
            ObjectMapManager.ObjectMapper = new AutoMapperObjectMapper();
            return applicationBuilder;
        }
    }
}
