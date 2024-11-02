using AutoDealerManager.Domain.Core;
using System;

namespace AutoDealerManager.Domain.Entities
{
    public class Fabricante : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public int AnoFundacao { get; set; }
        public string Website { get; set; }
    }
}
