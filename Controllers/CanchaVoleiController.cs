using Canchas4.Datos;
using Canchas4.Models;
using Canchas4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Canchas4.Controllers
{
    public class CanchaVoleiController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public CanchaVoleiController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CanchVolei> listaCanchas = _context.CanchVolei.ToList();
            return View(listaCanchas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CanchasVoleiVM canchasVoleiVM = new CanchasVoleiVM();
            canchasVoleiVM.ListaCanchaVoleiSedes = _context.Sede.Select(i =>
            new SelectListItem

            {
                Text = i.Nombre,
                Value = i.SedeId.ToString()
            });

            return View(canchasVoleiVM);

        }

        [HttpPost]
        public IActionResult Crear(CanchVolei canchVolei)
        {
            if (!ModelState.IsValid || canchVolei.Nombre == null)
            {
                CanchasVoleiVM canchasVoleiVM = new CanchasVoleiVM();
                canchasVoleiVM.ListaCanchaVoleiSedes = _context.Sede.Select(i =>
                new SelectListItem

                {
                    Text = i.Nombre,
                    Value = i.SedeId.ToString()
                });

                return View(canchasVoleiVM);
            }


            int nveses = 0;
            nveses = _context.CanchVolei.Where(p=>p.Nombre.ToUpper().Trim()==canchVolei.Nombre.ToUpper().Trim()).Count();

            if (!ModelState.IsValid || nveses>=1)
            {
                if (nveses >= 1) canchVolei.mensajeError = "El nombre ya esiste";
                CanchasVoleiVM canchasVoleiVM = new CanchasVoleiVM();
                canchasVoleiVM.ListaCanchaVoleiSedes = _context.Sede.Select(i =>
                new SelectListItem

                {
                    Text = i.Nombre,
                    Value = i.SedeId.ToString()
                });

                return View(canchasVoleiVM);


            } 
           else if (ModelState.IsValid)
            {
                _context.Add(canchVolei);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}