namespace CypherQueryBuilder.Tests;

public class Domain : OgmModelBase
{
    [CypherProperty]
    public string Name { get; set; } = string.Empty;
    [CypherProperty]
    public bool HasGlobalVariable { get; set; } = false;
    [CypherProperty]
    public List<string> Applications { get; set; } = [];
}
