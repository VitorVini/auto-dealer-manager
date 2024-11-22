using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using AutoDealerManager.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoDealerManager.MVC.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaRepository _vendaRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public VendasController(IVendaService vendaService,
                                     IVendaRepository vendaRepository,
                                     IMapper mapper,
                                     IFabricanteRepository fabricanteRepository)
        {
            _vendaService = vendaService;
            _vendaRepository = vendaRepository;
            _mapper = mapper;
            _fabricanteRepository = fabricanteRepository;
        }

        [Route("vendas")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await CarregarViewbagsAsync();
            var vendas = _mapper.Map<IEnumerable<VendaVM>>(await _vendaRepository.ObterTodosAsync());
            return View(vendas);
        }

        public async Task<ActionResult> RealizarVenda()
        {
            await CarregarViewbagsAsync();
            return View("Form", new VendaVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RealizarVenda(VendaVM vendaVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Erro"] = ValidationUtils.ObterErroValidacaoViewModel(ModelState);

                    await CarregarViewbagsAsync();

                    return View("Form", vendaVM);
                }

                var venda = _mapper.Map<Venda>(vendaVM);

                await _vendaService.Adicionar(venda);

                TempData["Sucesso"] = "Operação realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["Erro"] = exception.Message;

                await CarregarViewbagsAsync();

                return View("Form", vendaVM);
            }

        }

        public async Task<ActionResult> Edit(Guid id)
        {
            await CarregarViewbagsAsync();
            var vendaVM = _mapper.Map<VendaVM>(await _vendaRepository.ObterPorIdAsync(id));

            if (vendaVM == null)
            {
                return HttpNotFound();
            }

            return View("Form", vendaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, VendaVM vendaVM)
        {
            if (!ModelState.IsValid) return View(vendaVM);

            if (id != vendaVM.Id) return HttpNotFound();

            var venda = _mapper.Map<Venda>(vendaVM);
            await _vendaService.Atualizar(venda);

            TempData["Sucesso"] = "Venda atualizado com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var venda = await _vendaRepository.ObterPorIdAsync(id);

            if (venda == null) return HttpNotFound();

            await _vendaService.Remover(venda);

            TempData["Sucesso"] = "Venda removido com sucesso!";
            return RedirectToAction("Index");
        }

        private async Task CarregarViewbagsAsync()
        {
            ViewBag.Fabricantes = new SelectList((await _fabricanteRepository.ObterTodosAsync()).Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Nome }), "Value", "Text");
        }
    }
}