using System.Data.Entity;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Marvelist.DataAccess;
using Marvelist.API.App_Start;

namespace Marvelist.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            Bootstrapper.Configure();
            Database.SetInitializer(new MarvelInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
