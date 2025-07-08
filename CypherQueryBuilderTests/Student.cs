using CypherQueryBuilder;

namespace CypherQueryBuilderTests;

[CypherNode(Name = "Student")]
internal class Student : OgmNodeBase<Student>
{
    [CypherProperty(Name = "firstName")]
    public string? FirstName { get; set; }
    [CypherProperty(Name = "lastName")]
    public string? LastName { get; set; }
    [CypherProperty(Name = "dateOfBirth")]
    public DateTime? DateOfBirth { get; set; }
}
[CypherNode(Name = "Course")]
internal class Course : OgmNodeBase<Student>
{
    [CypherProperty]
    public string? Description { get; set; }
    [CypherProperty]
    public string? Title { get; set; }
    [CypherProperty]
    public DateTime? StartsOn { get; set; }
}
[CypherRelation(Name = "EnrolledIn")]
internal class EnrolledIn
{
    [CypherProperty]
    public decimal? Price { get; set; }
}
[CypherRelation(Name = "EnrolledInAsNonRegular")]
internal class EnrolledInAsNonRegular
{
    [CypherProperty]
    public decimal? Price { get; set; }
    [CypherProperty]
    public bool? IsNightShift { get; set; }
}
