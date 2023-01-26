using Canchas4.Datos;
using Canchas4.Models;
using Canchas4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Canchas4.Controllers
{
    public class CanchaFutController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public CanchaFutController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CanchaFut> listaCanchas = _context.CanchaFut.ToList();
            return View(listaCanchas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CanchaFutSedeVM canchaFutSedeVM = new CanchaFutSedeVM();
            canchaFutSedeVM.ListaCanchaFutSedes = _context.Sede.Select(i =>
            new SelectListItem

            {
                Text = i.Nombre,
                Value = i.SedeId.ToString()
            });

            return View(canchaFutSedeVM);

        }

        [HttpPost]
        public IActionResult Crear(CanchaFut canchaFut)
        {
            if (!ModelState.IsValid || canchaFut.Nombre == null)
            {
                CanchaFutSedeVM canchaFutSedeVM = new CanchaFutSedeVM();
                canchaFutSedeVM.ListaCanchaFutSedes = _context.Sede.Select(i =>
                new SelectListItem

                {
                    Text = i.Nombre,
                    Value = i.SedeId.ToString()
                });

                return View(canchaFutSedeVM);
            }

            int nveces = 0;
            nveces = _context.CanchaFut.Where(p => p.Nombre.ToUpper().Trim() == canchaFut.Nombre.ToUpper().Trim()).Count();

            if (!ModelState.IsValid || nveces >= 1 || canchaFut.Nombre == null)
            {

                if (nveces >= 1) canchaFut.mensajeError = "El nombre ya existe";
                CanchaFutSedeVM canchaFutSedeVM = new CanchaFutSedeVM();
                canchaFutSedeVM.ListaCanchaFutSedes = _context.Sede.Select(i =>
                new SelectListItem

                {
                    Text = i.Nombre,
                    Value = i.SedeId.ToString()
                });

                return View(canchaFutSedeVM);
            }
            else if (ModelState.IsValid)
            {
                _context.Add(canchaFut);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}