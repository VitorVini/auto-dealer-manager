using AutoDealerManager.CrossCutting.Helpers.Validations;
using AutoDealerManager.Domain.Entities;
using AutoDealerManager.Domain.Interfaces.Repositories;
using AutoDealerManager.Domain.Interfaces.Services;
using AutoDealerManager.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoDealerManager.MVC.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;
        public VeiculosController(IVeiculoService veiculoService,
                                     IVeiculoRepository veiculoRepository,
                                     IMapper mapper)
        {
            _veiculoService = veiculoService;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        [Route("veiculos")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var veiculos = _mapper.Map<IEnumerable<VeiculoVM>>(await _veiculoRepository.ObterTodosAsync());
            return View(veiculos);
        }

        [Route("novo-veiculo")]

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            return View("Form", new VeiculoVM());
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-veiculo")]
        public async Task<ActionResult> Salvar(VeiculoVM veiculoVM)
        {
            try {
                if (!ModelState.IsValid) {
                    TempData["Erro"] = ValidationUtils.ObterErroValidacaoViewModel(ModelState);
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
            catch(Exception exception)
            {
                TempData["Erro"] = exception.Message;
                return View("Form", veiculoVM);
            }
            
        }

        // GET: Veiculos/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var veiculoVM = _mapper.Map<VeiculoVM>(await _veiculoRepository.ObterPorIdAsync(id));

            if (veiculoVM == null)
            {
                return HttpNotFound();
            }

            veiculoVM.IsUpdate = true;
            return View("Form", veiculoVM);
        }

        // POST: Veiculos/Edit/5
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

        // POST: Veiculos/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var veiculo = await _veiculoRepository.ObterPorIdAsync(id);

            if (veiculo == null) return HttpNotFound();

            await _veiculoService.Remover(veiculo);

            TempData["Sucesso"] = "Veiculo removido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}