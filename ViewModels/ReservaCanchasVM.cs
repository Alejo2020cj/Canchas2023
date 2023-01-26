using Canchas4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Canchas4.ViewModels
{
    public class ReservaCanchasVM
    {
        public Reservas Reservas { get; set; }

        public IEnumerable<SelectListItem> ReservaCanFut { get; set; }
        public IEnumerable<SelectListItem> ReservaCanBolei { get; set; }



    }

}
