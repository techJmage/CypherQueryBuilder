using System.Linq.Expressions;
using System.Text;

namespace CypherQueryBuilder;

public class NodeCreationQuery : QueryBase
{
    protected List<Node> newNodes = [];
    protected List<Node> mergeNodes = [];

    internal NodeCreationQuery(List<Node> nodes, bool toMerge = false)
    {
        if (toMerge)
            mergeNodes = nodes;
        else
            newNodes = nodes;
    }

    #region Returns    
    /// <summary>
    /// Returns the specified returns.
    /// </summary>
    /// <param name="returns">The returns.</param>
    /// <returns></returns>
    public override NodeCreationQuery Return(params string[] returns) => (NodeCreationQuery)base.Return(returns);
    /// <summary>
    /// Returns the specified f.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved">if set to <c>true</c> [alias to be removed].</param>
    /// <returns></returns>
    public NodeCreationQuery Return<T>(Expression<Func<T, object>> f, bool aliasToBeRemoved = true)
    {
        var alias = newNodes.Select(FindAlias<T>).FirstOrDefault(p => p.Length > 0);
        return Return(alias, f, aliasToBeRemoved);
    }
    /// <summary>
    /// Returns the specified node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="node">The node.</param>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved">if set to <c>true</c> [alias to be removed].</param>
    /// <returns></returns>
    public override NodeCreationQuery Return<T>(Node<T> node, Expression<Func<T, object>> f, bool aliasToBeRemoved = true) => (NodeCreationQuery)base.Return(node, f, aliasToBeRemoved);

    public override NodeCreationQuery Return<T>(string? alias, Expression<Func<T, object>> f, bool aliasToBeRemoved = true) => (NodeCreationQuery)base.Return(alias, f, aliasToBeRemoved);

    #endregion Returns

    /// <summary>
    /// Compiles this instance to Cypher Query string.
    /// </summary>
    /// <returns cref="string">Cypher Query string</returns>
    public override string Compile()
    {
        StringBuilder sb = new();
        BuildNodeCreationhPart(sb, false);
        BuildNodeCreationhPart(sb, true);
        BuildReturnPart(sb);
        return sb.ToString();
    }

    protected virtual string CreateCommand => "CREATE ";
    protected virtual string MergeCommand => "MERGE ";

    protected void BuildNodeCreationhPart(StringBuilder sb, bool toMerge = false)
    {
        List<Node> nodes = toMerge ? mergeNodes : newNodes;
        if (nodes.Count == 0)
            return;
        var command = toMerge ? MergeCommand : CreateCommand;
        var compiles = nodes.Select(p => p.CompileToCreate()).ToArray();
        foreach (var compile in compiles)
        {
            sb.AppendLine();
            sb.Append(command);
            sb.Append(compile);
        }
    }
    /// <summary>
    /// Merges the specified node.
    /// </summary>
    /// <param name="node">The node.</param>
    /// <param name="otherNodes">The other nodes.</param>
    /// <returns></returns>
    public NodeCreationQuery Merge(Node node, params Node[] otherNodes) => Create(true, node, otherNodes);

    public NodeCreationQuery Create(Node node, params Node[] otherNodes) => Create(false, node, otherNodes);

    protected NodeCreationQuery Create(bool toMerge, Node node, params Node[] otherNodes)
    {
        List<Node> nodes = toMerge ? mergeNodes : newNodes;
        nodes.Add(node);
        if (otherNodes.Length > 0)
            nodes.AddRange(otherNodes);
        return this;
    }
    /// <summary>
    /// Releases the resources.
    /// </summary>
    public override void ReleaseResources()
    {
        base.ReleaseResources();
        newNodes.Clear();
        mergeNodes.Clear();
    }
}