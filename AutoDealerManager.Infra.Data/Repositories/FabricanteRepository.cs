using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interface.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        public async Task<Fabricante> ObterPorNomeAsync(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(f => f.Nome == nome);
        }

        public async Task<bool> NomeExisteAsync(string nome)
        {
            return await DbSet.AnyAsync(f => f.Nome == nome);
        }
    }
}
