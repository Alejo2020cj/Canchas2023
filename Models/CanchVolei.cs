using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Canchas4.Models
{
    public class CanchVolei
    {
        [Key]

        [Display(Name ="ID")]
        public int CanchaVoleiId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese la descripción")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string mensajeError { get; set; }

        [ForeignKey("Sede")]

        [Display(Name = "Id Sede")]
        public int? SedeId { get; set; }
        public Sede Sede { get; set; }
        public List<Reservas> Reservas { get; set; }
    }
}
