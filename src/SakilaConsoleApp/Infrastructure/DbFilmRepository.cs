using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Infrastructure
{
    internal class DbFilmRepository : IFilmRepository
    {
        private SakilaContext db;

        public DbFilmRepository(SakilaContext context)
        {
            this.db = context;    
        }

        public List<FilmInfo> GetFilmIGetFilmsAllnfosAll()
        {
            // Przygotowanie wyrażenia
            IQueryable<FilmInfo> query = db.Films
                .Select(film => new FilmInfo        // Projekcja
                {
                    Title = film.Title,
                    Description = film.Description,
                    ReleaseYear = film.ReleaseYear
                });

            // Wykonanie wyrażenia (materializacja)
            // W tym miejscu zostanie utworzone zapytanie SQL i wysłane do bazy danych
            List<FilmInfo> filmInfos = query.ToList();

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
