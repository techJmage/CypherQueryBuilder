namespace CypherQueryBuilder;

public enum LogicalOperator
{
    AND, OR, None
}

/// <summary>
/// <c>Query</c> - The main entry point to build cypher query for create, merge or match
/// </summary>
public static class Query
{
    /// <summary>Creates the specified node.</summary>
    /// <param name="node">Node to Instance</param>
    /// <param name="otherNodes">Other nodes to match in case multiple nodes to be created.</param>
    /// <returns cref="NodeCreationQuery">NodeCreationQuery</returns>
    /// <example>
    /// Example to build create query.
    /// <code>var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
    /// var q = Query.Instance(
    ///     Node&lt;Movie&gt;.Instance(movie)
    ///         .WithRelation(Node&lt;Person&gt;.Instance(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))
    ///     .Return&lt;Movie&gt;(p =&gt; new { p.Title, p.ReleaseYear }).Return&lt;Person&gt;(p =&gt; new { p.FullName});
    /// var str = q.Compile();</code></example>
    public static NodeCreationQuery Create(Node node, params Node[] otherNodes) => Create(false, node, otherNodes);

    /// <summary>Matches the specified node.</summary>
    /// <example>
    /// <code>
    /// var q = Query.Match(n).Return("n", "r", "m");
    /// </code>
    /// </example>
    /// <param cref="Node" name="node">Node to Match</param>
    /// <param cref="Node" name="otherNodes">Other nodes to match in case multiple nodes to be matched</param>
    /// <returns cref="MatchQuery"><c>MatchQuery</c></returns>
    public static MatchQuery Match(Node node, params Node[] otherNodes)
    {
        HashSet<Node> matches = [node];
        foreach (var n in otherNodes)
            matches.Add(n);
        MatchQuery q = new(matches);
        return q;
    }

    /// <summary>
    /// Merges the specified node.
    /// </summary>
    /// <param name="node">The node.</param>
    /// <param name="otherNodes">The other nodes in case multiple nodes to be merged.</param>
    /// <returns cref="NodeCreationQuery">NodeCreationQuery</returns>
    /// <example>
    /// Example to build merge query.
    /// <code>var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
    /// var q = Query.Merge(
    ///     Node&lt;Movie&gt;.Instance(movie)
    ///         .WithRelation(Node&lt;Person&gt;.Instance(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))
    ///     .Return&lt;Movie&gt;(p =&gt; new { p.Title, p.ReleaseYear }).Return&lt;Person&gt;(p =&gt; new { p.FullName});
    /// var str = q.Compile();</code></example>
    public static NodeCreationQuery Merge(Node node, params Node[] otherNodes) => Create(true, node, otherNodes);

    /// <summary>
    /// Creates the specified to merge.
    /// </summary>
    /// <param name="toMerge">if set to <c>true</c> [to merge].</param>
    /// <param name="node">The node.</param>
    /// <param name="otherNodes">The other nodes.</param>
    /// <returns cref="NodeCreationQuery"></returns>
    private static NodeCreationQuery Create(bool toMerge, Node node, params Node[] otherNodes)
    {
        List<Node> nodes = [node];
        nodes.AddRange(otherNodes);
        return new(nodes, toMerge);
    }
}