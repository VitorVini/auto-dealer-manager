﻿using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Enum;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using AutoDealerManager.MVC.Attributes;
using AutoDealerManager.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoDealerManager.MVC.Controllers
{
    [Authorize]
    public class FabricantesController : Controller
    {
        private readonly IFabricanteService _fabricanteService;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public FabricantesController(IFabricanteService fabricanteService,
                                     IFabricanteRepository fabricanteRepository,
                                     IMapper mapper)
        {
            _fabricanteService = fabricanteService;
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
        }

        [Route("fabricantes")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var fabricantes = _mapper.Map<IEnumerable<FabricanteVM>>(await _fabricanteRepository.ObterTodosAsync());
            return View(fabricantes);
        }

        [Route("novo-fabricante")]
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public ActionResult Create()
        {
            return View("Form", new FabricanteVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-fabricante")]
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public async Task<ActionResult> Salvar(FabricanteVM fabricanteVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Erro"] = ValidationUtils.ObterErroValidacaoViewModel(ModelState);
                    return View("Form", fabricanteVM);
                }

                var fabricante = _mapper.Map<Fabricante>(fabricanteVM);
                if (fabricanteVM.IsUpdate)
                    await _fabricanteService.Atualizar(fabricante);
                else
                    await _fabricanteService.Adicionar(fabricante);

                TempData["Sucesso"] = "Operação realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["Erro"] = exception.Message;
                return View("Form", fabricanteVM);
            }

        }
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public async Task<ActionResult> Edit(Guid id)
        {
            var fabricanteVM = _mapper.Map<FabricanteVM>(await _fabricanteRepository.ObterPorIdAsync(id));

            if (fabricanteVM == null)
            {
                return HttpNotFound();
            }

            fabricanteVM.IsUpdate = true;
            return View("Form", fabricanteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public async Task<ActionResult> Edit(Guid id, FabricanteVM fabricanteVM)
        {
            if (!ModelState.IsValid) return View(fabricanteVM);

            if (id != fabricanteVM.Id) return HttpNotFound();

            var fabricante = _mapper.Map<Fabricante>(fabricanteVM);
            await _fabricanteService.Atualizar(fabricante);

            TempData["Sucesso"] = "Fabricante atualizado com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, ActionName("Delete")]
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var fabricante = await _fabricanteRepository.ObterPorIdAsync(id);

            if (fabricante == null) return HttpNotFound();

            await _fabricanteService.Remover(fabricante);

            TempData["Sucesso"] = "Fabricante removido com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ObterModalFabricantes()
        {
            var fabricantes = _mapper.Map<IEnumerable<FabricanteVM>>(await _fabricanteRepository.ObterTodosAsync());
            return PartialView("_ModalFabricantes", fabricantes);
        }
    }
}