using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Canchas4.Models
{
    public class Sede
    {
        [Key]
        public int? SedeId { get; set; }
        //[Required(ErrorMessage = "Se requiere El nombre")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage ="Requiere dirección")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public string MenssajeError { get; set; }

        public List<CanchaFut> CanchaFut { get; set; }
        public List<CanchVolei> CanchVolei { get; set; }
    }
}
