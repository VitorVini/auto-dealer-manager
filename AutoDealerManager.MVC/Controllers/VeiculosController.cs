using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Enum;
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
    public class VeiculosController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public VeiculosController(IVeiculoService veiculoService,
                                     IVeiculoRepository veiculoRepository,
                                     IMapper mapper,
                                     IFabricanteRepository fabricanteRepository)
        {
            _veiculoService = veiculoService;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _fabricanteRepository = fabricanteRepository;
        }

        [Route("veiculos")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await CarregarViewbagsAsync();
            var veiculos = _mapper.Map<IEnumerable<VeiculoVM>>(await _veiculoRepository.ObterVeiculosComFabricantesAsync());
            return View(veiculos);
        }

        [Route("novo-veiculo")]
        public async Task<ActionResult> Create()
        {
            await CarregarViewbagsAsync();
            return View("Form", new VeiculoVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-veiculo")]
        public async Task<ActionResult> Salvar(VeiculoVM veiculoVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Erro"] = ValidationUtils.ObterErroValidacaoViewModel(ModelState);

                    await CarregarViewbagsAsync();

                    return View("Form", veiculoVM);
                }

                var veiculo = _mapper.Map<Veiculo>(veiculoVM);

                if (veiculoVM.IsUpdate)
                    await _veiculoService.Atualizar(veiculo);
                else
                    await _veiculoService.Adicionar(veiculo);

                TempData["Sucesso"] = "Operação realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["Erro"] = exception.Message;

                await CarregarViewbagsAsync();

                return View("Form", veiculoVM);
            }

        }

        public async Task<ActionResult> Edit(Guid id)
        {
            await CarregarViewbagsAsync();
            var veiculoVM = _mapper.Map<VeiculoVM>(await _veiculoRepository.ObterPorIdAsync(id));

            if (veiculoVM == null)
            {
                return HttpNotFound();
            }

            veiculoVM.IsUpdate = true;
            return View("Form", veiculoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, VeiculoVM veiculoVM)
        {
            if (!ModelState.IsValid) return View(veiculoVM);

            if (id != veiculoVM.Id) return HttpNotFound();

            var veiculo = _mapper.Map<Veiculo>(veiculoVM);
            await _veiculoService.Atualizar(veiculo);

            TempData["Sucesso"] = "Veiculo atualizado com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var veiculo = await _veiculoRepository.ObterPorIdAsync(id);

            if (veiculo == null) return HttpNotFound();

            await _veiculoService.Remover(veiculo);

            TempData["Sucesso"] = "Veiculo removido com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ObterModal()
        {
            var veiculos = _mapper.Map<IEnumerable<VeiculoVM>>(await _veiculoRepository.ObterVeiculosComFabricantesAsync());
            return PartialView("_Modal", veiculos);
        }

        private async Task CarregarViewbagsAsync()
        {
            ViewBag.Fabricantes = new SelectList((await _fabricanteRepository.ObterTodosAsync()).Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Nome }), "Value", "Text");

            ViewBag.TiposVeiculo = new SelectList(Enum.GetValues(typeof(EnumVeiculo)).Cast<EnumVeiculo>().Select(t => new SelectListItem { Value = ((int)t).ToString(), Text = t.ToString() }).ToList(), "Value", "Text");
        }
    }
}