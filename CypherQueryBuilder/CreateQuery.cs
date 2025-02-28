using System.Text;

namespace CypherQueryBuilder;

public class CreateQuery : MatchQuery
{
    protected HashSet<Node> newNodesWithRelations = [];

    internal CreateQuery(HashSet<Node> matches) : base(matches)
    {
    }
    /// <summary>
    /// Creates the relation.
    /// </summary>
    /// <param name="alias">The alias.</param>
    /// <param name="label">The label.</param>
    /// <param name="from">From.</param>
    /// <param name="to">To.</param>
    /// <param name="toMerge">if set to <c>true</c> [to merge].</param>
    /// <param name="properties">The properties.</param>
    /// <returns></returns>
    public override CreateQuery CreateRelation(string alias, string label, Node from, Node to, bool toMerge = false, object? properties = null)
    {
        if (!matches.Contains(from) && !newNodesWithRelations.Contains(from))
            newNodesWithRelations.Add(from);
        from.CreateRelationWith(to, alias, label, toMerge, properties);
        return this;
    }

    /// <summary>
    /// Compiles this instance to Cypher Query string.
    /// </summary>
    /// <returns cref="string">Cypher Query string</returns>
    /// <seealso cref="CompileWithParemeters"/>
    public override string Compile()
    {
        StringBuilder sb = new();
        BuildMatchPart(sb);
        BuildRelationCreationPart(sb, null);
        BuildReturnPart(sb);
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
        BuildRelationCreationPart(sb, parameters);
        BuildReturnPart(sb);
        return (sb.ToString(), parameters);
    }

    protected void BuildRelationCreationPart(StringBuilder sb, Dictionary<string, object?>? parameters)
    {
        HashSet<Node> creationConsideredFor = [];
        var existingNodes = new HashSet<Node>(matches);
        foreach (Node node in matches)
            sb.Append(node.CompileNewRelations(existingNodes, parameters, creationConsideredFor));
        foreach (Node node in newNodesWithRelations)
            sb.Append(node.CompileNewRelations(existingNodes, parameters, creationConsideredFor));
    }
}