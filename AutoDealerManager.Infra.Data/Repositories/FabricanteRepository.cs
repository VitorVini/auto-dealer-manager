using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(AutoDealerManagerContext context) : base(context) { }
        public async Task<Fabricante> ObterPorNomeAsync(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(f => f.Nome == nome);
        }

        public async Task<bool> NomeExisteAsync(string nome)
        {
            return await DbSet.AnyAsync(f => f.Nome == nome);
        }

        public async Task<Fabricante> ObterFabricanteVeiculosAsync(Guid id)
        {
            return await Db.Fabricantes.AsNoTracking()
                .Include(f => f.Veiculos).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> FabricanteExisteAsync(Guid id)
        {
            return await Db.Fabricantes.AnyAsync(f => f.Id == id);
        }

    }
}
