using System.Text;

namespace CypherQueryBuilder;

public class UnionQuery : MatchQuery
{
    protected HashSet<MatchQuery> unions = [];

    internal UnionQuery(HashSet<Node> matches) : base(matches)
    {
    }

    public override string Compile()
    {
        StringBuilder sb = new();
        BuildMatchPart(sb);
        BuildReturnPart(sb);
        if (unions.Count > 0)
        {
            sb.AppendLine(" UNION ");
            var uq = string.Join(" UNION ", unions.Select(p => p.Compile()));
            sb.AppendLine(uq);
        }
        return sb.ToString();
    }
    /// <summary>Compiles the instance to Cypher Query string with paremeters.</summary>
    /// <returns cref="ValueTuple">ValueTuple&lt;string, Dictionary&lt;string, Nullable&lt;Object&gt;&gt;&gt;</returns>
    /// <example>
    ///   <para>Usage:</para>
    ///   <code>var metaDataCount = 2;
    /// var metaDataNodes = new Node&lt;MetaData&gt;[metaDataCount];
    /// for (int i = 0; i &lt; metaDataCount; i++)
    /// {
    ///     var id = $"mId_{i}";
    ///     metaDataNodes[i] = Node&lt;MetaData&gt;.Instance(i).Where(p =&gt; p.Uid == id);
    /// }
    /// var domainNode = Node&lt;Domain&gt;.Instance().Where(p =&gt; p.Uid == "TestDomain");
    /// var (mq, parameters) = Query.Match(domainNode, metaDataNodes).CompileAsParemeterized();</code>
    /// </example>
    /// <seealso cref="Compile"/>
    public override (string query, Dictionary<string, object?> parameters) CompileWithParemeters(Dictionary<string, object?>? startParameters = null)
    {
        Dictionary<string, object?> parameters = startParameters ?? [];
        StringBuilder sb = new();
        BuildMatchPart(sb, ref parameters);
        BuildReturnPart(sb);
        if (unions.Count > 0)
        {
            sb.AppendLine(" UNION ");
            var uLst = unions.Select(p => p.CompileWithParemeters(parameters)).ToArray();
            var uq = string.Join(" UNION ", uLst.Select(p => p.query));
            sb.AppendLine(uq);
        }
        return (sb.ToString(), parameters);
    }
    public MatchQuery Union(MatchQuery other)
    {
        unions.Add(other);
        return this;
    }
}