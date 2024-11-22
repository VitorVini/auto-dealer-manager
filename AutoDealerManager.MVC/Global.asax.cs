using AutoDealerManager.Infra.CrossCutting.IoC;
using Microsoft.Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web;
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

            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null)
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;
            });


            // Registra os controllers da camada MVC no SimpleInjector
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
