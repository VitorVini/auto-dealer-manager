using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AutoDealerManagerContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Venda>> ObterPorDataAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await DbSet
                .AsNoTracking()
                .Where(v => v.Data >= dataInicio && v.Data <= dataFim && v.Ativo)
                .ToListAsync();
        }

        public async Task<Venda> ObterPorProtocoloAsync(long protocolo)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(v => v.Protocolo == protocolo && v.Ativo);
        }

        public async Task<bool> VerificarPrecoValidoAsync(Guid veiculoId, decimal precoVenda)
        {
            var veiculo = await Db.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == veiculoId && v.Ativo);
            return veiculo != null && precoVenda <= veiculo.Preco;
        }

        public override async Task<IEnumerable<Venda>> ObterTodosAsync()
        {
            return await DbSet
                .Where(v => v.Ativo)
                .Include(v => v.Cliente)
                .Include(v => v.Veiculo)
                .Include(v => v.Concessionaria)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
