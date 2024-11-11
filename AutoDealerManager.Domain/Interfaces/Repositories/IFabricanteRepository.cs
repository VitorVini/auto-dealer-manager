using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository : IRepository<Fabricante>
    {
        Task<Fabricante> ObterPorNomeAsync(string nome);
        Task<bool> NomeExisteAsync(Guid id, string nome);
        Task<Fabricante> ObterFabricanteVeiculosAsync(Guid id);
        Task<bool> FabricanteExisteAsync(Guid id);
    }
}
