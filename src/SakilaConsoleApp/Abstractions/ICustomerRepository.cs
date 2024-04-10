using SakilaConsoleApp.Model;

namespace SakilaConsoleApp.Abstractions
{
    internal interface ICustomerRepository
    {
        List<Customer> GetCustomersAll();
    }
}
