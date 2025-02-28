using System.Collections;
using ZSpitz.Util;

namespace CypherQueryBuilder;

public static class Extensions
{
    public static string ToEquatableFormat(this object value, Dictionary<string, object?>? parameters = null)
    {
        if (parameters == null)
            return value.ToCypherPropertyString();
        else
            return value.Parameterize(ref parameters);
    }
    public static string ToCypherPropertyString(this object value)
    {
        if (value is string)
            return $"'{value.ToString()?.Replace("'", "\\'")}'";
        else if (value is IEnumerable lst)
        {
            var strLst = new List<string>();
            foreach (var item in lst)
                strLst.Add(item.ToCypherPropertyString());
            var v = '[' + string.Join(',', strLst) + ']';
            return v;
        }
        else if (value is DateTime dt)
            return $"datetime('{dt:s}Z')";
        else if (value is DateTimeOffset dtOffet)
            return $"datetime('{dtOffet:s}Z')";
        else
            return $"{value}";
    }
    public static string Parameterize(this object value, ref Dictionary<string, object?> parameters)
    {
        var pName = $"p{parameters.Count}";
        parameters.Add(pName, value);
        return $"${pName}";
    }
    public static Dictionary<string, string> GetCypherPropertyMap(this Type t, string? alias = null)
    {
        var ps = t.GetProperties();
        if (!string.IsNullOrWhiteSpace(alias))
            alias += ".";
        int aliasLength = alias?.Length ?? 0;
        var filtered = ps.Select(p => new KeyValuePair<string, string>(
            p.Name,
            $"{alias}{IEntity.GetCypherName(p)}"))
        .Where(p => p.Value.Length > aliasLength).ToDictionary(k => k.Key, v => v.Value);
        return filtered;
    }

    public static string[] GetCypherProperties(this Type t, string? alias = null)
    {
        var ps = t.GetProperties();
        if (!string.IsNullOrWhiteSpace(alias))
            alias += ".";
        int aliasLength = alias?.Length ?? 0;
        var filtered = ps.Select(p => $"{alias}{IEntity.GetCypherName(p)}")
        .Where(p => p.Length > aliasLength).ToArray();
        return filtered;
    }
    public static string CypherName(this Type t)
    {
        var attr = t.GetCustomAttributes(typeof(CypherEntityAttribute), true).FirstOrDefault();
        if (attr == null)
            return t.Name;
        var cAttr = attr as CypherEntityAttribute;
        return cAttr?.Name ?? t.Name;
    }

    public static Node<T> AsNode<T>(this T obj, int sequence = 0)
    {
        var ps = obj.GetType().GetProperties();
        var filtered = ps.Select(p => new
        {
            Name = IEntity.GetCypherName(p),
            Value = p.GetValue(obj)
        });
        var node = new Node<T>(sequence);
        foreach (var p in filtered)
            if (!string.IsNullOrEmpty(p.Name))
                node = node.WithProperty(p.Name, p.Value);
        return node;
    }

    public static Node AsNode<T>(this Type obj, int sequence = 0) => new(obj, sequence);

    public static Relation AsRelation<T>(this Type obj, int sequence = 0) => new(obj, sequence);
}