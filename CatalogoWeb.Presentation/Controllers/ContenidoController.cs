using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.Business;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Presentation.Controllers
{
    public class ContenidoController : Controller
    {
        private readonly IContenidoService _service;

        public ContenidoController(IContenidoService service)
        {
            _service = service;
        }

        public IActionResult Index(string titulo, TipoContenido? tipo, string genero)
        {
            var lista = _service.Buscar(titulo, tipo, genero);
            ViewBag.TituloBuscado = titulo;
            ViewBag.TipoSeleccionado = tipo;
            ViewBag.GeneroBuscado = genero;
            return View(lista);
        }

        public IActionResult Crear() => View(new Contenido());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Contenido contenido)
        {
            if (!ModelState.IsValid) return View(contenido);

            var errores = _service.Registrar(contenido);
            if (errores.Count > 0)
            {
                foreach (var error in errores) ModelState.AddModelError(string.Empty, error);
                return View(contenido);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var contenido = _service.ObtenerPorId(id);
            if (contenido == null) return NotFound();
            return View(contenido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Contenido contenido)
        {
            contenido.Id = id;
            if (!ModelState.IsValid) return View(contenido);

            var errores = _service.Editar(contenido);
            if (errores.Count > 0)
            {
                foreach (var error in errores) ModelState.AddModelError(string.Empty, error);
                return View(contenido);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalles(int id)
        {
            var contenido = _service.ObtenerPorId(id);
            if (contenido == null) return NotFound();
            return View(contenido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id, EstadoContenido estado)
        {
            _service.CambiarEstado(id, estado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Estadisticas() => View(_service.ObtenerEstadisticas());
    }
}