using System;
using System.Collections.Generic;

namespace ASP_projekt.Models.Movies;

public partial class MovieCast
{
    public int? MovieId { get; set; }

    public int? PersonId { get; set; }

    public string? CharacterName { get; set; }

    public int? GenderId { get; set; }

    public int? CastOrder { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual Person? Person { get; set; }
}
