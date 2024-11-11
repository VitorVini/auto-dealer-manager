using AutoDealerManager.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoDealerManager.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Inicializa o container
            var container = new SimpleInjector.Container();
            BootStrapper.RegisterServices(container);

            // Define o container como o DependencyResolver do ASP.NET MVC
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            // Registra os controllers da camada MVC no SimpleInjector
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
