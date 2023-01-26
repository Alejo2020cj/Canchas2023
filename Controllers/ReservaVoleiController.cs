using Canchas4.Datos;
using Canchas4.Models;
using Canchas4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

namespace Canchas4.Controllers
{
    public class ReservaVoleiController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public ReservaVoleiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Reservas> ListaReserva2 = _context.Reservas.ToList();
            return View(ListaReserva2);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            if (ModelState.IsValid)
            {
                ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();
                reservaCanchasVM.ReservaCanBolei = _context.CanchVolei.Select(i =>
                new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.CanchaVoleiId.ToString()
                });

                return View(reservaCanchasVM);
            }

            return View();
        }
        [HttpPost]

        public IActionResult Crear(Reservas reservas)
        {
            ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();

                //obtengo lista de reservaciones del dia
                List<Reservas> ListaReserva2 = _context.Reservas.Where(X => X.CanchaFutId == reservas.CanchaFutId && X.FechaInicio
                == reservas.FechaInicio && X.FechaInicio >= reservas.FechaInicio ||
                X.FechaFin == reservas.FechaFin && X.FechaFin <= reservas.FechaFin 
              ).OrderBy(X=>X.FechaInicio).OrderBy(X=>X.FechaFin).OrderBy(X=>X.CanchaFutId).ToList();

            foreach (var Recor in ListaReserva2 )
            {
                Recor.CanchaFutId.Value.CompareTo(ListaReserva2);
               
            
            
            }

                if (ListaReserva2.Count == 0)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(reservas);
                        _context.SaveChanges();

                    }
                    //return reservaCanchasVM;

                }

                if (ModelState.IsValid)
                {
                 
                    reservaCanchasVM.ReservaCanFut = _context.CanchaFut.Select(i =>
                    new SelectListItem
                    {
                        Text = i.Nombre,
                        Value = i.CanchaFutId.ToString()
                    });
                
                   
                    //return View(reservaCanchasVM);
                }
            


            return View(reservaCanchasVM);
        }
       
    }
}
