using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using Microsoft.EntityFrameworkCore;

namespace SakilaConsoleApp.Infrastructure
{
    internal class EfDbCustomerRepository : ICustomerRepository
    {
        private SakilaContext db;

        public EfDbCustomerRepository(SakilaContext db)
        {
            this.db = db;
        }

        public List<Customer> GetCustomersAll()
        {
            return db.Customers
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                
                .ToList();
        }

        public List<Customer> GetCustomersByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }
    }
}
