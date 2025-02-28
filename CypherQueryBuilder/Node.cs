using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;

namespace CypherQueryBuilder;

public class Node(string alias) : Entity(alias)
{
    public Node(string alias, string label) : this(alias) => labels.Add(label);

    public Node(Type t, int aliasSequence = 0) : this($"{t.Name}{aliasSequence}", t.CypherName()) => UnderlyingType = t;
    public MatchQuery ToMatchQuery() => Query.Match(this);

    public virtual HashSet<Relation> Relations { get; protected set; } = [];
    protected override (string start, string end) Brackets => ("(", ")");
    protected HashSet<(Relation, bool)> NewRelations { get; set; } = [];
    /// <summary>
    /// Create a new Instance of <paramref name="node"/> type <typeparamref name="T"/> with alias suffixed with <paramref name="sequence"/>
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns>New <paramref name="node"/> of type T</returns>
    /// <remarks><paramref name="sequence"/> will be default to zero if not provided</remarks>
    /// <seealso cref="Instance{T}(T, int)"/>
    public static Node<T> Instance<T>(int sequence = 0) => new(sequence);
    /// <summary>
    /// Create a new Instance of <paramref name="node"/> type <typeparamref name="T"/> with alias suffixed with <paramref name="sequence"/>
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <param name="sequence"></param>
    /// <returns>New <paramref name="node"/> of type T</returns>
    /// <remarks><paramref name="sequence"/> will be default to zero if not provided</remarks>
    /// <seealso cref="Instance{T}(int)"/>
    public static Node<T> Instance<T>(T obj, int sequence = 0) => Instance<T>(sequence).TranslateProperties(obj);
    /// <summary>
    /// Compiles this instance Cipher queryable string format.
    /// </summary>
    /// <returns>ValueTuple of (string match, string where).</returns>
    public override (string match, string where) Compile(HashSet<string> matchedAliases)
    {
        var (m, wh) = base.Compile(matchedAliases);
        if (string.IsNullOrEmpty(m))
            return (m, wh);
        CompileRelation(matchedAliases, ref m, ref wh); //List<string> matchedAliases may be passed here too
        matchedAliases.Add(Alias);
        return (m, wh);
    }

    private void CompileRelation(HashSet<string> matchedAliases, ref string m, ref string wh)
    {
        if (Relations.Count == 0) return;
        var mStarts = new HashSet<string>(Relations.Count);
        foreach (var r in Relations)
        {
            var (rm, rwh) = r.Compile(matchedAliases);
            mStarts.Add(m + rm);
            if (!string.IsNullOrEmpty(rwh))
                wh = string.IsNullOrEmpty(wh) ? rwh : string.Join(" AND ", wh, rwh);
        }
        m = string.Join(", ", mStarts);
    }

    public override (string match, string where) Compile(HashSet<string> matchedAliases, ref Dictionary<string, object?> parameters)
    {
        var (m, wh) = base.Compile(matchedAliases, ref parameters);
        if (string.IsNullOrEmpty(m))
            return (m, wh);
        CompileRelation(matchedAliases, ref m, ref wh);
        return (m, wh);
    }
    public override Node<T> TranslateProperties<T>([NotNull] T obj) => (Node<T>)base.TranslateProperties(obj);

    public override Node Where(string filter) => (Node)base.Where(filter);
    /// <summary>
    /// Applies the labels fo the node.
    /// </summary>
    /// <param name="labels">The labels.</param>
    /// <returns></returns>
    public override Node WithLabels(params string[] labels) => (Node)base.WithLabels(labels);
    /// <summary>
    /// Configure the property.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The same <paramref name="node"/></returns>
    /// <seealso cref="WithProperty(string, object?)"/>
    public override Node WithProperty(object obj)
    {
        AddProperty(obj);
        return this;
    }
    /// <summary>
    /// Configure the property.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The same <paramref name="node"/></returns>
    /// <seealso cref="WithProperty(object)"/>
    public override Node WithProperty(string key, object? value)
    {
        AddProperty(key, value);
        return this;
    }
    /// <summary>
    /// Configure the relation with another node.
    /// </summary>
    /// <param name="to">To.</param>
    /// <param name="relationAlias">The relation alias.</param>
    /// <param name="relationProperties">The relation properties.</param>
    /// <param name="isForward">if set to <c>true</c> [is forward].</param>
    /// <param name="labels">The labels.</param>
    /// <returns>The same <paramref name="node"/></returns>
    public Node WithRelation(Node to, string relationAlias, object? relationProperties = null, bool isForward = true, params string[] labels)
    {
        var r = new Relation(relationAlias);
        AttachRelation(to, isForward, labels, r);
        if (relationProperties != null)
            r = r.WithProperty(relationProperties);
        Relations.Add(r);
        return this;
    }
    /// <summary>Withes the relation.</summary>
    /// <typeparam name="R"></typeparam>
    /// <param name="to">To.</param>
    /// <param name="instance">The instance for the relation.</param>
    /// <param name="aliasSequence">The alias sequence for the relation.</param>
    /// <param name="isForward">if set to <c>true</c> [is forward].</param>
    /// <param name="expr"></param>
    /// <param name="labels">The labels.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    /// <example>
    ///   <code>var r = 2010;
    /// var actor = new Person { FullName = "Debjit", Age = 80 };
    /// var mNode = Node&lt;Movie&gt;.Instance().Where(p =&gt; p.ReleaseYear &gt; 500);
    /// mNode.WithRelation(actor.AsNode(), new ActedIn() { ReleaseYear = 2009 });</code>
    /// </example>
    public Node WithRelation<R>(Node to, R instance, int aliasSequence = 0, bool isForward = true, params string[] labels)
    {
        var r = new Relation<R>(aliasSequence);
        AttachRelation(to, isForward, labels, r);
        r.TranslateProperties(instance);
        Relations.Add(r);
        return this;
    }
    public virtual Node RelatedTo<R>(Node to, R instance, int aliasSequence = 0, bool isForward = true, Expression<Func<R, bool>>? expr = null, params string[] labels)
    {
        var r = new Relation<R>(aliasSequence);
        if (expr != null)
            r.Where(expr);
        AttachRelation(to, isForward, labels, r);
        r.TranslateProperties(instance);
        Relations.Add(r);
        return this;
    }
    public virtual Node RelatedTo<R>(Node to, int aliasSequence = 0, bool isForward = true, Expression<Func<R, bool>>? expr = null, params string[] labels) where R : new()
    {
        var instance = new R();
        RelatedTo(to, instance, aliasSequence, isForward, expr, labels);
        return this;
    }
    protected static void AttachRelation(Node to, bool isForward, string[] labels, Relation r)
    {
        r = r.WithLabels(labels);
        if (isForward)
            r.To(to);
        else
            r.From(to);
    }

    internal string CompileNewRelations(ISet<Node> existingNodes, Dictionary<string, object?>? parameters, HashSet<Node> creationConsideredFor)
    {
        if (NewRelations.Count == 0)
            return string.Empty;
        StringBuilder sb = new();
        foreach (var r in NewRelations)
        {
            var toMerge = r.Item2;
            var command = toMerge ? "MERGE " : "CREATE ";
            sb.AppendLine();
            if (!existingNodes.Contains(this) && !creationConsideredFor.Contains(this))
            {
                sb.Append($"{command}");
                sb.Append(CompileToCreate(false, parameters));
                creationConsideredFor.Add(this);

            }
            else
                sb.Append($"{command} ({Alias})");//TODO: may require properties too
            if (existingNodes.Contains(r.Item1.EndNode))
                sb.Append(r.Item1.CompileToCreateWithoutNode(parameters));
            else
            {
                sb.Append(r.Item1.CompileToCreate(false, parameters));
                existingNodes.Add(r.Item1.EndNode);
            }
        }
        return sb.ToString();
    }

    internal override string CompileToCreate(bool aliasOnly = false, Dictionary<string, object?>? parameters = null)
    {
        var q = new StringBuilder(base.CompileToCreate(aliasOnly, parameters));
        foreach (var r in Relations)
        {
            var rq = r.CompileToCreate(aliasOnly, parameters);
            q.Append(rq);
        }
        return q.ToString();
    }

    internal Node CreateRelationWith(Node to, string alias, string label, bool toMerge = false, object? properties = null)
    {
        var r = new Relation(alias, label).WithLabels(label).To(to);
        if (properties != null)
            r = r.WithProperty(properties);
        NewRelations.Add((r, toMerge));
        return this;
    }
}

public class Node<T>(int aliasSequence = 0) : Node(typeof(T), aliasSequence)
{
    protected HashSet<Expression<Func<T, bool>>> FilterExpressions = [];
    /// <summary>
    /// Create a new Instance of <paramref name="node"/> type <typeparamref name="T"/> with alias suffixed with <paramref name="sequence"/>
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns>New <paramref name="node"/> of type T</returns>
    /// <remarks><paramref name="sequence"/> will be default to zero if not provided</remarks>
    /// <seealso cref="Instance(int)"/>
    /// <seealso cref="Instance(out Node{T}, int)"/>
    public static Node<T> Instance(int sequence = 0) => Instance<T>(sequence);
    /// <summary>Create a new Instance of <paramref name="node" /> type <span class="typeparameter">T</span> with alias suffixed with <paramref name="sequence" /></summary>
    /// <param name="node">out parameter</param>
    /// <param name="sequence"></param>
    /// <returns>New <paramref name="node" /> of type T</returns>
    /// <remarks>
    ///   <paramref name="sequence" /> will be default to zero if not provided</remarks>
    /// <example>
    ///   <code>Node&lt;Domain&gt;.Instance(out var domainNode).Where(p =&gt; p.Uid == "TestDomain");
    /// Node&lt;Group&gt;.Instance(out var groupNode).WithProperty(new { Uid = "gId_1", Name = "GName", Domain = "TestDomain" });
    /// var q = Query.Match(domainNode)
    ///     .CreateRelation("hg", "HAS_DOMAIN", groupNode, domainNode, false, new { DomainId = "TestDomain", GroupId = "gId_1" });
    /// var (cq, parameters) = q.CompileWithParemeters();
    /// Console.WriteLine(cq);</code>
    /// </example>
    /// <seealso cref="Instance(int)" />
    /// <seealso cref="Instance(T, int)">Instance(T, int)</seealso>
    public static Node<T> Instance(out Node<T> node, int sequence = 0)
    {
        node = Instance<T>(sequence);
        return node;
    }
    public T Model { get; protected set; }
    /// <summary>
    /// Create a new Instance of <paramref name="node"/> type <typeparamref name="T"/> with alias suffixed with <paramref name="sequence"/>
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <param name="sequence">The sequence.</param>
    /// <returns>New <paramref name="node"/> of type T</returns>
    /// <remarks><paramref name="sequence"/> will be default to zero if not provided</remarks>
    /// <seealso cref="Instance(int)"/>
    /// <seealso cref="Instance(out Node{T}, int)"/>
    public static Node<T> Instance(T obj, int sequence = 0)
    {
        var n = Instance<T>(obj, sequence);
        n.Model = obj;
        return n;
    }

    protected override string BuildFilter()
    {
        List<string> filters = new(FilterExpressions.Count + 1);
        foreach (var expr in FilterExpressions)
            filters.Add(IEntity.ToCypherExpression(expr, Alias));
        var traanslated = string.Join(" AND ", filters);
        return string.IsNullOrWhiteSpace(BasicFilter) ? traanslated : $"{BasicFilter} AND {traanslated}";
    }

    protected override string BuildFilter(ref Dictionary<string, object?> parameters)
    {
        List<string> filters = new(FilterExpressions.Count + 1);
        foreach (var expr in FilterExpressions)
            filters.Add(IEntity.ToParameterizedCypherExpression(expr, Alias, ref parameters));
        var translated = string.Join(" AND ", filters);
        if (string.IsNullOrWhiteSpace(BasicFilter))
            return translated;
        else if (string.IsNullOrWhiteSpace(translated))
            return BasicFilter;
        else
            return string.Join(" AND ", BasicFilter, translated);
    }
    /// <summary>
    /// Applies filter or Where clause.
    /// </summary>
    /// <param name="expr">The expr.</param>
    /// <returns>The same <paramref name="node"/> of type T</returns>
    public Node<T> Where(Expression<Func<T, bool>> expr)
    {
        FilterExpressions.Add(expr);
        return this;
    }
    /// <summary>
    /// Configure the property.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The same <paramref name="node"/> of type T</returns>
    /// <seealso cref="WithProperty(string, object?)"/>
    public override Node<T> WithProperty(object obj)
    {
        AddProperty(obj);
        return this;
    }
    /// <summary>
    /// Configure the property.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns></returns>
    public Node<T> WithProperty([NotNull] T obj)
    {
        AddProperty(obj!);
        return this;
    }
    /// <summary>
    /// Configure the property.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The same <paramref name="node"/> of type T</returns>
    /// <seealso cref="WithProperty(object)"/>
    public override Node<T> WithProperty(string key, object? value)
    {
        AddProperty(key, value);
        return this;
    }
    public override Node<T> RelatedTo<R>(Node to, R instance, int aliasSequence = 0, bool isForward = true, Expression<Func<R, bool>>? expr = null, params string[] labels)
    {
        base.RelatedTo(to, instance, aliasSequence, isForward, expr, labels);
        return this;
    }
    public Node<T> RelatedTo<R>(Node to, int aliasSequence = 0, bool isForward = true, Expression<Func<R, bool>>? expr = null, params string[] labels) where R : new()
    {
        base.RelatedTo(to, aliasSequence, isForward, expr, labels);
        return this;
    }
}