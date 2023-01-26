using Canchas4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Canchas4.ViewModels
{
    public class ReservaVoleiVM
    {
        public ReservasVolei ReservasVolei { get; set; }

        public IEnumerable<SelectListItem> ReservaCanBolei { get; set; }



    }

}
