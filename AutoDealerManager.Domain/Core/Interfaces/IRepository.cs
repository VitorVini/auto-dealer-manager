using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Core.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task AdicionarAsync(TEntity entity);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task AtualizarAsync(TEntity entity);
        Task RemoverAsync(TEntity entity);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
