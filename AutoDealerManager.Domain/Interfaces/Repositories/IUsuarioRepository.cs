using AutoDealerManager.Domain.Core.Interface;
using AutoDealerManager.Domain.Entities;
using System;

namespace AutoDealerManager.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void DesativarLock(Guid id);
    }
}
