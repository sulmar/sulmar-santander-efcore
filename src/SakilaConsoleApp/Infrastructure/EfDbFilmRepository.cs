using SakilaConsoleApp.Abstractions;
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
            var films = db.Films.Include(f => f.Language).ToList();

            return films;
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            var films = db.Films.Include(f => f.Language).Where(film => film.Title.StartsWith(title)).ToList();

            return films;
        }
    }
}
