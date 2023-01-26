using Canchas4.Datos;
using Canchas4.Models;
using Canchas4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Canchas4.Controllers
{
    public class UsuarioController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            List<Usuario> ListaUsuario = _context.Usuario.ToList();
            return View(ListaUsuario);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Editar(int? UsuarioId)
        {
            if (UsuarioId == null)
            {
                return View();
            }

            var usuario = _context.Usuario.FirstOrDefault(c => c.UsuarioId == UsuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (usuario.UsuarioId == 0)
            {
                return View(usuario);

            }
            else
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var User = _context.Usuario.FirstOrDefault(c => c.UsuarioId == id);
            _context.Usuario.Remove(User);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
