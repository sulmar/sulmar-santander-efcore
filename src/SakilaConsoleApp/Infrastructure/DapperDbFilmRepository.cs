using Dapper;
using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var films = db.Query<Film>(sql).ToList();

            return films;
        }

        public List<Film> GetFilmsByTitle(string title)
        {
            const string sql = "SELECT * FROM [film] WHERE title LIKE @title + '%'";

            var parameters = new DynamicParameters();
            parameters.Add("@title", title);

            var films = db.Query<Film>(sql, parameters).ToList();

            return films;

        }
    }
}
