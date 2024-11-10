using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Infra.Data.Context;

namespace AutoDealerManager.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AutoDealerManagerContext context) : base(context)
        {

        }
    }
}
