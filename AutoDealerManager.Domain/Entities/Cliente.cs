using AutoDealerManager.Domain.Core;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
