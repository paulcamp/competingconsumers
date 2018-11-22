using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MTCompetingConsumers.ServiceBus;

namespace MTCompetingConsumers
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebServiceBusHelper.InitServiceBus();
        }

        protected void Application_End()
        {
            WebServiceBusHelper.KillServiceBus();
        }
    }
}
