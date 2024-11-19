using AutoDealerManager.Domain.Entities;
using AutoDealerManager.MVC.ViewModels;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace AutoDealerManager.MVC.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fabricante, FabricanteVM>().ReverseMap();
            CreateMap<Concessionaria, ConcessionariaVM>().ReverseMap();
            CreateMap<Cliente, ClienteVM>().ReverseMap();
            CreateMap<Usuario, UsuarioVM>().ReverseMap();
            CreateMap<Veiculo, VeiculoVM>().ReverseMap();
            CreateMap<Venda, VendaVM>().ReverseMap();

        }
    }
}