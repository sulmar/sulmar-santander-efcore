using ScaffoldSakilaConsoleApp;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Linq;

Console.WriteLine("Hello, EF Core!");

SakilaContext db = new SakilaContext();

//var films = db.Films
//    .Include(f => f.Language)
//    .ToList();

//foreach (var film in films)
//{
//    Console.WriteLine($"{film.Title} {film.Description} {film.Language.Name}");
//}


var result = db.Inventories
    .Include(i => i.Film)
    .Include(i => i.Store)
        .ThenInclude(s => s.Address)
            .ThenInclude(a => a.City)
                .GroupBy(i => new  { i.Film.Title, i.Store.Address.City.City1 })
                .Select(g => 
                    new { FilmTitle = g.Key.Title, City = g.Key.City1, InventoryStack = g.Count() })
                .OrderBy(r => r.FilmTitle)
    .ToList(); 


foreach (var item in result)
{ 
    Console.WriteLine($"FilmTitle: {item.FilmTitle}, City: {item.City}, InventoryStack: {item.InventoryStack}"); 
}


string title = "AFFAIR PREJUDICE";

var query11 = db.Films.Where(f => f.Title.Contains(title));

var query12 = query11.OrderBy(q => q.Rating);

var results = query12
    .ToList();



var query1 = db.Inventories
    .Where(i => i.Film.Title.Contains(title))
    .GroupBy(g => g.Store.Address.City)
    .Select(g => new { City = g.Key.City1, Count = g.Count() })
    .ToList();


var query2a = db.Films
    .Include(f => f.Inventories)
        .ThenInclude(i => i.Store)
            .ThenInclude(s => s.Address)
                .ThenInclude(a => a.City)
    .Where(f => f.Title.Contains(title))
    .TagWith("query2")
    .ToList();

var query2b = query2a
    .SelectMany(f => f.Inventories)
    .GroupBy(g => new { g.Film.Title, g.Store.Address.City })
    .Select(g => new { City = g.Key.City.City1, Count = g.Count() })
    .ToList();

// W przypadku grupowania nie trzeba stosować Include


var sql = $@"
    select  
	f.title as FilmTitle, 
	ct.city as City, 
	count(i.inventory_id) as InventoryStack
from film f
join  inventory i 
on f.film_id = i.film_id
join store s 
on i.store_id =s.store_id
join address a
on a.address_id = s.address_id
join city ct
on a.city_id = ct.city_id
where f.title = '{title}'
group by f.title, ct.city
order by f.title
    ";

Console.WriteLine(sql);

// SQL Injection
// http://domain.com/search?city=Warszawa';DROP TABLE Users;


// TODO: Sprawdzić czy jest podatne na SQL Injection
var queryRawSql = db.Database.SqlQueryRaw<ResultInventory>(sql).ToList();



// Select

var query4 = db.Films
    .Where(f => f.Title.Contains(title))
    .Select(f => new { f, f.Inventories })
    .ToList();

// SelectMany

var query3 = db.Films
    .Where(f => f.Title.Contains(title))
    .SelectMany(f => f.Inventories)
    .ToList();

Console.ReadLine();


