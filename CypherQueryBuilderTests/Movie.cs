namespace CypherQueryBuilder.Tests;

public class Movie: OgmNodeBase<Movie>
{
    public int ProductionCost { get; set; }

    [CypherProperty]
    public int ReleaseYear { get; set; }

    [CypherProperty(Name = "name")]
    public string Title { get; set; }
    public List<Person> Actors { get; set; } = [];
}

[CypherRelation(Name = "ACTED_IN", IsForward = false)]
public class ActedIn
{
    //[CypherProperty]
    //public string Role { get; set; }

    //public Movie Movie { get; set; }
    [CypherProperty]
    public int ReleaseYear { get; set; }
}