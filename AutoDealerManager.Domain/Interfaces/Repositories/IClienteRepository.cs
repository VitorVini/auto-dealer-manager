using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> ClienteExisteAsync(Guid id, string cpf);
        Task<Cliente> ObterPorCpfAsync(string cpf);
    }
}
