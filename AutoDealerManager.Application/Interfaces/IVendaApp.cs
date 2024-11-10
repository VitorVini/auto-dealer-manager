using AutoDealerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerManager.Application.Interfaces
{
    public interface IVendaApp
    {
        Task<IEnumerable<Concessionaria>> ObterConcessionariasAsync();
        Task<IEnumerable<Fabricante>> ObterFabricantesAsync();
        Task<IEnumerable<Veiculo>> ObterVeiculosPorFabricanteAsync(Guid fabricanteId);
    }
}
