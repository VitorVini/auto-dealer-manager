using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Services
{
    public interface IVeiculoService : IDisposable
    {
        Task Adicionar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Remover(Veiculo veiculo);
    }
}
