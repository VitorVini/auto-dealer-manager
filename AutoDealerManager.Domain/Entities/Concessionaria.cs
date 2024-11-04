using AutoDealerManager.Domain.Core;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Entities
{
    public class Concessionaria : Entity
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CapacidadeMaximaVeiculos { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
