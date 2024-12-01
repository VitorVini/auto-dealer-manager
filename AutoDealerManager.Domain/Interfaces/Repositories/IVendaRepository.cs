using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<Venda> ObterPorProtocoloAsync(long protocolo);
        Task<IEnumerable<Venda>> ObterPorDataAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Venda>> ObterVendasPorMesAno(int mes, int ano);
        Task<Dictionary<string, decimal>> ObterVendasPorTipoDeVeiculoAsync(int mes, int ano);
        Task<Dictionary<string, decimal>> ObterVendasPorFabricanteAsync(int mes, int ano);
        Task<Dictionary<string, decimal>> ObterVendasPorConcessionariaAsync(int mes, int ano);
    }
}
