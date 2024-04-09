using Microsoft.EntityFrameworkCore;

namespace SakilaConsoleApp.Infrastructure
{
    internal class SakilaContextFactory
    {
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer

        public static SakilaContext Create()
        {
            string connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            var options = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;

            var context = new SakilaContext(options);

            return context;
        }
    }
}
