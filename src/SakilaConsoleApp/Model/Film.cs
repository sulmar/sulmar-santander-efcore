using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Model
{

    internal class Film
    {
        public int FilmId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ReleaseYear { get; set; }        
        public byte LanguageId { get; set; }    // FK
        public Language Language { get; set; }  // Powiązana encja (Navigation Property)
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length {  get; set; }
        public decimal ReplacementCost { get; set; }
        public string? Rating { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
