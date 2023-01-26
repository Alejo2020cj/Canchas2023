﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Canchas4.Models
{
    public class Slider
    {

        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para el slider")]
        [Display(Name = "Nombre del Slider")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Urllmagen { get; set; }
    }
}

