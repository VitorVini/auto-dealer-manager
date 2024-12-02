using AutoDealerManager.CrossCutting.Helpers.Validations;
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
    public class ConcessionariasController : Controller
    {
        private readonly IConcessionariaService _concessionariaService;
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly IMapper _mapper;
        public ConcessionariasController(IConcessionariaService concessionariaService,
                                     IConcessionariaRepository concessionariaRepository,
                                     IMapper mapper)
        {
            _concessionariaService = concessionariaService;
            _concessionariaRepository = concessionariaRepository;
            _mapper = mapper;
        }

        [Route("concessionarias")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var concessionarias = _mapper.Map<IEnumerable<ConcessionariaVM>>(await _concessionariaRepository.ObterTodosAsync());
            return View(concessionarias);
        }

        [Route("nova-concessionaria")]
        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public ActionResult Create()
        {
            return View("Form", new ConcessionariaVM());
        }

        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("nova-concessionaria")]
        public async Task<ActionResult> Salvar(ConcessionariaVM concessionariaVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Erro"] = ValidationUtils.ObterErroValidacaoViewModel(ModelState);
                    return View("Form", concessionariaVM);
                }

                var concessionaria = _mapper.Map<Concessionaria>(concessionariaVM);
                if (concessionariaVM.IsUpdate)
                    await _concessionariaService.Atualizar(concessionaria);
                else
                    await _concessionariaService.Adicionar(concessionaria);

                TempData["Sucesso"] = "Operação realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["Erro"] = exception.Message;
                return View("Form", concessionariaVM);
            }

        }

        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        public async Task<ActionResult> Edit(Guid id)
        {
            var concessionariaVM = _mapper.Map<ConcessionariaVM>(await _concessionariaRepository.ObterPorIdAsync(id));

            if (concessionariaVM == null)
            {
                return HttpNotFound();
            }

            concessionariaVM.IsUpdate = true;
            return View("Form", concessionariaVM);
        }

        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ConcessionariaVM concessionariaVM)
        {
            if (!ModelState.IsValid) return View(concessionariaVM);

            if (id != concessionariaVM.Id) return HttpNotFound();

            var concessionaria = _mapper.Map<Concessionaria>(concessionariaVM);
            await _concessionariaService.Atualizar(concessionaria);

            TempData["Sucesso"] = "Concessionária atualizada com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        [CustomAuthorize(Roles = nameof(EnumNivelAcesso.Administrador) + "," + nameof(EnumNivelAcesso.Dev))]
        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var concessionaria = await _concessionariaRepository.ObterPorIdAsync(id);

            if (concessionaria == null) return HttpNotFound();

            await _concessionariaService.Remover(concessionaria);

            TempData["Sucesso"] = "Concessionária removida com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ObterModal()
        {
            var concessionarias = _mapper.Map<IEnumerable<ConcessionariaVM>>(await _concessionariaRepository.ObterTodosAsync());
            return PartialView("_Modal", concessionarias);
        }
    }
}