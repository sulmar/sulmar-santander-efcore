using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Abstractions
{
    internal interface IFilmRepository
    {
        List<Film> GetFilmsAll();
        List<Film> GetFilmsByTitle(string title);
        List<FilmInfo> GetFilmIGetFilmsAllnfosAll();
    }
}
