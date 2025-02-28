using System.Linq.Expressions;

namespace CypherQueryBuilder;

public class Relation(string alias) : Entity(alias)
{
    protected Node end;
    protected bool isForward = true;

    internal Relation(string alias, string label) : this(alias) => labels.Add(label);

    internal Relation(Type t, int aliasSequence = 0) : this($"{t.Name}{aliasSequence}", t.CypherName()) => UnderlyingType = t;

    public Node EndNode => end;
    protected override (string start, string end) Brackets => ("[", "]");

    public override (string match, string where) Compile(HashSet<string> matchedAliases)
    {
        var (match, where) = base.Compile(matchedAliases);
        var (endMatch, endWhere) = end.Compile(matchedAliases);
        if (!string.IsNullOrEmpty(endWhere))
            where = string.IsNullOrEmpty(where) ? endWhere : string.Join(" AND ", where, endWhere);
        if (isForward)
            match = $"-{match}->{endMatch}";
        else
            match = $"<-{match}-{endMatch}";
        return (match, where);
    }

    public Relation From(Node from)
    {
        end = from;
        isForward = false;
        return this;
    }

    public Relation To(Node to)
    {
        end = to;
        isForward = true;
        return this;
    }

    public override Relation Where(string filter) => (Relation)base.Where(filter);

    public override Relation WithLabels(params string[] labels) => (Relation)base.WithLabels(labels);

    public override Relation WithProperty(object obj)
    {
        AddProperty(obj);
        return this;
    }

    public override Relation WithProperty(string key, object? value)
    {
        AddProperty(key, value);
        return this;
    }

    internal override string CompileToCreate(bool aliasOnly = false, Dictionary<string, object?>? parameters = null)
    {
        var endQ = end.CompileToCreate(aliasOnly, parameters);
        return CompileCore(aliasOnly, endQ, parameters);
    }

    internal string CompileToCreateWithoutNode(Dictionary<string, object?>? parameters) => CompileCore(false, end.CompileToCreate(true, parameters), parameters);

    private string CompileCore(bool aliasOnly, string endQ, Dictionary<string, object?>? parameters)
    {
        var q = base.CompileToCreate(aliasOnly, parameters);
        if (isForward)
            q = $"-{q}->{endQ}";
        else
            q = $"<-{q}-{endQ}";
        return q;
    }
}

public class Relation<T>(int aliasSequence = 0) : Relation(typeof(T), aliasSequence)
{
    public override Relation<T> WithLabels(params string[] labels) => (Relation<T>)base.WithLabels(labels);

    public override Relation<T> TranslateProperties<T>(T obj) => (Relation<T>)base.TranslateProperties(obj);
    /// <summary>
    /// Applies filter or Where clause.
    /// </summary>
    /// <param name="expr">The expr.</param>
    /// <returns>The same <paramref name="Relation"/> of type T</returns>
    public Relation<T> Where(Expression<Func<T, bool>> expr)
    {
        BasicFilter = IEntity.ToCypherExpression(expr, Alias);
        return this;
    }

    public override Relation<T> WithProperty(object obj)
    {
        AddProperty(obj);
        return this;
    }

    public override Relation<T> WithProperty(string key, object? value)
    {
        AddProperty(key, value);
        return this;
    }
}