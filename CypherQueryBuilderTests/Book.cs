namespace CypherQueryBuilder.Tests;

public class Book : OgmNodeBase<Book>
{
    [CypherProperty(Name = "topic")]
    public string[] Topics { get; set; }

    [CypherProperty(Name = "publishedOn")]
    public DateTimeOffset PublishedOn { get; set; }
}