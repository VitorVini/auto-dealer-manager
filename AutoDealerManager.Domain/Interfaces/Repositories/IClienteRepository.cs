using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> NomeExisteAsync(string nome);
        Task<bool> CpfExisteAsync(string cpf);
        Task<bool> ClienteExisteAsync(Guid id);
    }
}
