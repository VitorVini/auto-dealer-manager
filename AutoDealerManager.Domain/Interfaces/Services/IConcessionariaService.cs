using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Services
{
    public interface IConcessionariaService : IDisposable
    {
        Task Adicionar(Concessionaria concessionaria);
        Task Atualizar(Concessionaria concessionaria);
        Task Remover(Guid id);
    }
}
