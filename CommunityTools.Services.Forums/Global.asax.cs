using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.Common;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.Services.Forums
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            // autofac container
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<ForumModule>();
            builder.RegisterModule<DataAccessModule>();

            // Auto Mapper v5 Support
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                MappingConfiguration.Configure(typeof(ForumModule).Assembly, cfg);
                MappingConfiguration.Configure(typeof(ForumsBusinessProviderModule).Assembly, cfg);
            });

            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
