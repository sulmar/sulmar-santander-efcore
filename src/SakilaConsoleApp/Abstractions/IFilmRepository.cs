using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Abstractions
{
    internal interface IFilmRepository
    {
        List<Film> GetFilmsAll();
    }
}
