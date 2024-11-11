using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Cliente cliente);
    }
}
