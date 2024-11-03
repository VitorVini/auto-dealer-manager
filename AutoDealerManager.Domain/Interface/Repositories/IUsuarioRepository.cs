using AutoDealerManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
