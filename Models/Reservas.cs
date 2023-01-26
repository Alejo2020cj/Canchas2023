using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Canchas4.Models
{
    public class Reservas
    {
        [Key]

        [Display(Name ="ID")]
        public int ReservaId { get; set; }

        [Required(ErrorMessage ="Ingrese Fecha de inicio")]
        //[DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }
 
        [Required(ErrorMessage = "Ingrese fecha de finalización")]
        //[DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Ingrese Hora de inicio")]
        [Display(Name = "Hora Inicio")]
        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Ingrese hora de finalización")]
        [Display(Name = "Hora Fin")]
        [DataType(DataType.Time)]
       
        public DateTime HoraFin { get; set; }

        [ForeignKey("CanchaFut")]
        [Display(Name = "ID Cancha Futbol")]
        public int? CanchaFutId { get; set; }    
        public CanchaFut CanchaFut { get; set; }

        [ForeignKey("CanchVolei")]
        [Display(Name = "ID Cancha Boleivol")]
        public int? CanchaVoleiId { get; set; }
        [Display(Name = "ID Cancha Boleivol")]
        public CanchVolei CanchVolei { get; set; }

        [ForeignKey("Usuario")]
       
        public int? UsuarioId { get; set; }
        [Display(Name = "ID De usuario")]
        public Usuario Usuario { get; set; }


    }
}
