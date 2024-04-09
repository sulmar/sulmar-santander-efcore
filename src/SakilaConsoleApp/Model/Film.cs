using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Model
{
    internal class Film
    {
        public int film_id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public string? release_year { get; set; }
        public byte language_id { get; set; }
        public byte rental_duration { get; set; }
        public decimal rental_rate { get; set; }
        public short? length {  get; set; }
        public decimal replacement_cost { get; set; }
        public string? rating { get; set; }
        public DateTime last_update { get; set; }

        // Mapowanie typów
        // | -----------| --------------|
        // | SQL        | C#            |
        // | -----------| --------------|
        // | bit        | bool          |
        // | tinyint    | byte          |
        // | smallint   | short         |
        // | varchar    | string        |
        // | text       | string        |

    }
}
