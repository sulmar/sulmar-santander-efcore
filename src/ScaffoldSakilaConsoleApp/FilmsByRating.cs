using System;
using System.Collections.Generic;

namespace Sakila.Model;

public partial class FilmsByRating
{
    public string? Rating { get; set; }

    public int? FilmCount { get; set; }
}
