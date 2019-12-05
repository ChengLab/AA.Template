using AA.AspNetCore.Infrastructure;
using AA.AspNetCore.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA.Utils
{
    public class AAEngine : IEngine
    {
        #region Properties

        /// <summary>
        /// Gets or sets service provider
        /// </summary>
        private IServiceProvider _serviceProvider { get; set; }

        #endregion

        #region Utilities
        /// <summary>
        /// Get IServiceProvider
        /// </summary>
        /// <returns>IServiceProvider</returns>
        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="nopConfig">Nop configuration parameters</param>
        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services, ITypeFinder typeFinder)
        {
            var containerBuilder = new ContainerBuilder();

            //注册 engine
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            //注册 type finder
            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //populate Autofac container builder with the set of registered service descriptors
            containerBuilder.Populate(services);

            //find dependency registrars provided by other assemblies
            var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            //create and sort instances of dependency registrars
            var instances = dependencyRegistrars
                .Select(dependencyRegistrar => (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar))
                .OrderBy(dependencyRegistrar => dependencyRegistrar.Order);

            //register all provided dependencies
            foreach (var dependencyRegistrar in instances)
                dependencyRegistrar.Register(containerBuilder, typeFinder);

            //create service provider
            _serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            return _serviceProvider;
        }
        #endregion

        #region Methods
        public IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //find startup configurations provided by other assemblies

            var typeFinder = new WebAppTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<IAAStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (IAAStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            //configure services
            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);
            //注册 mapper 配置

            //注册依赖

            RegisterDependencies(services,typeFinder);
            return _serviceProvider;
        }

        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            //find startup configurations provided by other assemblies
            var typeFinder = Resolve<ITypeFinder>();
            var startupConfigurations = typeFinder.FindClassesOfType<IAAStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (IAAStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            //configure request pipeline
            foreach (var instance in instances)
                instance.Configure(application);
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {return GetServiceProvider().GetService(type);
             
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        public object ResolveUnregistered(Type type)
        {
            Exception innerException = null;
            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    //try to resolve constructor parameters
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                            throw new  Exception("Unknown dependency");
                        return service;
                    });

                    //all is ok, so create instance
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
        }

        #endregion
        #region Properties

        /// <summary>
        /// Service provider
        /// </summary>
        public virtual IServiceProvider ServiceProvider => _serviceProvider;

        #endregion
    }
}
