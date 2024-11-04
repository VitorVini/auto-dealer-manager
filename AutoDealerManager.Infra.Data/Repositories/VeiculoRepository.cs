using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Enum;
using AutoDealerManager.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public async Task<IEnumerable<Veiculo>> ObterPorModeloAsync(string modelo)
        {
            return await DbSet.AsNoTracking().Where(v => v.Modelo == modelo).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorFabricanteAsync(Guid fabricanteId)
        {
            return await DbSet.AsNoTracking().Where(v => v.FabricanteId == fabricanteId).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorTipoAsync(EnumVeiculo tipoVeiculo)
        {
            return await DbSet.AsNoTracking().Where(v => v.TipoVeiculo == tipoVeiculo).ToListAsync();
        }
    }
}
