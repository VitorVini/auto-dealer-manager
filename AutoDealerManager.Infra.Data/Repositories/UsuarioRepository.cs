using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interface.Repository;
using AutoDealerManager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AutoDealerManagerContext _db;

        public UsuarioRepository()
        {
            _db = new AutoDealerManagerContext();
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.ToList();
        }
        public void DesativarLock(string id)
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
