using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RaygunTrello.Models;
using RaygunTrello.Services;

namespace RaygunTrello
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register services
            ServiceLocator.RegisterSingletonService<ITrelloService, TrelloService>();
            ServiceLocator.RegisterService<ITrelloRepository, TrelloRepository>();
        }
    }
}
