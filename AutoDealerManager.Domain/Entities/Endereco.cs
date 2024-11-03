using System;

namespace AutoDealerManager.Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public Guid ConcessionariaId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public virtual Concessionaria Concessionaria { get; set; }
    }
}