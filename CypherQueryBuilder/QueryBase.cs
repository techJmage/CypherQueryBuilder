using ExpressionTreeToString;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Utility;

namespace CypherQueryBuilder;

public abstract partial class QueryBase : Disposable
{
    protected List<string> returns = [];
    protected List<(string expr, bool isDescending)> orders = [];
    protected bool isDistinct;

    /// <summary>
    /// Compiles this instance to Cypher Query string.
    /// </summary>
    /// <returns cref="string">Cypher Query string</returns>
    public abstract string Compile();

    /// <summary>
    /// Collect data to build return parts while compiling.
    /// </summary>
    /// <param name="returns">
    /// <seealso cref="Return{T}(string?, Expression{Func{T, object}}, bool)"/>
    /// <seealso cref="Return{T}(Node{T}, Expression{Func{T, object}})"/>
    public virtual QueryBase Return(params string[] returns)
    {
        this.returns.AddRange(returns);
        return this;
    }

    protected static string FindAlias<T>(Node? n)
    {
        if (n is null)
            return string.Empty;
        if (n is Node<T>)
            return n.Alias;
        var t = typeof(T);
        foreach (var r in n.Relations)
        {
            if (r.UnderlyingType == t)
                return r.Alias;
            else
            {
                var alias = FindAlias<T>(r.EndNode);
                if (!string.IsNullOrEmpty(alias))
                    return alias;
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// Collect data to build return parts whilde compiling.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="node">The node.</param>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved">if set to <c>true</c> [alias to be removed].</param>
    /// <returns></returns>
    /// <seealso cref="Return(string[])"/>
    /// <seealso cref="Return{T}(string?, Expression{Func{T, object}}, bool)"/>
    public virtual QueryBase Return<T>(Node<T> node, Expression<Func<T, object>> f, bool aliasToBeRemoved = true, string? collateAs = null) => Return(node.Alias, f, aliasToBeRemoved, collateAs);

    /// <summary>
    /// Collect data to build return parts whilde compiling.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="alias">The alias.</param>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved">if set to <c>true</c> [alias to be removed].</param>
    /// <returns></returns>
    /// <seealso cref="Return(string[])"/>
    /// <seealso cref="Return{T}(Node{T}, Expression{Func{T, object}}, bool)"/>
    public virtual QueryBase Return<T>(string? alias, Expression<Func<T, object>> f, bool aliasToBeRemoved = true, string? collateAs = null)
    {
        var collate = !string.IsNullOrWhiteSpace(collateAs);
        var map = typeof(T).GetCypherPropertyMap(alias);
        var rq = f.ToCypherString(map);
        var assignmentExp = AssignmentExp();
        var isAssignment = assignmentExp.IsMatch(rq);
        if (isAssignment)
            rq = assignmentExp.Replace(rq, m => collate ? $"{m.Groups["K"]}: {m.Groups["V"].Value}" : $"{m.Groups["V"].Value} AS {m.Groups["K"]}");
        else if (aliasToBeRemoved && alias != null)
        {
            var aliasRemovalLength = alias.Length + 1;
            foreach (var (_, v) in map)
                rq = rq.Replace(v, collate ? $"{v.Remove(0, aliasRemovalLength)}: {v}" : $"{v} AS {v.Remove(0, aliasRemovalLength)}");
        }
        if ((isAssignment || (aliasToBeRemoved && alias != null)) && collate)
            rq = $"{{ {rq} }} AS {collateAs}";
        return Return(rq);
    }
    protected virtual void AddOrder<T, K>(string? alias, Expression<Func<T, K>> keySelector, bool isDescending)
    {
        var order = keySelector.ToCypherString(typeof(T).GetCypherPropertyMap(alias));
        orders.Add((order, isDescending));
    }

    protected virtual void BuildReturnPart(StringBuilder sb)
    {
        var r = " RETURN ";
        if (isDistinct)
            r += "DISTINCT ";
        if (returns.Count > 0)
            sb.Append(r + string.Join(',', returns));
        if (orders.Count > 0)
            foreach (var (expr, isDescending) in orders)
                sb.Append($" ORDER BY {expr} " + (isDescending ? "DESC " : string.Empty));
    }

    public override void ReleaseResources()
    {
        returns.Clear();
        orders.Clear();
    }

    [GeneratedRegex(@"(?<K>\w+)\s*\=\s*(?<V>\w+(\.\w+)?)", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex AssignmentExp();
}