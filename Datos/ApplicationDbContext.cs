using Canchas4.Models;
using Microsoft.EntityFrameworkCore;

namespace Canchas4.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<CanchaFut> CanchaFut { get; set; }
        public DbSet<CanchVolei> CanchVolei { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<ReservasVolei> ReservasVolei { get; set; }
        public DbSet<Slider> Slider { get; set; }
        //public DbSet<Canchas4.Models.ReservasVolei> ReservasVolei { get; set; }


    }
}
