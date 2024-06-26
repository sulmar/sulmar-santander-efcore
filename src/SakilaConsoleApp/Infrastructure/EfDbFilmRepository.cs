﻿using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using Microsoft.EntityFrameworkCore;

namespace SakilaConsoleApp.Infrastructure
{

    internal class EfDbFilmRepository : IFilmRepository
    {
        private SakilaContext db;

        public EfDbFilmRepository(SakilaContext db)
        {
            this.db = db;
        }

        public void Add(Film film)
        {
            db.Films.Add(film);

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            db.SaveChanges();
        }

        public List<FilmAvailability> GetFilmAvailabilityByTitle(string title)
        {
            var result = db.Inventories
                .Include(i => i.Film)
                .Include(i => i.Store)
                    .ThenInclude(s => s.Address)
                        .ThenInclude(a => a.City)
                        .Where(i => i.Film.Title.Contains(title))
                        .GroupBy(i => new { i.Film.Title, i.Store.Address.City.Name })
                        .Select(g =>
                            new FilmAvailability { Title = g.Key.Title, City = g.Key.Name, InventoryStack = g.Count() })
                        .OrderBy(r => r.Title)
                .ToList();

            return result;


        }

        public List<FilmInfo> GetFilmIGetFilmsAllnfosAll()
        {
            // Przygotowanie wyrażenia
            var filmInfos = db.Films
                .Select(film => new FilmInfo        // Projekcja
                {
                    Title = film.Title,
                    Description = film.Description,
                    ReleaseYear = film.ReleaseYear
                }).ToList();

            return filmInfos;
        }

        public List<Film> GetFilmsAll()
        {
            // Zachłanne pobieranie powiązanego obiektu
            var films = db.Films
                .OrderByDescending(f => f.ReleaseYear)
                .TagWith(nameof(GetFilmsAll))
                .ToList();

            return films;
        }

        public List<Film> GetFilmsByRating(string rating)
        {
            var films = db.Films
                .Where(film => film.Rating == rating)
                .TagWith(nameof(GetFilmsByRating))
                .ToList();

            return films;
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            var films = db.Films
                .Include(f => f.Language)
                .Where(film => film.Title.StartsWith(title))
                .TagWith(nameof(GetFilmsByTitle))
                .ToList();

            return films;
        }

        public List<RatingStat> GetRatingStatAll()
        {
            var results = db.Films
                .GroupBy(f => f.Rating) 
                .Select(g => new RatingStat { Rating = g.Key, Count = g.Count() })
                .TagWith(nameof(GetRatingStatAll))
                .ToList();

          return results;
        }
    }
}
