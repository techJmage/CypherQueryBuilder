using Currying;
using System.Linq.Expressions;
using System.Text;

namespace CypherQueryBuilder;

public class MatchQuery : QueryBase
{
    protected HashSet<Node> matches = [];
    protected LinkedList<(string clause, LogicalOperator op)> whereClause = [];

    internal MatchQuery(HashSet<Node> matches) => (this.matches) = (matches);

    #region Returns

    private int? skip, limit;

    /// <summary>
    /// Limits the specified limit.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <returns cref="MatchQuery">MatchQuery</returns>
    public MatchQuery Limit(int limit)
    {
        this.limit = limit;
        return this;
    }

    /// <summary>
    /// Returns the specified returns.
    /// </summary>
    /// <param name="returns">The returns.</param>
    /// <returns></returns>
    public override MatchQuery Return(params string[] returns) => (MatchQuery)base.Return(returns);

    /// <summary>
    /// Returns the specified f.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved">if set to <c>true</c> [alias to be removed].</param>
    /// <returns></returns>
    public MatchQuery Return<T>(Expression<Func<T, object>>? f = null, bool aliasToBeRemoved = true)
    {
        var alias = matches.Select(FindAlias<T>).FirstOrDefault(p => p.Length > 0);
        if (f == null)
        {
            var t = typeof(T);
            var ps = t.GetCypherProperties(alias);

            if (aliasToBeRemoved && alias != null)
            {
                var aliasRemovalLength = alias.Length + 1;
                var withoutAlias = ps.Select(p => $"{p} AS {p[aliasRemovalLength..]}");
                returns.Add(string.Join(',', withoutAlias));
            }
            else
                returns.Add(string.Join(',', ps));
            return this;
        }
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
    public override MatchQuery Return<T>(Node<T> node, Expression<Func<T, object>> f, bool aliasToBeRemoved = true) => (MatchQuery)base.Return(node, f, aliasToBeRemoved);

    /// <summary>
    /// Returns the specified alias.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="alias">The alias.</param>
    /// <param name="f">The f.</param>
    /// <param name="aliasToBeRemoved"></param>
    /// <returns></returns>
    public override MatchQuery Return<T>(string? alias, Expression<Func<T, object>> f, bool aliasToBeRemoved = true) => (MatchQuery)base.Return(alias, f, aliasToBeRemoved);

    /// <summary>
    /// Skips the specified skip.
    /// </summary>
    /// <param name="skip">The skip.</param>
    /// <returns></returns>
    public MatchQuery Skip(int skip)
    {
        this.skip = skip;
        return this;
    }
    #endregion Returns
    /// <summary>
    /// Compiles this instance to Cypher Query string.
    /// </summary>
    /// <returns cref="string">Cypher Query string</returns>
    /// <seealso cref="CompileWithParemeters"/>
    public override string Compile()
    {
        StringBuilder sb = new();
        BuildMatchPart(sb);
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
    public virtual (string query, Dictionary<string, object?> parameters) CompileWithParemeters(Dictionary<string, object?>? startParameters = null)
    {
        Dictionary<string, object?> parameters = startParameters ?? [];
        StringBuilder sb = new();
        BuildMatchPart(sb, ref parameters);
        BuildReturnPart(sb);
        return (sb.ToString(), parameters);
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
    public virtual CreateQuery CreateRelation(string alias, string label, Node from, Node to, bool toMerge = false, object? properties = null)
    {
        var q = new CreateQuery(matches) { returns = returns, whereClause = whereClause };
        return q.CreateRelation(alias, label, from, to, toMerge, properties);
    }
    /// <summary>
    /// Deletes the specified entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities">The entities.</param>
    /// <returns></returns>
    public virtual DeleteQuery Delete<T>(params T[] entities) where T : Entity
    {
        var q = new DeleteQuery(matches) { returns = returns, whereClause = whereClause };
        return q.Delete(entities);
    }
    /// <summary>
    /// Detaches the specified entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities">The entities.</param>
    /// <returns></returns>
    public virtual DeleteQuery Detach<T>(params T[] entities) where T : Entity
    {
        var q = new DeleteQuery(matches) { returns = returns, whereClause = whereClause };
        return q.Detach(entities);
    }

    /// <summary>
    /// Ors the where.
    /// </summary>
    /// <param name="clause">The clause.</param>
    /// <returns></returns>
    public MatchQuery OrWhere(string clause)
    {
        whereClause.AddLast((clause, LogicalOperator.OR));
        return this;
    }

    public override void ReleaseResources()
    {
        base.ReleaseResources();
        matches.Clear();
        whereClause.Clear();
    }

    /// <summary>
    /// Unions the specified other.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns></returns>
    public UnionQuery Union(MatchQuery other)
    {
        var q = new UnionQuery(matches) { whereClause = whereClause, returns = returns };
        q.Union(other);
        return q;
    }
    /// <summary>Create Update Query.</summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="propertySelector"></param>
    /// <param name="valueSelector"></param>
    /// <param name="alias"></param>
    /// <returns>
    ///   <c>UpdateQuery</c>
    /// </returns>
    /// <example>
    /// <code>var r = 2010;
    /// var mNode = Node&lt;Movie&gt;.Instance().Where(p =&gt; p.ReleaseYear &gt; 500);
    /// var q = Query
    ///     .Match(mNode)
    ///     .Update&lt;Movie, int&gt;(p =&gt; p.ReleaseYear, p =&gt; r)
    ///     .Return&lt;Movie&gt;()
    ///     .OrderBy&lt;Movie, int&gt;(m =&gt; m.ReleaseYear)
    ///     .Return&lt;Movie&gt;(p =&gt; new { p.Title, p.ReleaseYear });
    /// var str = q.Compile();</code></example>
    public virtual UpdateQuery Update<T, K>(Expression<Func<T, K>> propertySelector, Expression<Func<T, K>> valueSelector, string? alias = null)
    {
        var q = new UpdateQuery(matches) { returns = returns, whereClause = whereClause };
        return q.Update(propertySelector, valueSelector, alias);
    }

    /// <summary>Wheres the specified clause.</summary>
    /// <param name="clause">The clause.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    /// <example>
    ///   <code>var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
    /// var m = movie.AsNode().Where(p =&gt; p.ReleaseYear == 2001 || p.ReleaseYear &lt; 1997 || p.Title == "D");
    /// var n = new Node("n")
    ///     .WithLabels("Actor")
    ///     .WithProperty("name", "Clint Eastwood")
    ///     .WithRelation(m, "r", new { Role = "Hero" }, true, "ACTED_IN");
    /// var q = Query
    ///     .Match(n).Where(m.BasicFilter)
    ///     .Return&lt;Movie&gt;(p =&gt; new { p.Title, p.ReleaseYear });
    /// var str = q.Compile();</code>
    /// </example>
    public MatchQuery Where(string clause)
    {
        var op = whereClause.Count == 0 ? LogicalOperator.None : LogicalOperator.AND;
        whereClause.AddLast((clause, op));
        return this;
    }
    /// <summary>Wheres the specified expr.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="expr">The expr.</param>
    /// <param name="alias"></param>
    /// <returns>
    ///   <br />
    /// </returns>
    /// <example>
    ///   <code>var r = 2010;
    /// var actor = new Person { FullName = "Debjit", Age = 80 };
    /// var mNode = Node&lt;Movie&gt;.Instance().Where(p =&gt; p.ReleaseYear &gt; 500);
    /// mNode.WithRelation(actor.AsNode(), new ActedIn() { ReleaseYear = 2009 });
    /// var q = Query
    ///     .Match(mNode)
    ///     .Where&lt;ActedIn&gt;(p =&gt; p.ReleaseYear &gt; 2000)
    ///     .Delete(mNode.Relation);
    /// var str = q.Compile();</code>
    /// </example>
    public MatchQuery Where<T>(Expression<Func<T, bool>> expr, string? alias = null)
    {
        var op = whereClause.Count == 0 ? LogicalOperator.None : LogicalOperator.AND;
        alias = string.IsNullOrWhiteSpace(alias) ? FindAlias<T>() : alias;
        var clause = IEntity.ToCypherExpression(expr, alias);
        whereClause.AddLast((clause, op));
        return this;
    }
    /// <summary>
    /// Builds the match part.
    /// </summary>
    /// <param name="sb">The sb.</param>
    protected void BuildMatchPart(StringBuilder sb)
    {
        if (matches.Count == 0)
            return;
        sb.Append("MATCH ");
        HashSet<string> matchedAliases = [];
        var compiles = matches.Select(p => p.Compile(matchedAliases)).Where(p => !string.IsNullOrEmpty(p.match)).ToList();
        var mtch = string.Join(',', compiles.Select(p => p.match));
        sb.Append(mtch);
        BuildWhereClause(sb, string.Join(" AND ", compiles.Where(p => !string.IsNullOrWhiteSpace(p.where)).Select(p => p.where)));
    }

    protected void BuildMatchPart(StringBuilder sb, ref Dictionary<string, object?> parameters)
    {
        if (matches.Count == 0)
            return;
        sb.Append("MATCH ");
        var compiles = new HashSet<(string match, string where)>(matches.Count);
        HashSet<string> matchedAliases = [];
        foreach (var p in matches)
        {
            (var m, var w) = p.Compile(matchedAliases, ref parameters);
            if (!string.IsNullOrEmpty(m))
                compiles.Add((m, w));
        }
        var mtch = string.Join(',', compiles.Select(p => p.match));
        sb.Append(mtch);
        BuildWhereClause(sb, string.Join(" AND ", compiles.Where(p => !string.IsNullOrWhiteSpace(p.where)).Select(p => p.where)));
    }

    protected override void BuildReturnPart(StringBuilder sb)
    {
        base.BuildReturnPart(sb);
        if (skip.HasValue) sb.Append($" SKIP {skip}");
        if (limit.HasValue) sb.Append($" LIMIT {limit}");
    }

    protected void BuildWhereClause(StringBuilder sb, string wh)
    {
        var recursiveClauseExists = wh.Length > 0;
        if (recursiveClauseExists)
            sb.Append($" WHERE {wh} ");
        foreach (var (clause, op) in whereClause)
        {
            sb.Append(recursiveClauseExists ? " AND " : op.Pipe(TranslatToWhereClauseStart));
            sb.Append(clause);
        }
        static string TranslatToWhereClauseStart(LogicalOperator op) => op switch
        {
            LogicalOperator.AND => " AND ",
            LogicalOperator.OR => " OR ",
            _ => " WHERE "
        };
    }

    protected string FindAlias<T>()
    {
        var alias = matches.FirstOrDefault(m => !string.IsNullOrEmpty(FindAlias<T>(m)))?.Alias ?? string.Empty;
        return alias;
    }
    #region Orderby    
    /// <summary>Orders the by.</summary>
    /// <typeparam name="T">Entity (Node or Relation)</typeparam>
    /// <typeparam name="K">The property of the T type Node or Relation on which order by will be applied.</typeparam>
    /// <param name="keySelector">The key selector.</param>
    /// <param name="alias">The alias.</param>
    /// <returns>MatchQuery</returns>
    /// <example>
    ///   <code>var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
    /// var mNode = Node&lt;Movie&gt;.Instance(movie);
    /// var q = Query
    ///     .Match(mNode, pNode)
    ///     .Return&lt;Movie&gt;()
    ///     .OrderBy&lt;Movie, int&gt;(m =&gt; m.ReleaseYear);</code>
    /// </example>
    /// <seealso cref="OrderByDescending{T, K}(Expression{Func{T, K}}, string?)">OrderByDescending{T, K}(Expression{Func{T, K}}, string?)</seealso>
    public virtual MatchQuery OrderBy<T, K>(Expression<Func<T, K>> keySelector, string? alias = null)
    {
        if (string.IsNullOrWhiteSpace(alias))
            alias = FindAlias<T>();
        AddOrder(alias, keySelector, false);
        return this;
    }

    /// <summary>Orders the by descending.</summary>
    /// <typeparam name="T">Entity (Node or Relation)</typeparam>
    /// <typeparam name="K">The property of the T type Node or Relation on which descending order by will be applied.</typeparam>
    /// <param name="keySelector">The key selector.</param>
    /// <param name="alias">The alias.</param>
    /// <returns>MatchQuery</returns>
    /// <example>
    ///   <code>var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };
    /// var mNode = Node&lt;Movie&gt;.Instance(movie);
    /// var q = Query
    ///     .Match(mNode, pNode)
    ///     .Return&lt;Movie&gt;()
    ///     .OrderByDescending&lt;Movie, int&gt;(m =&gt; m.ReleaseYear);</code>
    /// </example>
    /// <seealso cref="OrderBy{T, K}(Expression{Func{T, K}}, string?)">OrderBy{T, K}(Expression{Func{T, K}}, string?)</seealso>
    public virtual MatchQuery OrderByDescending<T, K>(Expression<Func<T, K>> keySelector, string? alias = null)
    {
        if (string.IsNullOrWhiteSpace(alias))
            alias = FindAlias<T>();
        AddOrder(alias, keySelector, true);
        return this;
    }
    #endregion

    public virtual MatchQuery Distinct()
    {
        isDistinct = true;
        return this;
    }
}