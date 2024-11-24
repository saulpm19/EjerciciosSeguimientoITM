using Microsoft.EntityFrameworkCore;
using Ejercicios.Models;



namespace Ejercicios.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options) { }
        public DbSet<Tarea> Tarea { get; set; }

        public DbSet<Propina> Propina { get; set; }

        public DbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propina>().Property(e => e.PorcentajePropina).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Propina>().Property(e => e.MontoPropina).HasColumnType("decimal(38,2)");
            modelBuilder.Entity<Propina>().Property(e => e.MontoTotalConPropina).HasColumnType("decimal(38,2)");

        }


    }
}
