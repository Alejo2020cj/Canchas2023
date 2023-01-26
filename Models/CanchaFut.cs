using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canchas4.Models
{
    public class CanchaFut
    {
        [Key]
        [Display(Name = "ID")]
        public int CanchaFutId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese la descripción")]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }
        public string mensajeError { get; set; }

        [ForeignKey("Sede")]

        [Display(Name = "ID Sede")]
        public int? SedeId { get; set; }
        public Sede Sede { get; set; }
        public List<Reservas> Reservas { get; set; }
    }
}
