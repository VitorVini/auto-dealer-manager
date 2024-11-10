using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Enum;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(AutoDealerManagerContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Veiculo>> ObterPorModeloAsync(Guid fabricanteId, string modelo)
        {
            return await DbSet.AsNoTracking().Where(v => v.Modelo == modelo && v.FabricanteId == fabricanteId).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorFabricanteAsync(Guid fabricanteId)
        {
            return await DbSet.AsNoTracking().Where(v => v.FabricanteId == fabricanteId).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorTipoAsync(EnumVeiculo tipoVeiculo)
        {
            return await DbSet.AsNoTracking().Where(v => v.TipoVeiculo == tipoVeiculo).ToListAsync();
        }

        public async Task<bool> VeiculoExisteAsync(string modelo)
        {
            return await DbSet.AsNoTracking().AnyAsync(v => v.Modelo == modelo);
        }

    }
}
