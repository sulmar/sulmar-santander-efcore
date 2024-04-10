namespace SakilaConsoleApp.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
