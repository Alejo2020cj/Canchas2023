using Canchas4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Canchas4.ViewModels
{
    public class CanchaFutSedeVM
    {
     
        public CanchaFut CanchaFut { get; set; }
        public IEnumerable<SelectListItem> ListaCanchaFutSedes { get; set; }

    }
}
