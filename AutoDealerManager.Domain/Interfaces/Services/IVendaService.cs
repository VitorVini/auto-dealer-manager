using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Services
{
    public interface IVendaService : IDisposable
    {
        Task Adicionar(Venda venda);
        Task Atualizar(Venda venda);
        Task Remover(Venda venda);
    }
}
