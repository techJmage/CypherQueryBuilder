namespace CypherQueryBuilder.Tests;

public class Person : OgmNodeBase<Person>
{
    [CypherProperty(Name = "age")]
    public int Age { get; set; }

    [CypherProperty(Name = "fullName")]
    public string FullName { get; set; }

}
[CypherRelation(Name = "WROTE")]
public class Wrote
{
    [CypherProperty]
    public string PersonnId { get; set; }
}
[CypherRelation(Name = "ACTED_BY")]
public class ActedBy
{
    [CypherProperty]
    public string PersonnId { get; set; }
}