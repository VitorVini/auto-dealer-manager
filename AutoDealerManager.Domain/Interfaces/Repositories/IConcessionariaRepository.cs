using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IConcessionariaRepository : IRepository<Concessionaria>
    {
        Task<Concessionaria> ObterPorNomeAsync(string nome);
        Task<bool> ConcessionariaExisteAsync(Guid Id, string nome);
    }
}
