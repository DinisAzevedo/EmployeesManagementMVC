using _14530_employes_managment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _14530_employes_managment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Department)
                    .HasConversion<string>()
                    .HasMaxLength(32);

                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Employees_Department",
                    "[Department] IN ('Administration','Engineer','Worker')"));
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.Property(i => i.TypeInstrument)
                    .HasMaxLength(120);

                entity.Property(i => i.InstrumentName)
                    .HasMaxLength(120);
            });
        }
    }
}
