namespace CypherQueryBuilder.Tests;

public class Book : OgmNodeBase<Book>
{
    [CypherProperty(Name = "genres")]
    public List<string> Genre { get; set; }
    [CypherProperty(Name = "topic")]
    public string[] Topics { get; set; }

    [CypherProperty(Name = "publishedOn")]
    public DateTimeOffset PublishedOn { get; set; }
    [CypherProperty(Name = "title")]
    public string Title { get; set; }
}