using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;

namespace AutoDealerManager.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void DesativarLock(Guid id);
    }
}
