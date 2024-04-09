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
        public byte LanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length {  get; set; }
        public decimal ReplacementCost { get; set; }
        public string? Rating { get; set; }
        public DateTime LastUpdate { get; set; }

        // Mapowanie typów
        // | -----------| --------------|
        // | SQL        | C#            |
        // | -----------| --------------|
        // | bit        | bool          |
        // | tinyint    | byte          |
        // | smallint   | short         |
        // | int        | int           |
        // | bigint     | long          |
        // | float      | float         |
        // | real       | float         |
        // | decimal    | decimal       |
        // | numeric    | decimal       |
        // | money      | decimal       |
        // | smallmoney | decimal       |
        // | char       | string        |
        // | varchar    | string        |
        // | text       | string        |
        // | nchar      | string        |
        // | nvarchar   | string        |
        // | ntext      | string        |
        // | date       | DateTime      |
        // | time       | TimeSpan      |
        // | datetime   | DateTime      |
        // | datetime2  | DateTime      |
        // | datetimeoffset | DateTimeOffset |
        // | timestamp  | byte[]        |
        // | uniqueidentifier | Guid    |
        // | binary     | byte[]        |
        // | varbinary  | byte[]        |
        // | image      | byte[]        |
        // | xml        | XmlDocument or XElement (or string if serialized) |
        // | geometry   | SqlGeometry   |
        // | geography  | SqlGeography  |
        // | -----------| --------------|

    }
}
