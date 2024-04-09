using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;

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
            var films = db.Films.ToList();

            return films;
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            var films = db.Films.Where(film => film.Title.StartsWith(title)).ToList();

            return films;
        }
    }
}
