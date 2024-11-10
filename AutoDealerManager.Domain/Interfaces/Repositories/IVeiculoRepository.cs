using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> ObterPorModeloAsync(Guid fabricanteId, string modelo);
        Task<IEnumerable<Veiculo>> ObterPorFabricanteAsync(Guid fabricanteId);
        Task<IEnumerable<Veiculo>> ObterPorTipoAsync(EnumVeiculo tipoVeiculo);
        Task<bool> VeiculoExisteAsync(string modelo);
    }
}
