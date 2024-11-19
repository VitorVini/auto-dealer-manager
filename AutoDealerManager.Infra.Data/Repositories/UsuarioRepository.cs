using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repository;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AutoDealerManagerContext _db;
        public UsuarioRepository(AutoDealerManagerContext context) : base(context)
        {
            _db = new AutoDealerManagerContext();
        }

        public Usuario ObterPorId(Guid id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.Where(u => u.Ativo).ToList();
        }
        public void DesativarLock(Guid id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
