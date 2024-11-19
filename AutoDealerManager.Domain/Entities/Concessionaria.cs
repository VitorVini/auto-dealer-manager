using AutoDealerManager.Domain.Core;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Entities
{
    public class Concessionaria : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CapacidadeMaximaVeiculos { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
