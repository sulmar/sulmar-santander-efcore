using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp.Abstractions;
using System.Data;

namespace SakilaConsoleApp.Infrastructure
{
    internal class SakilaContextFactory
    {
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer

        public static SakilaContext Create(string connectionString)
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;

            var context = new SakilaContext(options);

            return context;
        }
    }

    internal class FilmRepositoryFactory
    {
        public static IFilmRepository Create(ProviderType source, string connectionString)
        {
            switch(source)
            {
                case ProviderType.Dapper: return DapperDbFilmRepository(connectionString);
                case ProviderType.EFCore: return EfDbFilmRepository(connectionString);

                default: throw new NotSupportedException();
            }
        }

        private static IFilmRepository EfDbFilmRepository(string connectionString)
        {
            var context = SakilaContextFactory.Create(connectionString);
            IFilmRepository filmRepository = new EfDbFilmRepository(context);

            return filmRepository;
        }

        private static IFilmRepository DapperDbFilmRepository(string connectionString)
        {
            
            IDbConnection connection = new SqlConnection(connectionString);
            IFilmRepository filmRepository = new DapperDbFilmRepository(connection);

            return filmRepository;
        }
    }


    enum ProviderType
    {
        Dapper,
        EFCore
    }
    
}
