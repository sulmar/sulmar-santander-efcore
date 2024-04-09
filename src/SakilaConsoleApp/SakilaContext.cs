using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp.Model;

namespace SakilaConsoleApp
{
    internal class SakilaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public SakilaContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasKey(p => p.film_id); // Mapowanie klucza podstawowego PK (Primary Key)

            modelBuilder.Entity<Film>()
                .ToTable("film");  // Mapowanie nazwy tabeli
        }


    }
}
