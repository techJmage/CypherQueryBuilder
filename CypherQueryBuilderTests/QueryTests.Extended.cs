using CypherQueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CypherQueryBuilderTests;
public partial class QueryTests
{
    [TestMethod]
    public void MatchReturnTest()
    {
        var q = Query.Match(Node<Student>.Instance()).Return<Student>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void OptionalMatchReturnTest()
    {
        var q = Query.OptionalMatch(Node<Student>.Instance()).Return<Student>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchReturnSelectedTest()
    {
        var q = Query.Match(Node<Student>.Instance()).Return<Student>(p => new { p.FirstName, p.LastName }).Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void OptionalMatchReturnSelectedTest()
    {
        var q = Query.OptionalMatch(Node<Student>.Instance()).Return<Student>(p => new { p.FirstName, p.LastName }).Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchForwardRelationTest()
    {
        var n = Node<Student>
                .Instance()
                .RelatedTo<EnrolledIn>(Node<Course>.Instance());
        var q = Query.Match(n).Return<Course>(p => new { value = p.Description }).Return<EnrolledIn>(p => new { key = p.Price }).Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void OptionalMatchForwardRelationTest()
    {
        var n = Node<Student>
                .Instance()
                .RelatedTo<EnrolledIn>(Node<Course>.Instance());
        var q = Query.OptionalMatch(n).Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchBackwardRelationTest()
    {
        var n = Node<Course>
                .Instance()
                .RelatedTo<EnrolledIn>(Node<Student>.Instance(), isForward: false);
        var q = Query.Match(n).Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [DataTestMethod]
    [DataRow(true, DisplayName = "With alias")]
    [DataRow(false, DisplayName = "Without alias")]
    public void MatchForwardRelationWithEmptySinkTest(bool withAlias)
    {
        var n = Node<Student>
                .Instance()
                .RelatedTo<EnrolledIn>(new Node(withAlias ? "n" : string.Empty));
        var q = Query.Match(n).Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [DataTestMethod]
    [DataRow(true, DisplayName = "With alias")]
    [DataRow(false, DisplayName = "Without alias")]
    public void MatchForwardEmptyRelationWithEmptySinkTest(bool withAlias)
    {
        var n = Node<Student>
                .Instance()
                .WithRelation(new Node(string.Empty), withAlias ? "r" : string.Empty);
        var q = Query.Match(n).Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchForwardRelationWithMultipleLabelsTest()
    {
        // multiple labels doesn't work
        var n = Node<Student>
                .Instance()
                .RelatedTo<EnrolledIn>(Node<Course>.Instance(), labels: typeof(EnrolledInAsNonRegular).CypherName());
        var q = Query.Match(n).Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchWhereReturnTest()
    {
        var now = DateTime.Now;
        var n = Node<Student>
                .Instance()
                .Where(p => p.FirstName == "John" || p.LastName == "Doe")
                .RelatedTo<EnrolledIn>(Node<Course>.Instance(), expr: p => p.Price > 10_000);
        var q = Query.OptionalMatch(n).Where<Course>(p => p.Title == "Cypher").Return<Student>().Return<Course>().Return<EnrolledIn>().Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
    }
    [TestMethod]
    public void MatchReturnTest2()
    {
        var n = Node<Student>.Instance();
        var q = Query.Match(n).Return(n, p => p.DateOfBirth, collateAs: "Dob").Compile();
        var q1 = Query.Match(n).Return<Student>(n.Alias, p => p.DateOfBirth, collateAs: "Dob").Compile();
        var q2 = Query.Match(n).Return<Student>(collateAs: "Value").Compile();
        var q3 = Query.Match(n).Return<Student>(n.Alias, p => new {Dob = p.DateOfBirth}, collateAs: "Value").Compile();
        Assert.IsNotEmpty(q);
        Assert.IsNotNull(q);
        Console.WriteLine(q);
        Console.WriteLine(q1);
        Console.WriteLine(q2);
        Console.WriteLine(q3);
    }
}