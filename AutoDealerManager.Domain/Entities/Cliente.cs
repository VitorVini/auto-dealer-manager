using System;

namespace AutoDealerManager.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
    }
}
