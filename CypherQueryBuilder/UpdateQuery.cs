using ExpressionTreeToString;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Linq.Expressions;
using System.Text;

namespace CypherQueryBuilder;

public class UpdateQuery : MatchQuery
{
    protected Dictionary<string, string> updateExpressions = [];
    protected Dictionary<string, object> updatableValues = [];

    internal UpdateQuery(HashSet<Node> matches) : base(matches)
    {
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
        BuildUpdatePart(sb);
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
        BuildUpdatePart(sb, parameters);
        BuildReturnPart(sb);
        return (sb.ToString(), parameters);
    }

    public override UpdateQuery Update<T, K>(Expression<Func<T, K>> propertySelector, Expression<Func<T, K>> valueSelector, string? alias = null)
    {
        if (string.IsNullOrWhiteSpace(alias))
            alias = FindAlias<T>();
        var pMap = typeof(T).GetCypherPropertyMap(alias);
        var property = propertySelector.ToCypherString(pMap);
        var tk = typeof(K);
        if (tk.IsAssignableTo(typeof(System.Collections.IList)))// && tk.IsGenericType)
        {
            var fn = valueSelector.Compile();
            var lst = (System.Collections.IList)fn(default);            
            updatableValues.Add(property, lst);
            return this;
        }

        var exprValue = valueSelector.ToCypherString(pMap);
        //TODO:
        try
        {
            var v = CSharpScript.EvaluateAsync(exprValue).Result;
            //if(typeof(K).IsValueType)
            if (v is char && typeof(K) == typeof(string))
                updatableValues.Add(property, v.ToString());
            else
                updatableValues.Add(property, (K)v);
        }
        catch (CompilationErrorException)
        {
            updateExpressions.Add(property, exprValue);
        }
        return this;
    }
    protected void BuildUpdatePart(StringBuilder sb, Dictionary<string, object?>? parameters = null)
    {
        if (updateExpressions.Count == 0 && updatableValues.Count == 0)
            return;
        sb.AppendLine();
        sb.Append("SET ");
        var values = updatableValues.Select(p => $"{p.Key} = {p.Value.ToEquatableFormat(parameters)}").ToArray();
        var exprs = updateExpressions.Select(p => $"{p.Key} = {p.Value}").ToArray();
        sb.Append(string.Join(", ", values.Concat(exprs)));
    }
}