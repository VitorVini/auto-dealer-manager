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

        public async Task<IEnumerable<Veiculo>> ObterVeiculosComFabricantesAsync()
        {
            return await Db.Veiculos.Where(v => v.Ativo).Include(v => v.Fabricante).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorModeloAsync(Guid fabricanteId, string modelo)
        {
            return await DbSet
                .AsNoTracking()
                .Where(v => v.Modelo == modelo && v.FabricanteId == fabricanteId && v.Ativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorFabricanteAsync(Guid fabricanteId)
        {
            return await DbSet.AsNoTracking().Where(v => v.FabricanteId == fabricanteId && v.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterPorTipoAsync(EnumVeiculo tipoVeiculo)
        {
            return await DbSet.AsNoTracking().Where(v => v.TipoVeiculo == tipoVeiculo && v.Ativo).ToListAsync();
        }

        public async Task<bool> VeiculoExisteAsync(Guid Id, string modelo)
        {
            return await DbSet.AsNoTracking().AnyAsync(v => v.Modelo == modelo && v.FabricanteId == Id && v.Ativo);
        }

    }
}
