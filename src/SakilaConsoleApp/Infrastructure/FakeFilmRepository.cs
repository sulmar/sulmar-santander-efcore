using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Infrastructure
{
    internal class FakeFilmRepository : IFilmRepository
    {
        public List<Film> GetFilmsAll()
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
