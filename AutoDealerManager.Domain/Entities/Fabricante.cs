using AutoDealerManager.Domain.Core;
using System;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Entities
{
    public class Fabricante : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public int AnoFundacao { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
