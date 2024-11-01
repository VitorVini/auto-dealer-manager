using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoDealerManager.MVC.Startup))]
namespace AutoDealerManager.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
