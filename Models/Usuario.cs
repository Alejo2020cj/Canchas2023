using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Canchas4.Models
{
    public class Usuario
    {
        [Key]
        public int? UsuarioId { get; set; }
        [Required(ErrorMessage = "Ingrese su nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese Su apellido")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido")]
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }

        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "Ingrese su Corre electronico")]
        [EmailAddress(ErrorMessage = ("Por favor ingrese un Email correcto"))]
        public string Coreo { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int? Celular { get; set; }
        public List<Reservas> Reservas { get; set; }
    }
}
