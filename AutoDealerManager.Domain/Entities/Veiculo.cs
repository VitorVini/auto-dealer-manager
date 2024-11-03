using AutoDealerManager.Domain.Core;
using AutoDealerManager.Domain.Enum;
using System;
using System.Collections.Generic;

namespace AutoDealerManager.Domain.Entities
{
    public class Veiculo : Entity
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
        public Guid FabricanteId { get; set; }
        public EnumVeiculo TipoVeiculo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
        public virtual ICollection<Fabricante> Fabricantes { get; set; }
    }
}
