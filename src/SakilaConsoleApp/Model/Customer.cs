namespace SakilaConsoleApp.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
    }
}
