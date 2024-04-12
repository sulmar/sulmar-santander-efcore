namespace SakilaConsoleApp.Model
{
    public partial class Store
    {
        public int StoreId { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;

    }
}
