using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interface.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class ConcessionariaRepository : Repository<Concessionaria>, IConcessionariaRepository
    {
        public async Task<Concessionaria> ObterPorNomeAsync(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }
}
