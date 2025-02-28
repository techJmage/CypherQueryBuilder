using Currying;
using ExpressionTreeToString;
using System.Linq.Expressions;
using System.Reflection;

namespace CypherQueryBuilder;

public interface IEntity
{
    string Alias { get; }
    Type UnderlyingType { get; set; }
    string BasicFilter { get; set; }

    (string match, string where) Compile(HashSet<string> matchedAliases);

    Entity WithLabels(params string[] labels);

    IEntity WithProperty(object obj);

    IEntity WithProperty(string key, object? value);

    static Dictionary<string, string> GetMap<T>(string alias) => typeof(T).GetCypherPropertyMap(alias);

    public static string ToCypherExpression<T>(Expression<Func<T, bool>> filter, string alias) => filter.ToCypherString(alias.Pipe(GetMap<T>));

    public static string ToParameterizedCypherExpression<T>(Expression<Func<T, bool>> filter, string alias, ref Dictionary<string, object?> parameters) =>
        filter.ToParameterizedCypherString(alias.Pipe(GetMap<T>), ref parameters);

    public static string GetCypherName(PropertyInfo p) =>
        p.GetCustomAttributes(typeof(CypherPropertyAttribute), true).FirstOrDefault().Pipe(CypherName, p.Name);

    public static string CypherName(object? attr, string propertName) =>
        attr is CypherPropertyAttribute attribute ? attribute.Name ?? propertName : string.Empty;
}