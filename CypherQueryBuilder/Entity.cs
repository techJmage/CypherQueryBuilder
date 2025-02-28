using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CypherQueryBuilder;

public class Entity(string alias) : IEntity
{
    protected HashSet<string> labels = [];
    protected Dictionary<string, object> propertyValues = [];

    public Entity(string alias, string label) : this(alias) => labels.Add(label);

    public Entity(Type t, int aliasSequence = 0) : this($"{t.Name}{aliasSequence}", t.Name) => UnderlyingType = t;

    public string Alias => alias;
    public string BasicFilter { get; set; }
    public Type UnderlyingType { get; set; } = typeof(object);
    protected virtual (string start, string end) Brackets => ("(", ")");

    protected virtual string BuildFilter() => BasicFilter;

    protected virtual string BuildFilter(ref Dictionary<string, object?> parameters) => BasicFilter;

    public virtual (string match, string where) Compile(HashSet<string> matchedAliases)
    {
        var alreadyMatched = matchedAliases.Contains(Alias);
        //if (matchedAliases.Contains(Alias))
        //    return (string.Empty, string.Empty);
        StringBuilder sb = new();
        var (start, end) = Brackets;
        sb.Append($"{start}{alias}");
        if (alreadyMatched)
            sb.Append(end);
        else
        {
            var labeled = string.Join(string.Empty, labels.Select(p => $":{p}"));
            sb.Append($"{labeled} {ToPropertyInsider()}{end}");
        }
        return (sb.ToString(), BuildFilter());
    }
    /// <summary>
    /// Compiles the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns></returns>
    public virtual (string match, string where) Compile(HashSet<string> matchedAliases, ref Dictionary<string, object?> parameters)
    {
        if (matchedAliases.Contains(Alias))
            return (string.Empty, string.Empty);
        StringBuilder sb = new();
        var (start, end) = Brackets;
        sb.Append($"{start}{alias}");
        var labeled = string.Join(string.Empty, labels.Select(p => $":{p}"));
        sb.Append($"{labeled} {ToPropertyInsider(parameters)}{end}");
        return (sb.ToString(), BuildFilter(ref parameters));
    }
    /// <summary>
    /// Translates the properties.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object.</param>
    /// <returns></returns>
    public virtual Entity TranslateProperties<T>([NotNull] T obj)
    {
        var ps = typeof(T).GetProperties();
        var filtered = ps.Select(p => new
        {
            Name = IEntity.GetCypherName(p),
            Value = p.GetValue(obj)
        });
        foreach (var p in filtered)
            if (!string.IsNullOrEmpty(p.Name))
                AddProperty(p.Name, p.Value);
        return this;
    }

    public virtual Entity Where(string filter)
    {
        BasicFilter = filter;
        return this;
    }

    public virtual Entity WithLabels(params string[] labels)
    {
        foreach (var label in labels)
            this.labels.Add(label);
        return this;
    }

    public virtual IEntity WithProperty(object obj)
    {
        AddProperty(obj);
        return this;
    }

    public virtual IEntity WithProperty(string key, object? value)
    {
        AddProperty(key, value);
        return this;
    }

    protected void AddProperty([NotNull] object obj)
    {
        var ps = obj.GetType().GetProperties();
        foreach (var p in ps)
            AddProperty(p.Name, p.GetValue(obj));
    }

    protected void AddProperty(string key, object? value)
    {
        if (value != null)
            propertyValues.Add(key, value);
    }

    internal virtual string CompileToCreate(bool aliasOnly = false, Dictionary<string, object?>? parameters = null)
    {
        StringBuilder sb = new();
        var (start, end) = Brackets;
        sb.Append($"{start}{alias}");
        if (!aliasOnly)
        {
            var labeled = string.Join(string.Empty, labels.Select(p => $":{p}"));
            sb.Append($"{labeled} {ToPropertyInsider(parameters)}{end}");
        }
        else
            sb.Append(end);
        return sb.ToString();
    }

    protected string ToPropertyInsider(Dictionary<string, object?>? parameters = null)
    {
        if (propertyValues.Count == 0)
            return string.Empty;
        var s = "{" + string.Join(',', propertyValues.Select(x => $"{x.Key}:{x.Value.ToEquatableFormat(parameters)}")) + "}";
        return s;
    }
}