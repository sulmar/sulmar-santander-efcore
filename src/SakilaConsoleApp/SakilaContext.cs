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
                .HasKey(p => p.FilmId); // Mapowanie klucza podstawowego PK (Primary Key)

            modelBuilder.Entity<Film>()
                .ToTable("film");  // Mapowanie nazwy tabeli

            modelBuilder.Entity<Film>()
                .Property(p => p.FilmId).HasColumnName("film_id"); // Mapowanie nazwy pola

            modelBuilder.Entity<Film>()
                .Property(p => p.ReleaseYear).HasColumnName("release_year");

            modelBuilder.Entity<Film>()
                .Property(p => p.RentalDuration).HasColumnName("rental_duration");

            modelBuilder.Entity<Film>()
                .Property(p => p.RentalRate).HasColumnName("rental_rate");

            modelBuilder.Entity<Film>()
                .Property(p => p.ReplacementCost).HasColumnName("replacement_cost");

            modelBuilder.Entity<Film>()
                .Property(p => p.LastUpdate).HasColumnName("last_update");

            modelBuilder.Entity<Film>()
                .Property(p => p.LanguageId).HasColumnName("language_id");

            modelBuilder.Entity<Language>()
                .Property(p => p.LanguageId).HasColumnName("language_id");
        } 


    }
}
