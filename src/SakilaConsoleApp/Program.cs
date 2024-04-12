using Microsoft.Data.SqlClient;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Infrastructure;
using SakilaConsoleApp.Model;

Console.WriteLine("Hello, EF Core!");

// TODO: Pobierz listą filmów z bazy danych Sakila 

//var context = SakilaContextFactory.Create();
//IFilmRepository filmRepository = new EfDbFilmRepository(context);

string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Application Name=SakilaConsoleApp";

var context = SakilaContextFactory.Create(connectionString);

IFilmRepository filmRepository = new EfDbFilmRepository(context);
var results = filmRepository.GetFilmAvailabilityByTitle("bingo");


ILanguageRepository languageRepository = new EfDbLanguageRepository(context);

var languages = languageRepository.GetAllLanguages();

Console.WriteLine("Wybierz język: ");
foreach(var language in languages)
{
    Console.WriteLine(language.Name);
}

string selectedLanguageName = Console.ReadLine();

var selectedLanguage = languages.Single(l => l.Name.TrimEnd() == selectedLanguageName);

// Language language = new Language { Name = "Polish" };
// languageRepository.Add(language);

// IFilmRepository filmRepository = FilmRepositoryFactory.Create(ProviderType.EFCore, connectionString);



Film newFilm = new Film
{
    Title = "EFCore in Action",
    Description = "Lorem ipsum",
    Language = selectedLanguage,
    Rating = "PG",
    ReleaseYear = "2024",
    RentalDuration = 3,
    Length = 120,
    RentalRate = 1m,
    ReplacementCost = 2m,    
    LastUpdate = DateTime.Now
};

filmRepository.Add(newFilm);

//var films = filmRepository.GetFilmsByRating("PG-13");

var ratingstats = filmRepository.GetRatingStatAll();

var films = filmRepository.GetFilmsAll();

foreach (var film in films)
{
    Console.WriteLine($"{film.Title}, {film.Description}, {film.ReleaseYear}, {film.Language.Name}");
}
 
//ICustomerRepository customerRepository = new EfDbCustomerRepository(SakilaContextFactory.Create(connectionString));

ICustomerRepository customerRepository = new DapperDbCustomerRepository(new SqlConnection(connectionString));

var customers = customerRepository.GetCustomersByFirstName("Tom");

foreach (var customer in customers)
{
    Console.WriteLine($"{customer.Address.AddressLine1} {customer.Address.AddressLine2} {customer.Address.PostalCode} {customer.Address.Phone}");
}

