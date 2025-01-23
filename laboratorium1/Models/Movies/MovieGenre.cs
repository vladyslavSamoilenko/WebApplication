using System;
using System.Collections.Generic;

namespace ASP_projekt.Models.Movies;

public partial class MovieGenre
{
    public int? MovieId { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual Movie? Movie { get; set; }
}
