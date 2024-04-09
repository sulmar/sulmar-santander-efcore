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

        public List<Film> GetFilmsAll()
        {
            var films = db.Films.ToList();

            return films;
        }
    }
}
