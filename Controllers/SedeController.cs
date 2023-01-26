using Canchas4.Datos;
using Canchas4.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Canchas4.Controllers
{
    public class SedeController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public SedeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Sede> ListaSedes = _context.Sede.ToList();
            return View(ListaSedes);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Sede sede)
        {
            if (!ModelState.IsValid || sede.Nombre == null)
            {
                return View(sede);
            }

            int nveses = 0;
            nveses = _context.Sede.Where(p => p.Nombre.ToUpper().Trim() == sede.Nombre.ToUpper().Trim()).Count();

            if (!ModelState.IsValid || nveses >= 1)
            {
                if (nveses >= 1)
                    return View(sede);

            }
            else if (ModelState.IsValid)
            {
                _context.Sede.Add(sede);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}
