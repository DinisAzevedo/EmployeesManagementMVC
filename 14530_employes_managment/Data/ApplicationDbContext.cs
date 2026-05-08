using _14530_employes_managment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _14530_employes_managment.Data
{
    // Contexto central do Entity Framework: liga modelos C# a tabelas SQL Server.
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tabela principal do modulo de gestao de empregados.
        public DbSet<Employee> Employees { get; set; }
    }
}
