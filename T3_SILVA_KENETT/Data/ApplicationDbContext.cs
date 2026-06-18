using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T3_SILVA_KENETT.Models;

namespace T3_SILVA_KENETT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tabla Libros en la base de datos
        public DbSet<Libro> Libros { get; set; }
    }
}