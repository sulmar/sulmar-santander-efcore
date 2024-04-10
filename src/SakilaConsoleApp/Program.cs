using Microsoft.Data.SqlClient;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Infrastructure;

Console.WriteLine("Hello, EF Core!");

// TODO: Pobierz listą filmów z bazy danych Sakila 

//var context = SakilaContextFactory.Create();
//IFilmRepository filmRepository = new EfDbFilmRepository(context);

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

IFilmRepository filmRepository = FilmRepositoryFactory.Create(ProviderType.Dapper, connectionString);

var films = filmRepository.GetFilmsAll();

foreach (var film in films)
{
    Console.WriteLine($"{film.Title}, {film.Description}, {film.ReleaseYear}, {film.Language.Name}");
}

//ICustomerRepository customerRepository = new EfDbCustomerRepository(SakilaContextFactory.Create(connectionString));

ICustomerRepository customerRepository = new DapperDbCustomerRepository(new SqlConnection(connectionString));

var customers = customerRepository.GetCustomersAll();

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.Address.AddressLine1} {customer.Address.AddressLine2} {customer.Address.PostalCode} {customer.Address.Phone}");
}

