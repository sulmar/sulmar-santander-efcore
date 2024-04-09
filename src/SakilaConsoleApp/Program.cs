using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Infrastructure;

Console.WriteLine("Hello, EF Core!");

// TODO: Pobierz listą filmów z bazy danych Sakila 


var context = SakilaContextFactory.Create();

IFilmRepository filmRepository = new DbFilmRepository(context);

var films = filmRepository.GetFilmIGetFilmsAllnfosAll();

foreach (var film in films)
{
    Console.WriteLine($"{film.Title}, {film.Description}, {film.ReleaseYear}");
}


