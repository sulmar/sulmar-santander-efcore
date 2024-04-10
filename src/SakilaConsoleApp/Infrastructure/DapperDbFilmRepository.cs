﻿using Dapper;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using System.Data;

namespace SakilaConsoleApp.Infrastructure
{
    internal class DapperDbCustomerRepository : ICustomerRepository
    {
        private IDbConnection db;

        public DapperDbCustomerRepository(IDbConnection db)
        {
            this.db = db;
        }

        public List<Customer> GetCustomersAll()
        {
            string sql = """
                                SELECT 
                	c.customer_id as CustomerId,
                	c.first_name as FirstName,
                	c.last_name as LastName,
                	c.email,
                	c.address_id AS AddressId,
                	a.address_id AS AddressId,
                	a.address AS AddressLine1,
                	a.city_id AS CityId
                FROM customer AS c
                	INNER JOIN address AS a
                		ON c.address_id = a.address_id
                """;

            var customers = db.Query<Customer, Address, Customer>(sql,
                map: (customer, address) =>
                {
                    customer.Address = address;

                    return customer;
                },
                splitOn: "AddressId"
                )                
                .AsList();

            return customers;



        }
    }

    // dotnet add package Dapper
    internal class DapperDbFilmRepository : IFilmRepository
    {
        private IDbConnection db;

        public DapperDbFilmRepository(IDbConnection db)
        {
            this.db = db;    
        }

        public List<FilmInfo> GetFilmIGetFilmsAllnfosAll()
        {
            throw new NotImplementedException();
        }

        public List<Film> GetFilmsAll()
        {
            string sql = """
                    SELECT 
	                    f.film_id as FilmId, 
	                    f.title, 
	                    f.description, 
                        f.language_id as LanguageId,
	                    l.language_id as LanguageId,
	                    l.name as [Name]
                    FROM [film] as f
                    JOIN [language] AS l
	                    ON f.language_id = l.language_id
""";

            var films = db.Query<Film, Language, Film>(sql, 
                map: (film, language) =>
                {
                    film.Language = language;

                    return film;
                },
                
                splitOn: "LanguageId"
                ).AsList();

            return films;
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            const string sql = "SELECT film_id as FilmId, title, description FROM [film] WHERE title LIKE @title + '%'";

            // Przekazywanie parametrów poprzez DynamicParameters
            // var parameters = new DynamicParameters();
            // parameters.Add("@title", title);

            // Przekazywanie parametrów poprzez typ anonimowy
            var parameters = new { title };

            var films = db.Query<Film>(sql, parameters).AsList();

            return films;

        }
    }
}
