using Canchas4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Canchas4.ViewModels
{
    public class CanchasVoleiVM
    {
        public CanchVolei CanchVolei { get; set; }
        public IEnumerable<SelectListItem> ListaCanchaVoleiSedes { get; set; }
    }
}
