using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interface.Repositories
{
    public interface IConcessionariaRepository : IRepository<Concessionaria>
    {
        Task<Concessionaria> ObterPorNomeAsync(string nome);
    }
}
