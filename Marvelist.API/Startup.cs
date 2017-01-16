using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Marvelist.API;
using Marvelist.API.Providers;
using Marvelist.DataAccess;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Marvelist.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.EnableSystemDiagnosticsTracing();
            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureIoc(config);
            app.UseWebApi(config);
            AutoMapperConfiguration.Configure();
            Database.SetInitializer(new MarvelInitializer());



        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            const string publicClientId = "self";
            Func<UserManager<ApplicationUser>> userManagerFactory =
                () => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MarvelEntities()));
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(publicClientId, userManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //app.UseOAuthBearerTokens(oAuthServerOptions);





            //OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            //{

            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            //    Provider = new SimpleAuthorizationServerProvider(),
            //    RefreshTokenProvider = new SimpleRefreshTokenProvider()
            //};

            // Token Generation
        }

        public static void ConfigureIoc(HttpConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerRequest();
            //REPOS
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            containerBuilder.RegisterType<SeriesRepository>().As<ISeriesRepository>().InstancePerRequest();
            containerBuilder.RegisterType<ComicRepository>().As<IComicRepository>().InstancePerRequest();
            containerBuilder.RegisterType<UserSeriesRepository>().As<IUserSeriesRepository>().InstancePerRequest();
            containerBuilder.RegisterType<UserComicRepository>().As<IUserComicRepository>().InstancePerRequest();
            //SERVICES
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            containerBuilder.RegisterType<SeriesService>().As<ISeriesService>().InstancePerRequest();
            containerBuilder.RegisterType<UserSeriesService>().As<IUserSeriesService>().InstancePerRequest();
            containerBuilder.RegisterType<UserComicService>().As<IUserComicService>().InstancePerRequest();

            containerBuilder.Register(
                    c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MarvelEntities())))
                .As<UserManager<ApplicationUser>>()
                .InstancePerRequest();

            IContainer container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}