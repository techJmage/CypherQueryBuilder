using System.Text;

namespace CypherQueryBuilder;

public class DeleteQuery : MatchQuery
{
    protected HashSet<string> removables = [];
    protected HashSet<string> detachables = [];

    internal DeleteQuery(HashSet<Node> matches) : base(matches)
    {
    }

    /// <summary>
    /// Deletes the specified entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities">The entities to delete.</param>
    /// <returns cref="DeleteQuery">DeleteQuery</returns>
    public override DeleteQuery Delete<T>(params T[] entities)
    {
        var lst = entities.Select(p => p.Alias);
        foreach (var s in lst)
            removables.Add(s);
        return this;
    }

    /// <summary>
    /// Detaches, i.e. delete with all the associated relations (if it is a node), the specified entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities">The entities to detache and delete.</param>
    /// <returns cref="DeleteQuery">DeleteQuery</returns>
    public override DeleteQuery Detach<T>(params T[] entities)
    {
        var lst = entities.Select(p => p.Alias);
        foreach (var s in lst)
            detachables.Add(s);
        return this;
    }

    /// <summary>
    /// Compiles this instance to Cypher Query string.
    /// </summary>
    /// <returns cref="string">Cypher Query string</returns>
    public override string Compile()
    {
        StringBuilder sb = new();
        BuildMatchPart(sb);
        BuildDeletePart(sb);
        return sb.ToString();
    }

    protected void BuildDeletePart(StringBuilder sb)
    {
        if (removables.Count == 0 && detachables.Count == 0) return;
        if (removables.Count > 0)
        {
            sb.AppendLine();
            sb.Append("DELETE ");
            sb.Append(string.Join(',', removables));
        }
        if (detachables.Count > 0)
        {
            sb.AppendLine();
            sb.Append("DETACH DELETE ");
            sb.Append(string.Join(',', detachables));
        }
    }

    /// <summary>
    /// Releases the resources, used while disposing.
    /// </summary>
    public override void ReleaseResources()
    {
        base.ReleaseResources();
        removables.Clear();
        detachables.Clear();
    }
}