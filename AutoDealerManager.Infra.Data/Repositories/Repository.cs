using AutoDealerManager.Domain.Core;
using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AutoDealerManagerContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(AutoDealerManagerContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }
        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await DbSet
                .Where(e => e.Id == id && e.Ativo)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await DbSet.AsNoTracking()
                .Where(e => e.Ativo)
                .ToListAsync();
        }
        public virtual async Task AdicionarAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }
        public virtual async Task AtualizarAsync(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public virtual async Task RemoverAsync(TEntity entity)
        {
            entity.Ativo = false;
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
