using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Infrastructure;

Console.WriteLine("Hello, EF Core!");

// TODO: Pobierz listą filmów z bazy danych Sakila 

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

var options = new DbContextOptionsBuilder()
    .UseSqlServer(connectionString)
    .Options;

var context = new SakilaContext(options);

IFilmRepository filmRepository = new DbFilmRepository(context);

var films = filmRepository.GetAll();

foreach (var film in films)
{
    Console.WriteLine($"{film.FilmId}, {film.Title}, {film.Description}");
}


