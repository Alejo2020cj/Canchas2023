using Canchas4.Datos;
using Canchas4.Models;
using Canchas4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System;

namespace Canchas4.Controllers
{
    public class ReservaController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Reservas> ListaReserva = _context.Reservas.ToList();
            return View(ListaReserva);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            if (ModelState.IsValid)
            {
                ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();
                reservaCanchasVM.ReservaCanFut = _context.CanchaFut.Select(i =>
                new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.CanchaFutId.ToString()
                });
                if (ModelState.IsValid)
                {
                    //ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();
                    reservaCanchasVM.ReservaCanBolei = _context.CanchVolei.Select(i =>
                    new SelectListItem
                    {
                        Text = i.Nombre,
                        Value = i.CanchaVoleiId.ToString()
                    });


                }
                return View(reservaCanchasVM);
            }

            return View();
        }
        [HttpPost]

        public IActionResult  Crear(Reservas reservas)
        {
            ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();



            List<Reservas> List = _context.Reservas.Where(X => X.CanchaFutId == reservas.CanchaFutId
             && X.FechaInicio == reservas.FechaInicio && X.FechaInicio >= reservas.FechaInicio && X.FechaFin <= reservas.FechaFin && X.FechaFin == reservas.FechaFin
             && X.FechaInicio.Hour >= reservas.FechaInicio.Hour && X.FechaFin.Hour <= reservas.FechaFin.Hour  )
            .OrderBy(X => X.CanchaFutId).OrderBy(X => X.FechaInicio).OrderBy(X => X.FechaFin).ToList();

        

            if (List.Count == 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(reservas);
                    _context.SaveChanges();

                }
                //return reservaCanchasVM;

            }

            ////obtengo lista de reservaciones del dia
            //List<Reservas> ListaReserva2 = _context.Reservas.Where(x => x.FechaInicio
            //== reservas.FechaInicio && x.FechaInicio >= reservas.FechaInicio ||
            //x.FechaFin == reservas.FechaFin && x.FechaFin <= reservas.FechaFin
            //   ).OrderBy(X => X.FechaInicio)
            //.OrderBy(X => X.FechaFin).ToList();


            //if (ListaReserva2.Count == 0)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(reservas);
            //        _context.SaveChanges();

            //    }
            //    //return reservaCanchasVM;

            //}




            //&& 

            //&& x.HoraInicio == reservas.HoraInicio && x.HoraFin
            //== reservas.HoraFin && x.HoraInicio >= reservas.HoraInicio && x.HoraFin <= reservas.HoraFin).OrderBy
            //(x => x.FechaInicio).OrderBy(x => x.HoraInicio).ToList();



            //if (ListaReserva2.Count == 0)
            //    {
            //        if (ModelState.IsValid)
            //        {
            //            _context.Add(reservas);
            //            _context.SaveChanges();

            //        }
            //        //return reservaCanchasVM;

            //    }

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


                //obtengo lista de reservaciones del dia
                //List<Reservas> ListaReserva = _context.Reservas.Where(x => x.FechaInicio 
                //== reservas.FechaInicio && x.FechaFin == reservas.FechaFin && x.CanchaVoleiId
                //== reservas.CanchaVoleiId && x.HoraInicio == reservas.HoraInicio &&
                //x.HoraFin == reservas.HoraFin && x.HoraInicio >= reservas.HoraInicio
                //&& x.HoraFin <= reservas.HoraFin).OrderBy(x => x.FechaInicio).OrderBy(x => x.HoraInicio).ToList();

                //obtengo lista de reservaciones del dia
                //List<Reservas> ListaReserva3 = _context.Reservas.Where(x => x.FechaInicio
                //== reservas.FechaInicio && x.FechaInicio >= reservas.FechaInicio ||
                //x.FechaFin == reservas.FechaFin && x.FechaFin <= reservas.FechaFin
                //&& x.CanchVolei == reservas.CanchVolei).OrderBy(X => X.FechaInicio).OrderBy(X => X.FechaFin).ToList();

                //if (ListaReserva2.Count == 0)
                //{
                //    if (ModelState.IsValid)
                //    {
                //        _context.Add(reservas);
                //        _context.SaveChanges();

                //    }

                //}
                //else if (ListaReserva.Count >= 1)
                //{
                //    ReservaCanchasVM reservaCanchasVM = new ReservaCanchasVM();
                //    reservaCanchasVM.ReservaCanBolei = _context.CanchVolei.Select(i =>
                //    new SelectListItem
                //    {
                //        Text = i.Nombre,
                //        Value = i.CanchaVoleiId.ToString()
                //    });
                   
                //}

               
            


            return View(reservaCanchasVM);
        }
       
    }
}
