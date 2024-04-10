using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Infrastructure;

Console.WriteLine("Hello, EF Core!");

// TODO: Pobierz listą filmów z bazy danych Sakila 

//var context = SakilaContextFactory.Create();
//IFilmRepository filmRepository = new EfDbFilmRepository(context);

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

IFilmRepository filmRepository = FilmRepositoryFactory.Create(ProviderType.EFCore, connectionString);

var films = filmRepository.GetFilmsByTitle("AL");

foreach (var film in films)
{
    Console.WriteLine($"{film.Title}, {film.Description}, {film.ReleaseYear}, {film.Language.Name}");
}


