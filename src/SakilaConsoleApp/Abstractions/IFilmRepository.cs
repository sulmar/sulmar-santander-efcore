using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Abstractions
{
    internal interface IFilmRepository
    {
        List<Film> GetFilmsAll();
        List<Film> GetFilmsByTitle(string title);
        List<Film> GetFilmsByRating(string rating);
        List<FilmInfo> GetFilmIGetFilmsAllnfosAll();
        List<RatingStat> GetRatingStatAll();
        void Add(Film film);
        List<FilmAvailability> GetFilmAvailabilityByTitle(string title);
    }
}
