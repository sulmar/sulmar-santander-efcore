using Dapper;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using System.Data;

namespace SakilaConsoleApp.Infrastructure
{
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
            string sql = "SELECT * FROM [film]";

            var films = db.Query<Film>(sql).AsList();

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
