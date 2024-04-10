using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Infrastructure
{
    internal class FakeFilmRepository : IFilmRepository
    {
        public List<FilmInfo> GetFilmIGetFilmsAllnfosAll()
        {
            throw new NotImplementedException();
        }

        public List<Film> GetFilmsAll()
        {
            return new List<Film>
            {
                new Film { FilmId = 1, Title = "A"},
                new Film { FilmId = 2, Title = "B"},
                new Film { FilmId = 3, Title = "C"},
            };
        }

        public List<Film> GetFilmsByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<RatingStat> GetRatingStatAll()
        {
            throw new NotImplementedException();
        }
    }
}
