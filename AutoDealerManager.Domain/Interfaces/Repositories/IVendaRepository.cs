using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<Venda> ObterPorProtocoloAsync(string protocolo);
        Task<bool> VerificarPrecoValidoAsync(Guid veiculoId, decimal precoVenda);
        Task<IEnumerable<Venda>> ObterPorDataAsync(DateTime dataInicio, DateTime dataFim);
    }
}
