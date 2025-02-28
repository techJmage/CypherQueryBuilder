namespace CypherQueryBuilder;

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
public class CypherPropertyAttribute : Attribute
{
    public string? Name { get; set; } = null;
}
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class CypherEntityAttribute : Attribute
{
    public string? Name { get; set; } = null;
}
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class CypherNodeAttribute : CypherEntityAttribute
{
}
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class CypherRelationAttribute : CypherEntityAttribute
{
    public bool IsForward { get; set; } = true;
}