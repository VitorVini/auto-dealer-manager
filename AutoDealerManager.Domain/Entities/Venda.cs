﻿using AutoDealerManager.Domain.Core;
using System;

namespace AutoDealerManager.Domain.Entities
{
    public class Venda : Entity
    {
        public Guid Id { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid ConcessionariaId { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Protocolo { get; set; }

        // EF Relations
        public Veiculo Veiculo { get; set; }
        public Concessionaria Concessionaria { get; set; }
        public Cliente Cliente { get; set; }
    }
}