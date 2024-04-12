namespace SakilaConsoleApp.Model
{
    internal class Inventory
    {
        public int InventoryId { get; set; }

        public int FilmId { get; set; }

        public int StoreId { get; set; }

        public Film Film { get; set; } = null!;

        public Store Store { get; set; } = null!;
    }
}
