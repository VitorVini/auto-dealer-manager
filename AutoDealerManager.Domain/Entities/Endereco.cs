using AutoDealerManager.Domain.Core;
using System;

namespace AutoDealerManager.Domain.Entities
{
    public class Endereco : Entity
    {
        public Guid ConcessionariaId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public virtual Concessionaria Concessionaria { get; set; }
    }
}