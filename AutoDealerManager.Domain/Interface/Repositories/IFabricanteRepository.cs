using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interface.Repositories
{
    public interface IFabricanteRepository : IRepository<Fabricante>
    {
        Task<Fabricante> ObterPorNomeAsync(string nome);
        Task<bool> NomeExisteAsync(string nome);
    }
}
