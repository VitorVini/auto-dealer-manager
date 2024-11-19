using System;

namespace AutoDealerManager.Domain.Core
{

    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } = true;
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
