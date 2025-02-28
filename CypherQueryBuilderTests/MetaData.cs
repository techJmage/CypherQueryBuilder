namespace CypherQueryBuilder.Tests;

public class MetaData : OgmModelBase
{
    [CypherProperty]
    public string Code { get; set; }
    [CypherProperty]
    public string Description { get; set; }
}
