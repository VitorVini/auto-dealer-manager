﻿using AutoDealerManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AutoDealerManager.Domain.Interfaces.Services
{
    public interface IFabricanteService : IDisposable
    {
        //Task<bool> WebsiteAcessivelAsync(string website, CancellationToken cancellationToken);
        bool WebsiteAcessivel(string website);
        Task Adicionar(Fabricante fabricante);
        Task Atualizar(Fabricante fabricante);
        Task Remover(Fabricante fabricante);

    }
}
