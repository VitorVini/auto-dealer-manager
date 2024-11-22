using AutoDealerManager.Domain.Interfaces.Repository;
using System;
using System.Web.Mvc;

namespace AutoDealerManager.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioRepository.ObterTodosAsync());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_usuarioRepository.ObterPorIdAsync(id));
        }

        public ActionResult DesativarLock(Guid id)
        {
            _usuarioRepository.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}
