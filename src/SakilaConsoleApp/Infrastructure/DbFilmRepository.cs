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

        public List<Film> GetAll()
        {
            var films = db.Films.ToList();

            return films;
        }
    }

    internal class FakeFilmRepository : IFilmRepository
    {
        public List<Film> GetAll()
        {
            return new List<Film>
            {
                new Film { FilmId = 1, Title = "A"},
                new Film { FilmId = 2, Title = "B"},
                new Film { FilmId = 3, Title = "C"},
            };
        }
    }
}
