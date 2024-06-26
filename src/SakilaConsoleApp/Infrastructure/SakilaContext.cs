﻿using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Infrastructure
{
    internal class SakilaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

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

            modelBuilder.Entity<Customer>()
              .HasKey(p => p.CustomerId); // Mapowanie klucza podstawowego PK (Primary Key)

            modelBuilder.Entity<Customer>()
                .ToTable("customer");  // Mapowanie nazwy tabeli

            modelBuilder.Entity<Customer>()
                .Property(p => p.CustomerId).HasColumnName("customer_id");

            modelBuilder.Entity<Customer>()
                .Property(p => p.FirstName).HasColumnName("first_name");

            modelBuilder.Entity<Customer>()
                .Property(p => p.LastName).HasColumnName("last_name");

            modelBuilder.Entity<Customer>()
              .Property(p => p.AddressId).HasColumnName("address_id");

            modelBuilder.Entity<Address>()
                .Property(p => p.AddressId).HasColumnName("address_id");

            modelBuilder.Entity<Address>()
                .Property(p => p.AddressLine1).HasColumnName("address");

            modelBuilder.Entity<Address>()
                .Property(p => p.AddressLine2).HasColumnName("address2");

            modelBuilder.Entity<Address>()
                .Property(p => p.PostalCode).HasColumnName("postal_code");

            modelBuilder.Entity<Address>()
               .Property(p => p.CityId).HasColumnName("city_id");

            modelBuilder.Entity<City>()
                .Property(p => p.CityId).HasColumnName("city_id");

            modelBuilder.Entity<City>()
                .Property(p => p.Name).HasColumnName("city");

            // Włącza automatyczne pobieranie encji zależnej (Include)
            modelBuilder.Entity<Film>()
                .Navigation(p => p.Language).AutoInclude();


            modelBuilder.Entity<Language>()
                .ToTable("language");

            modelBuilder.Entity<Language>()
               .HasKey(p=>p.LanguageId);

            modelBuilder.Entity<Language>()
                .Property(p=>p.LanguageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("language_id");


            modelBuilder.Entity<Inventory>()
                .ToTable("inventory");

            modelBuilder.Entity<Inventory>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");

            modelBuilder.Entity<Inventory>()
                .Property(p => p.FilmId)
                .HasColumnName("film_id");

            modelBuilder.Entity<Store>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");

            modelBuilder.Entity<Store>()
                .Property(p => p.AddressId)
                .HasColumnName("address_id");

        }


    }
}
