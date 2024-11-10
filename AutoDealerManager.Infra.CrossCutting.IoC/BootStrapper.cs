using AutoDealerManager.Application.Interfaces;
using AutoDealerManager.Application.Services;
using AutoDealerManager.Domain.Entities.Services;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Repository;
using AutoDealerManager.Domain.Interfaces.Services;
using AutoDealerManager.Infra.CrossCutting.Identity.Config;
using AutoDealerManager.Infra.CrossCutting.Identity.Context;
using AutoDealerManager.Infra.CrossCutting.Identity.Models;
using AutoDealerManager.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace AutoDealerManager.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IConcessionariaRepository, ConcessionariaRepository>(Lifestyle.Scoped);
            container.Register<IFabricanteRepository, FabricanteRepository>(Lifestyle.Scoped);
            container.Register<IVeiculoRepository, VeiculoRepository>(Lifestyle.Scoped);
            container.Register<IVendaRepository, VendaRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);

            container.Register<IConcessionariaService, ConcessionariaService>(Lifestyle.Scoped);
            container.Register<IFabricanteService, FabricanteService>(Lifestyle.Scoped);
            container.Register<IVeiculoService, VeiculoService>(Lifestyle.Scoped);
            container.Register<IVendaService, VendaService>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            container.Register<IVendaApp, VendaApp>(Lifestyle.Scoped);

        }
    }
}
