using CypherQueryBuilder;
using CypherQueryBuilder.Tests;
using System.Text.RegularExpressions;

namespace CypherQueryBuilderTests;
[TestClass]
public class QueryTests
{
    [TestMethod]
    public void CompileTest()
    {
        var m = new Node("m")
            .WithLabels("Movie");
        var n = new Node("n")
            .WithLabels("Actor")
            .WithProperty("name", "Clint Eastwood").WithRelation(m, "r", new { Role = "Hero" }, true, "ACTED_IN");
        var q = Query
            .Match(n)
            .Return("n", "r", "m");
        var cq = q.Compile();
        Console.WriteLine(cq);
        Assert.IsNotNull(cq);
    }

    [TestMethod]
    public void CompileGenericTest()
    {
        var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
        var m = movie.AsNode();
        var n = new Node("n")
            .WithLabels("Actor")
            .WithProperty("name", "Clint Eastwood")
            .WithRelation(m, "r", null, true, "ACTED_IN");
        var q = Query
            .Match(n)
            .Return("n", "r", "m");
        var cq = q.Compile();
        Console.WriteLine(cq);
        Assert.IsNotNull(cq);
    }

    [TestMethod]
    public void CompileUnionTest()
    {
        var q = Query
            .Match(new Node("n").WithLabels("Actor").WithProperty("name", "Clint Eastwood"))
            .Return("n.name AS name");
        var uq = Query
            .Match(new Node("p").WithLabels("Director").WithProperty("name", "Clint Eastwood"))
            .Return("p.name AS name");
        q = q.Union(uq);
        var cq = q.Compile();
        Console.WriteLine(cq);
        Assert.IsNotNull(cq);
    }

    [TestMethod]
    public void CompileExpressionTest()
    {
        var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
        var m = movie.AsNode().Where(p => p.ReleaseYear == 2001 || p.ReleaseYear < 1997 || p.Title == "D");
        var n = new Node("n")
            .WithLabels("Actor")
            .WithProperty("name", "Clint Eastwood")
            .WithRelation(m, "r", new { Role = "Hero" }, true, "ACTED_IN");
        var q = Query
            .Match(n)//.Where(m.BasicFilter)
                     //.Return("n", "r", "m")
            .Return<Movie>(p => new { p.Title, p.ReleaseYear });
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }

    [TestMethod]
    public void CompileSimpleCreationTest()
    {
        var movies = new List<Movie>();
        var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
        var q = Query.Create(
            Node<Movie>.Instance(movie)
                .WithRelation(Node<Person>.Instance(new Person { Age = 30, FullName = "Ray" }), "DIRECTED_BY"))
            .Return<Movie>(p => new { p.Title, p.ReleaseYear }).Return<Person>(p => new { p.FullName });
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileChainCreationTest()
    {
        var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" }.AsNode();
        var person = new Person { Age = 30, FullName = "Ray" }.AsNode();
        var book = new Book { PublishedOn = DateTime.Now }.AsNode();
        var book2 = new Book { PublishedOn = DateTime.Now, Uid = "tty" }.AsNode(1);
        var dtValue = DateTime.MinValue;
        var mq = Query.Match(movie, book, book2).Where<Book>(p => p.PublishedOn > dtValue, book2.Alias);
        var q = mq.CreateRelation("r1", "ACTED_BY", movie, person, properties: new { p1 = "t1" });
        q = q.CreateRelation("r2", "Wrote", person, book);
        q = q.CreateRelation("r3", "Test", person, book2);
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileMatchCreationTest()
    {
        var mNode = new Movie() { ReleaseYear = 2010, Title = "Gambler" }.AsNode();
        var mNode2 = new Movie() { ReleaseYear = 2025, Title = "Titanic" }.AsNode(1);
        var pNode = Node<Person>.Instance(new Person { Age = 30, FullName = "Ray" });
        var bookNode = new Book { Topics = ["Science"], PublishedOn = DateTime.Now }.AsNode();
        var q = Query
            .Match(mNode, mNode2, bookNode)
            .CreateRelation("d", "DIRECTED_BY", mNode, pNode)
            .CreateRelation("d", "DIRECTED_BY", mNode2, pNode)
            .CreateRelation("w", "WRITES", pNode, bookNode);
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void ComplexCompileTest()
    {
        var metaDataCount = 2;
        var metaDataNodes = new Node<MetaData>[metaDataCount];
        for (int i = 0; i < metaDataCount; i++)
        {
            var id = $"mId_{i}";
            metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);
        }
        var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");
        var mq = Query.Match(domainNode, metaDataNodes).Compile();
        var groupNode = Node<Group>.Instance().WithProperty(new { Uid = "gId_1", Name = "GName", Domain = "TestDomain" });
        var q = Query.Match(domainNode, metaDataNodes)
            .CreateRelation("hg", "HAS_GROUP", domainNode, groupNode, false, new { DomainId = "TestDomain", GroupId = "gId_1" });
        for (int i = 0; i < metaDataNodes.Length; i++)
            q = q.CreateRelation($"hmdfg{i}", "HAS_META_DATA_FOR_GROUP", groupNode, metaDataNodes[i], false, new { GroupId = "gId_1", MetaDataId = $"mId_{i}" });
        var cq = q.Compile();
        Console.WriteLine(cq);
        Assert.IsNotNull(cq);
    }
    [TestMethod]
    public void ParameterizedCompileTest()
    {
        var metaDataCount = 2;
        var metaDataNodes = new Node<MetaData>[metaDataCount];
        for (int i = 0; i < metaDataCount; i++)
        {
            var id = $"mId_{i}";
            metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);
        }
        var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");
        var groupNode = Node<Group>.Instance().WithProperty(new { Uid = "gId_1", Name = "GName", Domain = "TestDomain" });
        var q = Query.Match(domainNode, metaDataNodes)
            .CreateRelation("hg", "HAS_GROUP", domainNode, groupNode, false, new { DomainId = "TestDomain", GroupId = "gId_1" });
        for (int i = 0; i < metaDataNodes.Length; i++)
            q = q.CreateRelation($"hmdfg{i}", "HAS_META_DATA_FOR_GROUP", groupNode, metaDataNodes[i], false, new { GroupId = "gId_1", MetaDataId = $"mId_{i}" });
        var (cq, parameters) = q.CompileWithParemeters();
        Console.WriteLine(cq);
        Assert.IsTrue(parameters.Count > 0);
        Assert.IsNotNull(cq);
    }
    [TestMethod]
    public void ParameterizedCompileWithBackwardRelationTest()
    {
        Node<Domain>.Instance(out var domainNode).Where(p => p.Uid == "TestDomain");
        Node<Group>.Instance(out var groupNode).WithProperty(new { Uid = "gId_1", Name = "GName", Domain = "TestDomain" });
        MetaData md = new() { Uid = "123", Code = "6Y", Description = "Lusado" };
        var q = Query.Match(domainNode)
            .CreateRelation("hg", "HAS_DOMAIN", groupNode, domainNode, false, new { DomainId = "TestDomain", GroupId = "gId_1" })
            .CreateRelation("hmd", "HAS_METADATA", groupNode, md.AsNode(), false, new { DomainId = "TestDomain", GroupId = "gId_1" });
        var (cq, parameters) = q.CompileWithParemeters();
        Console.WriteLine(cq);
        Assert.IsTrue(parameters.Count > 0);
        Assert.IsNotNull(cq);
    }
    [TestMethod]
    public void CompileUpdateQueryTest()
    {
        var r = 2010;
        var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);
        var q = Query
            .Match(mNode)
            .Update<Movie, int>(p => p.ReleaseYear, p => r)
            .Return<Movie>()
            .OrderBy<Movie, int>(m => m.ReleaseYear)
            .Return<Movie>(p => new { p.Title, p.ReleaseYear });
        var str = q.Compile();
        Console.WriteLine(str);
        (str, var parameters) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }

    [TestMethod]
    public void CompileUpdateRelationQueryTest()
    {
        var r = 2010;
        var actor = new Person { FullName = "Debjit", Age = 80 };
        var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);
        mNode.WithRelation(actor.AsNode(), new ActedIn() { ReleaseYear = 2009 });
        //mNode.WithRelation(actor.AsNode(), "r", new { ReleaseYear = 2009 }, true, "ACTED_IN");
        var q = Query
            .Match(mNode)
            .Update<ActedIn, int>(p => p.ReleaseYear, p => r);
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileUpdateQueryTest2()
    {
        /*
         MATCH (dt:DecisionTree {Uid: "{{args.Value}}"})-[ri:RESULTS_IN_DECISION_TREE]->(child:DecisionTree)
            WHERE ri.RuleSequence = 0 AND child.Uid IN $ChildUids
            SET ri.RuleSequence = 1
         */
        var r = 2010;
        var actor = new Person { FullName = "Debjit", Age = 80 };
        var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);
        mNode.WithRelation(actor.AsNode(), "r", new { ReleaseYear = 2009 }, true, "ACTED_IN");
        var q = Query
            .Match(mNode)
            .Update<Movie, int>(p => p.ReleaseYear, p => r)
            .Return<Movie>()
            .OrderBy<Movie, int>(m => m.ReleaseYear)
            .Return<Movie>(p => new { p.Title, p.ReleaseYear });
        var str = q.Compile();
        Console.WriteLine(str);
        (str, var parameters) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileUpdateQueryExpressionTest()
    {
        var r = 2010;
        var incr = 10;
        var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > r);
        var q = Query
            .Match(mNode)
            .Update<Movie, int>(p => p.ReleaseYear, p => p.ReleaseYear + incr)
            .Return<Movie>()
            .OrderBy<Movie, int>(m => m.ReleaseYear)
            .Return<Movie>(p => new { p.Title, p.ReleaseYear });
        var str = q.Compile();
        Console.WriteLine(str);
        (str, var parameters) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileTet2()
    {
        var domainId = "biggo";
        var q = Query
                .Match(Node<Movie>.Instance().Where(p => p.Uid == domainId))
                .Return<Movie>(p => new { p.Title, p.ReleaseYear });
        var str = q.Compile();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CompileDeleteQueryTest()
    {
        var r = 2010;
        var actor = new Person();
        var actorNode = actor.AsNode();
        var m = new Movie();
        m.Node = m.AsNode().Where(p => p.ReleaseYear > 500);
        m.Node.RelatedTo<ActedIn>(actorNode, expr: p => p.ReleaseYear > 2000);
        actorNode.Where(p => p.Age > 9);
        var q = m.ToMatchQuery()
            .Delete(m.Node.Relations.First());
        var str = q.Compile();
        (var s, var parameters) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void ListDateTimePropertyTest()
    {
        var dt = DateTime.Now;
        var book = new Book { Topics = ["History", "Culture"], PublishedOn = DateTime.Now }.AsNode();
        var q = Query
            .Match(book)
            .Where<Book>(p => p.PublishedOn > dt) // p.Topics.Contains("India") && 
            .Return<Book>();
        var str = q.Compile();
        (var str1, var p) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void UpdateDateTimePropertyTest()
    {
        DateTimeOffset dt = DateTime.Now;
        var book = new Book { Topics = ["History", "Culture"], PublishedOn = DateTime.Now }.AsNode();
        var lst = new List<string>() { "History", "Culture", "Biology" };
        var q = Query
            .Match(book)
            .Where<Book>(p => p.PublishedOn > dt) // p.Topics.Contains("India") && 
            .Update<Book, DateTimeOffset>(p => p.PublishedOn, p => dt)
            .Update<Book, string>(p => p.Title, p => "N")
            .Update<Book, List<string>>(p => p.Genre, p => new List<string>() { "History", "Culture", "Biology" });
        var str = q.Compile();
        (var str1, var p) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
    [TestMethod]
    public void CreateMultipleRelationsTest()
    {
        var dt = DateTime.Now;
        var book = new Book { Topics = ["History", "Culture"], PublishedOn = DateTime.Now }.AsNode();
        var q = Query
            .Match(book)
            .Where<Book>(p => p.PublishedOn > dt) // p.Topics.Contains("India") && 
            .Return<Book>();
        var str = q.Compile();
        (var str1, var p) = q.CompileWithParemeters();
        Console.WriteLine(str);
        Assert.IsNotNull(str);
    }
}