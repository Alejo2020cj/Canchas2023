using Canchas4.Datos;
using Canchas4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Canchas4.Controllers
{
    public class SliderController : Controller
    {
        //Con esto creamos la relación con la base de datos solo queda invocar lo de la tabla
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SliderController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                //Nuevo artículo
                string nombreArchivo = Guid.NewGuid().ToString();
                var subidas = Path.Combine(rutaPrincipal, @"Imagenes\sliders");
                var extension = Path.GetExtension(archivos[0].FileName);

                using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStreams);
                }

                slider.Urllmagen = @"\Imagenes\sliders\" + nombreArchivo + extension;


                _context.Slider.Add(slider);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
       
    }
}
