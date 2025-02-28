#### [CypherQueryBuilder](index.md 'index')

## CypherQueryBuilder Assembly
### Namespaces

<a name='CypherQueryBuilder'></a>

## CypherQueryBuilder Namespace
### Classes

<a name='CypherQueryBuilder.CreateQuery'></a>

## CreateQuery Class

```csharp
public class CreateQuery : CypherQueryBuilder.MatchQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery') &#129106; CreateQuery
### Methods

<a name='CypherQueryBuilder.CreateQuery.Compile()'></a>

## CreateQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

### See Also
- [CompileWithParemeters(Dictionary&lt;string,object&gt;)](index.md#CypherQueryBuilder.CreateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_) 'CypherQueryBuilder.CreateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary<string,object>)')

<a name='CypherQueryBuilder.CreateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_)'></a>

## CreateQuery.CompileWithParemeters(Dictionary<string,object>) Method

Compiles the instance to Cypher Query string with paremeters.

```csharp
public override (string query,System.Collections.Generic.Dictionary<string,object?> parameters) CompileWithParemeters(System.Collections.Generic.Dictionary<string,object?>? startParameters=null);
```
#### Parameters

<a name='CypherQueryBuilder.CreateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_).startParameters'></a>

`startParameters` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
ValueTuple<string, Dictionary<string, Nullable<Object>>>

### Example
  
Usage:  
  
```csharp  
var metaDataCount = 2;  
            var metaDataNodes = new Node<MetaData>[metaDataCount];  
            for (int i = 0; i < metaDataCount; i++)  
            {  
                var id = $"mId_{i}";  
                metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);  
            }  
            var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");  
            var (mq, parameters) = Query.Match(domainNode, metaDataNodes).CompileAsParemeterized();  
```

### See Also
- [Compile()](index.md#CypherQueryBuilder.CreateQuery.Compile() 'CypherQueryBuilder.CreateQuery.Compile()')

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object)'></a>

## CreateQuery.CreateRelation(string, string, Node, Node, bool, object) Method

Creates the relation.

```csharp
public override CypherQueryBuilder.CreateQuery CreateRelation(string alias, string label, CypherQueryBuilder.Node from, CypherQueryBuilder.Node to, bool toMerge=false, object? properties=null);
```
#### Parameters

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).label'></a>

`label` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The label.

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).from'></a>

`from` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

From.

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).to'></a>

`to` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

To.

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).toMerge'></a>

`toMerge` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [to merge].

<a name='CypherQueryBuilder.CreateQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).properties'></a>

`properties` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The properties.

#### Returns
[CreateQuery](index.md#CypherQueryBuilder.CreateQuery 'CypherQueryBuilder.CreateQuery')

<a name='CypherQueryBuilder.DeleteQuery'></a>

## DeleteQuery Class

```csharp
public class DeleteQuery : CypherQueryBuilder.MatchQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery') &#129106; DeleteQuery
### Methods

<a name='CypherQueryBuilder.DeleteQuery.Compile()'></a>

## DeleteQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

<a name='CypherQueryBuilder.DeleteQuery.Delete_T_(T[])'></a>

## DeleteQuery.Delete<T>(T[]) Method

Deletes the specified entities.

```csharp
public override CypherQueryBuilder.DeleteQuery Delete<T>(params T[] entities)
    where T : CypherQueryBuilder.Entity;
```
#### Type parameters

<a name='CypherQueryBuilder.DeleteQuery.Delete_T_(T[]).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.DeleteQuery.Delete_T_(T[]).entities'></a>

`entities` [T](index.md#CypherQueryBuilder.DeleteQuery.Delete_T_(T[]).T 'CypherQueryBuilder.DeleteQuery.Delete<T>(T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The entities to delete.

#### Returns
[DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')  
DeleteQuery

<a name='CypherQueryBuilder.DeleteQuery.Detach_T_(T[])'></a>

## DeleteQuery.Detach<T>(T[]) Method

Detaches, i.e. delete with all the associated relations (if it is a node), the specified entities.

```csharp
public override CypherQueryBuilder.DeleteQuery Detach<T>(params T[] entities)
    where T : CypherQueryBuilder.Entity;
```
#### Type parameters

<a name='CypherQueryBuilder.DeleteQuery.Detach_T_(T[]).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.DeleteQuery.Detach_T_(T[]).entities'></a>

`entities` [T](index.md#CypherQueryBuilder.DeleteQuery.Detach_T_(T[]).T 'CypherQueryBuilder.DeleteQuery.Detach<T>(T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The entities to detache and delete.

#### Returns
[DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')  
DeleteQuery

<a name='CypherQueryBuilder.DeleteQuery.ReleaseResources()'></a>

## DeleteQuery.ReleaseResources() Method

Releases the resources, used while disposing.

```csharp
public override void ReleaseResources();
```

<a name='CypherQueryBuilder.Entity'></a>

## Entity Class

```csharp
public class Entity :
CypherQueryBuilder.IEntity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Entity

Derived  
&#8627; [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

Implements [CypherQueryBuilder.IEntity](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity 'CypherQueryBuilder.IEntity')
### Methods

<a name='CypherQueryBuilder.Entity.Compile(System.Collections.Generic.HashSet_string_,System.Collections.Generic.Dictionary_string,object_)'></a>

## Entity.Compile(HashSet<string>, Dictionary<string,object>) Method

Compiles the specified parameters.

```csharp
public virtual (string match,string where) Compile(System.Collections.Generic.HashSet<string> matchedAliases, ref System.Collections.Generic.Dictionary<string,object?> parameters);
```
#### Parameters

<a name='CypherQueryBuilder.Entity.Compile(System.Collections.Generic.HashSet_string_,System.Collections.Generic.Dictionary_string,object_).matchedAliases'></a>

`matchedAliases` [System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='CypherQueryBuilder.Entity.Compile(System.Collections.Generic.HashSet_string_,System.Collections.Generic.Dictionary_string,object_).parameters'></a>

`parameters` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

The parameters.

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')

<a name='CypherQueryBuilder.Entity.TranslateProperties_T_(T)'></a>

## Entity.TranslateProperties<T>(T) Method

Translates the properties.

```csharp
public virtual CypherQueryBuilder.Entity TranslateProperties<T>(T obj);
```
#### Type parameters

<a name='CypherQueryBuilder.Entity.TranslateProperties_T_(T).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.Entity.TranslateProperties_T_(T).obj'></a>

`obj` [T](index.md#CypherQueryBuilder.Entity.TranslateProperties_T_(T).T 'CypherQueryBuilder.Entity.TranslateProperties<T>(T).T')

The object.

#### Returns
[Entity](index.md#CypherQueryBuilder.Entity 'CypherQueryBuilder.Entity')

<a name='CypherQueryBuilder.MatchQuery'></a>

## MatchQuery Class

```csharp
public class MatchQuery : CypherQueryBuilder.QueryBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; MatchQuery

Derived  
&#8627; [CreateQuery](index.md#CypherQueryBuilder.CreateQuery 'CypherQueryBuilder.CreateQuery')  
&#8627; [DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')  
&#8627; [UnionQuery](index.md#CypherQueryBuilder.UnionQuery 'CypherQueryBuilder.UnionQuery')  
&#8627; [UpdateQuery](index.md#CypherQueryBuilder.UpdateQuery 'CypherQueryBuilder.UpdateQuery')
### Methods

<a name='CypherQueryBuilder.MatchQuery.BuildMatchPart(System.Text.StringBuilder)'></a>

## MatchQuery.BuildMatchPart(StringBuilder) Method

Builds the match part.

```csharp
protected void BuildMatchPart(System.Text.StringBuilder sb);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.BuildMatchPart(System.Text.StringBuilder).sb'></a>

`sb` [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')

The sb.

<a name='CypherQueryBuilder.MatchQuery.Compile()'></a>

## MatchQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

### See Also
- [CompileWithParemeters(Dictionary&lt;string,object&gt;)](index.md#CypherQueryBuilder.MatchQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_) 'CypherQueryBuilder.MatchQuery.CompileWithParemeters(System.Collections.Generic.Dictionary<string,object>)')

<a name='CypherQueryBuilder.MatchQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_)'></a>

## MatchQuery.CompileWithParemeters(Dictionary<string,object>) Method

Compiles the instance to Cypher Query string with paremeters.

```csharp
public virtual (string query,System.Collections.Generic.Dictionary<string,object?> parameters) CompileWithParemeters(System.Collections.Generic.Dictionary<string,object?>? startParameters=null);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_).startParameters'></a>

`startParameters` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
ValueTuple<string, Dictionary<string, Nullable<Object>>>

### Example
  
Usage:  
  
```csharp  
var metaDataCount = 2;  
            var metaDataNodes = new Node<MetaData>[metaDataCount];  
            for (int i = 0; i < metaDataCount; i++)  
            {  
                var id = $"mId_{i}";  
                metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);  
            }  
            var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");  
            var (mq, parameters) = Query.Match(domainNode, metaDataNodes).CompileAsParemeterized();  
```

### See Also
- [Compile()](index.md#CypherQueryBuilder.MatchQuery.Compile() 'CypherQueryBuilder.MatchQuery.Compile()')

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object)'></a>

## MatchQuery.CreateRelation(string, string, Node, Node, bool, object) Method

Creates the relation.

```csharp
public virtual CypherQueryBuilder.CreateQuery CreateRelation(string alias, string label, CypherQueryBuilder.Node from, CypherQueryBuilder.Node to, bool toMerge=false, object? properties=null);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).label'></a>

`label` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The label.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).from'></a>

`from` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

From.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).to'></a>

`to` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

To.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).toMerge'></a>

`toMerge` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [to merge].

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).properties'></a>

`properties` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The properties.

#### Returns
[CreateQuery](index.md#CypherQueryBuilder.CreateQuery 'CypherQueryBuilder.CreateQuery')

<a name='CypherQueryBuilder.MatchQuery.Delete_T_(T[])'></a>

## MatchQuery.Delete<T>(T[]) Method

Deletes the specified entities.

```csharp
public virtual CypherQueryBuilder.DeleteQuery Delete<T>(params T[] entities)
    where T : CypherQueryBuilder.Entity;
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Delete_T_(T[]).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Delete_T_(T[]).entities'></a>

`entities` [T](index.md#CypherQueryBuilder.MatchQuery.Delete_T_(T[]).T 'CypherQueryBuilder.MatchQuery.Delete<T>(T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The entities.

#### Returns
[DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')

<a name='CypherQueryBuilder.MatchQuery.Detach_T_(T[])'></a>

## MatchQuery.Detach<T>(T[]) Method

Detaches the specified entities.

```csharp
public virtual CypherQueryBuilder.DeleteQuery Detach<T>(params T[] entities)
    where T : CypherQueryBuilder.Entity;
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Detach_T_(T[]).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Detach_T_(T[]).entities'></a>

`entities` [T](index.md#CypherQueryBuilder.MatchQuery.Detach_T_(T[]).T 'CypherQueryBuilder.MatchQuery.Detach<T>(T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The entities.

#### Returns
[DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')

<a name='CypherQueryBuilder.MatchQuery.Limit(int)'></a>

## MatchQuery.Limit(int) Method

Limits the specified limit.

```csharp
public CypherQueryBuilder.MatchQuery Limit(int limit);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Limit(int).limit'></a>

`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The limit.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
MatchQuery

<a name='CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string)'></a>

## MatchQuery.OrderBy<T,K>(Expression<Func<T,K>>, string) Method

Orders the by.

```csharp
public virtual CypherQueryBuilder.MatchQuery OrderBy<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>> keySelector, string? alias=null);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).T'></a>

`T`

Entity (Node or Relation)

<a name='CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).K'></a>

`K`

The property of the T type Node or Relation on which order by will be applied.
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).keySelector'></a>

`keySelector` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).T 'CypherQueryBuilder.MatchQuery.OrderBy<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[K](index.md#CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).K 'CypherQueryBuilder.MatchQuery.OrderBy<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The key selector.

<a name='CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
MatchQuery

### Example
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var mNode = Node<Movie>.Instance(movie);  
            var q = Query  
                .Match(mNode, pNode)  
                .Return<Movie>()  
                .OrderBy<Movie, int>(m => m.ReleaseYear);  
```

### See Also
- [OrderByDescending{T, K}(Expression{Func{T, K}}, string?)](index.md#CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string) 'CypherQueryBuilder.MatchQuery.OrderByDescending<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string)')

<a name='CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string)'></a>

## MatchQuery.OrderByDescending<T,K>(Expression<Func<T,K>>, string) Method

Orders the by descending.

```csharp
public virtual CypherQueryBuilder.MatchQuery OrderByDescending<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>> keySelector, string? alias=null);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).T'></a>

`T`

Entity (Node or Relation)

<a name='CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).K'></a>

`K`

The property of the T type Node or Relation on which descending order by will be applied.
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).keySelector'></a>

`keySelector` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).T 'CypherQueryBuilder.MatchQuery.OrderByDescending<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[K](index.md#CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).K 'CypherQueryBuilder.MatchQuery.OrderByDescending<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The key selector.

<a name='CypherQueryBuilder.MatchQuery.OrderByDescending_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
MatchQuery

### Example
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var mNode = Node<Movie>.Instance(movie);  
            var q = Query  
                .Match(mNode, pNode)  
                .Return<Movie>()  
                .OrderByDescending<Movie, int>(m => m.ReleaseYear);  
```

### See Also
- [OrderBy{T, K}(Expression{Func{T, K}}, string?)](index.md#CypherQueryBuilder.MatchQuery.OrderBy_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,string) 'CypherQueryBuilder.MatchQuery.OrderBy<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, string)')

<a name='CypherQueryBuilder.MatchQuery.OrWhere(string)'></a>

## MatchQuery.OrWhere(string) Method

Ors the where.

```csharp
public CypherQueryBuilder.MatchQuery OrWhere(string clause);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.OrWhere(string).clause'></a>

`clause` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The clause.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return(string[])'></a>

## MatchQuery.Return(string[]) Method

Returns the specified returns.

```csharp
public virtual CypherQueryBuilder.MatchQuery Return(params string[] returns);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return(string[]).returns'></a>

`returns` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The returns.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## MatchQuery.Return<T>(Node<T>, Expression<Func<T,object>>, bool) Method

Returns the specified node.

```csharp
public virtual CypherQueryBuilder.MatchQuery Return<T>(CypherQueryBuilder.Node<T> node, System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).node'></a>

`node` [CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.MatchQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')

The node.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.MatchQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## MatchQuery.Return<T>(string, Expression<Func<T,object>>, bool) Method

Returns the specified alias.

```csharp
public virtual CypherQueryBuilder.MatchQuery Return<T>(string? alias, System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.MatchQuery.Return<T>(string, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## MatchQuery.Return<T>(Expression<Func<T,object>>, bool) Method

Returns the specified f.

```csharp
public CypherQueryBuilder.MatchQuery Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>>? f=null, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.MatchQuery.Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Skip(int)'></a>

## MatchQuery.Skip(int) Method

Skips the specified skip.

```csharp
public CypherQueryBuilder.MatchQuery Skip(int skip);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Skip(int).skip'></a>

`skip` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The skip.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Union(CypherQueryBuilder.MatchQuery)'></a>

## MatchQuery.Union(MatchQuery) Method

Unions the specified other.

```csharp
public CypherQueryBuilder.UnionQuery Union(CypherQueryBuilder.MatchQuery other);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Union(CypherQueryBuilder.MatchQuery).other'></a>

`other` [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

The other.

#### Returns
[UnionQuery](index.md#CypherQueryBuilder.UnionQuery 'CypherQueryBuilder.UnionQuery')

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string)'></a>

## MatchQuery.Update<T,K>(Expression<Func<T,K>>, Expression<Func<T,K>>, string) Method

Create Update Query.

```csharp
public virtual CypherQueryBuilder.UpdateQuery Update<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>> propertySelector, System.Linq.Expressions.Expression<System.Func<T,K>> valueSelector, string? alias=null);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).T'></a>

`T`

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).K'></a>

`K`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).propertySelector'></a>

`propertySelector` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).T 'CypherQueryBuilder.MatchQuery.Update<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, System.Linq.Expressions.Expression<System.Func<T,K>>, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[K](index.md#CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).K 'CypherQueryBuilder.MatchQuery.Update<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, System.Linq.Expressions.Expression<System.Func<T,K>>, string).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).valueSelector'></a>

`valueSelector` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).T 'CypherQueryBuilder.MatchQuery.Update<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, System.Linq.Expressions.Expression<System.Func<T,K>>, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[K](index.md#CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).K 'CypherQueryBuilder.MatchQuery.Update<T,K>(System.Linq.Expressions.Expression<System.Func<T,K>>, System.Linq.Expressions.Expression<System.Func<T,K>>, string).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='CypherQueryBuilder.MatchQuery.Update_T,K_(System.Linq.Expressions.Expression_System.Func_T,K__,System.Linq.Expressions.Expression_System.Func_T,K__,string).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UpdateQuery](index.md#CypherQueryBuilder.UpdateQuery 'CypherQueryBuilder.UpdateQuery')  
`UpdateQuery`

### Example
  
```csharp  
var r = 2010;  
            var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);  
            var q = Query  
                .Match(mNode)  
                .Update<Movie, int>(p => p.ReleaseYear, p => r)  
                .Return<Movie>()  
                .OrderBy<Movie, int>(m => m.ReleaseYear)  
                .Return<Movie>(p => new { p.Title, p.ReleaseYear });  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.MatchQuery.Where(string)'></a>

## MatchQuery.Where(string) Method

Wheres the specified clause.

```csharp
public CypherQueryBuilder.MatchQuery Where(string clause);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Where(string).clause'></a>

`clause` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The clause.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
<br/>

### Example
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var m = movie.AsNode().Where(p => p.ReleaseYear == 2001 || p.ReleaseYear < 1997 || p.Title == "D");  
            var n = new Node("n")  
                .WithLabels("Actor")  
                .WithProperty("name", "Clint Eastwood")  
                .WithRelation(m, "r", new { Role = "Hero" }, true, "ACTED_IN");  
            var q = Query  
                .Match(n).Where(m.BasicFilter)  
                .Return<Movie>(p => new { p.Title, p.ReleaseYear });  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.MatchQuery.Where_T_(System.Linq.Expressions.Expression_System.Func_T,bool__,string)'></a>

## MatchQuery.Where<T>(Expression<Func<T,bool>>, string) Method

Wheres the specified expr.

```csharp
public CypherQueryBuilder.MatchQuery Where<T>(System.Linq.Expressions.Expression<System.Func<T,bool>> expr, string? alias=null);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Where_T_(System.Linq.Expressions.Expression_System.Func_T,bool__,string).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Where_T_(System.Linq.Expressions.Expression_System.Func_T,bool__,string).expr'></a>

`expr` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Where_T_(System.Linq.Expressions.Expression_System.Func_T,bool__,string).T 'CypherQueryBuilder.MatchQuery.Where<T>(System.Linq.Expressions.Expression<System.Func<T,bool>>, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The expr.

<a name='CypherQueryBuilder.MatchQuery.Where_T_(System.Linq.Expressions.Expression_System.Func_T,bool__,string).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
<br/>

### Example
  
```csharp  
var r = 2010;  
            var actor = new Person { FullName = "Debjit", Age = 80 };  
            var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);  
            mNode.WithRelation(actor.AsNode(), new ActedIn() { ReleaseYear = 2009 });  
            var q = Query  
                .Match(mNode)  
                .Where<ActedIn>(p => p.ReleaseYear > 2000)  
                .Delete(mNode.Relation);  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.Node'></a>

## Node Class

```csharp
public class Node : CypherQueryBuilder.Entity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Entity](index.md#CypherQueryBuilder.Entity 'CypherQueryBuilder.Entity') &#129106; Node

Derived  
&#8627; [Node&lt;T&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')
### Methods

<a name='CypherQueryBuilder.Node.Compile(System.Collections.Generic.HashSet_string_)'></a>

## Node.Compile(HashSet<string>) Method

Compiles this instance Cipher queryable string format.

```csharp
public override (string match,string where) Compile(System.Collections.Generic.HashSet<string> matchedAliases);
```
#### Parameters

<a name='CypherQueryBuilder.Node.Compile(System.Collections.Generic.HashSet_string_).matchedAliases'></a>

`matchedAliases` [System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

Implements [Compile(HashSet&lt;string&gt;)](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.Compile#CypherQueryBuilder_IEntity_Compile_System_Collections_Generic_HashSet{System_String}_ 'CypherQueryBuilder.IEntity.Compile(System.Collections.Generic.HashSet{System.String})')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
ValueTuple of (string match, string where).

<a name='CypherQueryBuilder.Node.Instance_T_(int)'></a>

## Node.Instance<T>(int) Method

Create a new Instance of node type [T](index.md#CypherQueryBuilder.Node.Instance_T_(int).T 'CypherQueryBuilder.Node.Instance<T>(int).T') with alias suffixed with [sequence](index.md#CypherQueryBuilder.Node.Instance_T_(int).sequence 'CypherQueryBuilder.Node.Instance<T>(int).sequence')

```csharp
public static CypherQueryBuilder.Node<T> Instance<T>(int sequence=0);
```
#### Type parameters

<a name='CypherQueryBuilder.Node.Instance_T_(int).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.Node.Instance_T_(int).sequence'></a>

`sequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node.Instance_T_(int).T 'CypherQueryBuilder.Node.Instance<T>(int).T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
New node of type T

### Remarks
[sequence](index.md#CypherQueryBuilder.Node.Instance_T_(int).sequence 'CypherQueryBuilder.Node.Instance<T>(int).sequence') will be default to zero if not provided

### See Also
- [Instance&lt;T&gt;(T, int)](index.md#CypherQueryBuilder.Node.Instance_T_(T,int) 'CypherQueryBuilder.Node.Instance<T>(T, int)')

<a name='CypherQueryBuilder.Node.Instance_T_(T,int)'></a>

## Node.Instance<T>(T, int) Method

Create a new Instance of node type [T](index.md#CypherQueryBuilder.Node.Instance_T_(T,int).T 'CypherQueryBuilder.Node.Instance<T>(T, int).T') with alias suffixed with [sequence](index.md#CypherQueryBuilder.Node.Instance_T_(T,int).sequence 'CypherQueryBuilder.Node.Instance<T>(T, int).sequence')

```csharp
public static CypherQueryBuilder.Node<T> Instance<T>(T obj, int sequence=0);
```
#### Type parameters

<a name='CypherQueryBuilder.Node.Instance_T_(T,int).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.Node.Instance_T_(T,int).obj'></a>

`obj` [T](index.md#CypherQueryBuilder.Node.Instance_T_(T,int).T 'CypherQueryBuilder.Node.Instance<T>(T, int).T')

The object.

<a name='CypherQueryBuilder.Node.Instance_T_(T,int).sequence'></a>

`sequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node.Instance_T_(T,int).T 'CypherQueryBuilder.Node.Instance<T>(T, int).T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
New node of type T

### Remarks
[sequence](index.md#CypherQueryBuilder.Node.Instance_T_(T,int).sequence 'CypherQueryBuilder.Node.Instance<T>(T, int).sequence') will be default to zero if not provided

### See Also
- [Instance&lt;T&gt;(int)](index.md#CypherQueryBuilder.Node.Instance_T_(int) 'CypherQueryBuilder.Node.Instance<T>(int)')

<a name='CypherQueryBuilder.Node.WithLabels(string[])'></a>

## Node.WithLabels(string[]) Method

Applies the labels fo the node.

```csharp
public virtual CypherQueryBuilder.Node WithLabels(params string[] labels);
```
#### Parameters

<a name='CypherQueryBuilder.Node.WithLabels(string[]).labels'></a>

`labels` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The labels.

Implements [WithLabels(string[])](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.WithLabels#CypherQueryBuilder_IEntity_WithLabels_System_String[]_ 'CypherQueryBuilder.IEntity.WithLabels(System.String[])')

#### Returns
[Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

<a name='CypherQueryBuilder.Node.WithProperty(object)'></a>

## Node.WithProperty(object) Method

Configure the property.

```csharp
public virtual CypherQueryBuilder.Node WithProperty(object obj);
```
#### Parameters

<a name='CypherQueryBuilder.Node.WithProperty(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object.

Implements [WithProperty(object)](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.WithProperty#CypherQueryBuilder_IEntity_WithProperty_System_Object_ 'CypherQueryBuilder.IEntity.WithProperty(System.Object)')

#### Returns
[Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')  
The same node

### See Also
- [WithProperty(string, object)](index.md#CypherQueryBuilder.Node.WithProperty(string,object) 'CypherQueryBuilder.Node.WithProperty(string, object)')

<a name='CypherQueryBuilder.Node.WithProperty(string,object)'></a>

## Node.WithProperty(string, object) Method

Configure the property.

```csharp
public virtual CypherQueryBuilder.Node WithProperty(string key, object? value);
```
#### Parameters

<a name='CypherQueryBuilder.Node.WithProperty(string,object).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key.

<a name='CypherQueryBuilder.Node.WithProperty(string,object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The value.

Implements [WithProperty(string, object)](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.WithProperty#CypherQueryBuilder_IEntity_WithProperty_System_String,System_Object_ 'CypherQueryBuilder.IEntity.WithProperty(System.String,System.Object)')

#### Returns
[Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')  
The same node

### See Also
- [WithProperty(object)](index.md#CypherQueryBuilder.Node.WithProperty(object) 'CypherQueryBuilder.Node.WithProperty(object)')

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[])'></a>

## Node.WithRelation(Node, string, object, bool, string[]) Method

Configure the relation with another node.

```csharp
public CypherQueryBuilder.Node WithRelation(CypherQueryBuilder.Node to, string relationAlias, object? relationProperties=null, bool isForward=true, params string[] labels);
```
#### Parameters

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[]).to'></a>

`to` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

To.

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[]).relationAlias'></a>

`relationAlias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The relation alias.

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[]).relationProperties'></a>

`relationProperties` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The relation properties.

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[]).isForward'></a>

`isForward` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [is forward].

<a name='CypherQueryBuilder.Node.WithRelation(CypherQueryBuilder.Node,string,object,bool,string[]).labels'></a>

`labels` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The labels.

#### Returns
[Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')  
The same node

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[])'></a>

## Node.WithRelation<R>(Node, R, int, bool, string[]) Method

Withes the relation.

```csharp
public CypherQueryBuilder.Node WithRelation<R>(CypherQueryBuilder.Node to, R instance, int aliasSequence=0, bool isForward=true, params string[] labels);
```
#### Type parameters

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).R'></a>

`R`
#### Parameters

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).to'></a>

`to` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

To.

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).instance'></a>

`instance` [R](index.md#CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).R 'CypherQueryBuilder.Node.WithRelation<R>(CypherQueryBuilder.Node, R, int, bool, string[]).R')

The instance for the relation.

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).aliasSequence'></a>

`aliasSequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The alias sequence for the relation.

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).isForward'></a>

`isForward` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [is forward].

<a name='CypherQueryBuilder.Node.WithRelation_R_(CypherQueryBuilder.Node,R,int,bool,string[]).labels'></a>

`labels` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The labels.

#### Returns
[Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')  
<br/>

### Example
  
```csharp  
var r = 2010;  
            var actor = new Person { FullName = "Debjit", Age = 80 };  
            var mNode = Node<Movie>.Instance().Where(p => p.ReleaseYear > 500);  
            mNode.WithRelation(actor.AsNode(), new ActedIn() { ReleaseYear = 2009 });  
```

<a name='CypherQueryBuilder.Node_T_'></a>

## Node<T> Class

```csharp
public class Node<T> : CypherQueryBuilder.Node
```
#### Type parameters

<a name='CypherQueryBuilder.Node_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Entity](index.md#CypherQueryBuilder.Entity 'CypherQueryBuilder.Entity') &#129106; [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node') &#129106; Node<T>
### Methods

<a name='CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int)'></a>

## Node<T>.Instance(Node<T>, int) Method

Create a new Instance of [node](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).node 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int).node') type <span class="typeparameter">T</span> with alias suffixed with [sequence](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).sequence 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int).sequence')

```csharp
public static CypherQueryBuilder.Node<T> Instance(out CypherQueryBuilder.Node<T> node, int sequence=0);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).node'></a>

`node` [CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')

out parameter

<a name='CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).sequence'></a>

`sequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
New [node](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).node 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int).node') of type T

### Example
  
```csharp  
Node<Domain>.Instance(out var domainNode).Where(p => p.Uid == "TestDomain");  
            Node<Group>.Instance(out var groupNode).WithProperty(new { Uid = "gId_1", Name = "GName", Domain = "TestDomain" });  
            var q = Query.Match(domainNode)  
                .CreateRelation("hg", "HAS_DOMAIN", groupNode, domainNode, false, new { DomainId = "TestDomain", GroupId = "gId_1" });  
            var (cq, parameters) = q.CompileWithParemeters();  
            Console.WriteLine(cq);  
```

### Remarks
[sequence](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int).sequence 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int).sequence') will be default to zero if not provided

### See Also
- [Instance(int)](index.md#CypherQueryBuilder.Node_T_.Instance(int) 'CypherQueryBuilder.Node<T>.Instance(int)')
- [Instance(T, int)](index.md#CypherQueryBuilder.Node_T_.Instance(T,int) 'CypherQueryBuilder.Node<T>.Instance(T, int)')

<a name='CypherQueryBuilder.Node_T_.Instance(int)'></a>

## Node<T>.Instance(int) Method

Create a new Instance of node type [T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T') with alias suffixed with [sequence](index.md#CypherQueryBuilder.Node_T_.Instance(int).sequence 'CypherQueryBuilder.Node<T>.Instance(int).sequence')

```csharp
public static CypherQueryBuilder.Node<T> Instance(int sequence=0);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.Instance(int).sequence'></a>

`sequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
New node of type T

### Remarks
[sequence](index.md#CypherQueryBuilder.Node_T_.Instance(int).sequence 'CypherQueryBuilder.Node<T>.Instance(int).sequence') will be default to zero if not provided

### See Also
- [Instance(int)](index.md#CypherQueryBuilder.Node_T_.Instance(int) 'CypherQueryBuilder.Node<T>.Instance(int)')
- [Instance(Node&lt;T&gt;, int)](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int) 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int)')

<a name='CypherQueryBuilder.Node_T_.Instance(T,int)'></a>

## Node<T>.Instance(T, int) Method

Create a new Instance of node type [T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T') with alias suffixed with [sequence](index.md#CypherQueryBuilder.Node_T_.Instance(T,int).sequence 'CypherQueryBuilder.Node<T>.Instance(T, int).sequence')

```csharp
public static CypherQueryBuilder.Node<T> Instance(T obj, int sequence=0);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.Instance(T,int).obj'></a>

`obj` [T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')

The object.

<a name='CypherQueryBuilder.Node_T_.Instance(T,int).sequence'></a>

`sequence` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The sequence.

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
New node of type T

### Remarks
[sequence](index.md#CypherQueryBuilder.Node_T_.Instance(T,int).sequence 'CypherQueryBuilder.Node<T>.Instance(T, int).sequence') will be default to zero if not provided

### See Also
- [Instance(int)](index.md#CypherQueryBuilder.Node_T_.Instance(int) 'CypherQueryBuilder.Node<T>.Instance(int)')
- [Instance(Node&lt;T&gt;, int)](index.md#CypherQueryBuilder.Node_T_.Instance(CypherQueryBuilder.Node_T_,int) 'CypherQueryBuilder.Node<T>.Instance(CypherQueryBuilder.Node<T>, int)')

<a name='CypherQueryBuilder.Node_T_.Where(System.Linq.Expressions.Expression_System.Func_T,bool__)'></a>

## Node<T>.Where(Expression<Func<T,bool>>) Method

Applies filter or Where clause.

```csharp
public CypherQueryBuilder.Node<T> Where(System.Linq.Expressions.Expression<System.Func<T,bool>> expr);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.Where(System.Linq.Expressions.Expression_System.Func_T,bool__).expr'></a>

`expr` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The expr.

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
The same node of type T

<a name='CypherQueryBuilder.Node_T_.WithProperty(object)'></a>

## Node<T>.WithProperty(object) Method

Configure the property.

```csharp
public virtual CypherQueryBuilder.Node<T> WithProperty(object obj);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.WithProperty(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object.

Implements [WithProperty(object)](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.WithProperty#CypherQueryBuilder_IEntity_WithProperty_System_Object_ 'CypherQueryBuilder.IEntity.WithProperty(System.Object)')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
The same node of type T

### See Also
- [WithProperty(string, object)](index.md#CypherQueryBuilder.Node_T_.WithProperty(string,object) 'CypherQueryBuilder.Node<T>.WithProperty(string, object)')

<a name='CypherQueryBuilder.Node_T_.WithProperty(string,object)'></a>

## Node<T>.WithProperty(string, object) Method

Configure the property.

```csharp
public virtual CypherQueryBuilder.Node<T> WithProperty(string key, object? value);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.WithProperty(string,object).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key.

<a name='CypherQueryBuilder.Node_T_.WithProperty(string,object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The value.

Implements [WithProperty(string, object)](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.IEntity.WithProperty#CypherQueryBuilder_IEntity_WithProperty_System_String,System_Object_ 'CypherQueryBuilder.IEntity.WithProperty(System.String,System.Object)')

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')  
The same node of type T

### See Also
- [WithProperty(object)](index.md#CypherQueryBuilder.Node_T_.WithProperty(object) 'CypherQueryBuilder.Node<T>.WithProperty(object)')

<a name='CypherQueryBuilder.Node_T_.WithProperty(T)'></a>

## Node<T>.WithProperty(T) Method

Configure the property.

```csharp
public CypherQueryBuilder.Node<T> WithProperty(T obj);
```
#### Parameters

<a name='CypherQueryBuilder.Node_T_.WithProperty(T).obj'></a>

`obj` [T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')

The object.

#### Returns
[CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.Node_T_.T 'CypherQueryBuilder.Node<T>.T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')

<a name='CypherQueryBuilder.NodeCreationQuery'></a>

## NodeCreationQuery Class

```csharp
public class NodeCreationQuery : CypherQueryBuilder.QueryBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; NodeCreationQuery
### Methods

<a name='CypherQueryBuilder.NodeCreationQuery.Compile()'></a>

## NodeCreationQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

<a name='CypherQueryBuilder.NodeCreationQuery.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[])'></a>

## NodeCreationQuery.Merge(Node, Node[]) Method

Merges the specified node.

```csharp
public CypherQueryBuilder.NodeCreationQuery Merge(CypherQueryBuilder.Node node, params CypherQueryBuilder.Node[] otherNodes);
```
#### Parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).node'></a>

`node` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

The node.

<a name='CypherQueryBuilder.NodeCreationQuery.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The other nodes.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')

<a name='CypherQueryBuilder.NodeCreationQuery.ReleaseResources()'></a>

## NodeCreationQuery.ReleaseResources() Method

Releases the resources.

```csharp
public override void ReleaseResources();
```

<a name='CypherQueryBuilder.NodeCreationQuery.Return(string[])'></a>

## NodeCreationQuery.Return(string[]) Method

Returns the specified returns.

```csharp
public virtual CypherQueryBuilder.NodeCreationQuery Return(params string[] returns);
```
#### Parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Return(string[]).returns'></a>

`returns` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The returns.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## NodeCreationQuery.Return<T>(Node<T>, Expression<Func<T,object>>, bool) Method

Returns the specified node.

```csharp
public virtual CypherQueryBuilder.NodeCreationQuery Return<T>(CypherQueryBuilder.Node<T> node, System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).node'></a>

`node` [CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.NodeCreationQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')

The node.

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.NodeCreationQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## NodeCreationQuery.Return<T>(Expression<Func<T,object>>, bool) Method

Returns the specified f.

```csharp
public CypherQueryBuilder.NodeCreationQuery Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.NodeCreationQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.NodeCreationQuery.Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.NodeCreationQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')

<a name='CypherQueryBuilder.Query'></a>

## Query Class

`Query` - The main entry point to build cypher query for create, merge or match

```csharp
public static class Query
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Query
### Methods

<a name='CypherQueryBuilder.Query.Create(bool,CypherQueryBuilder.Node,CypherQueryBuilder.Node[])'></a>

## Query.Create(bool, Node, Node[]) Method

Creates the specified to merge.

```csharp
private static CypherQueryBuilder.NodeCreationQuery Create(bool toMerge, CypherQueryBuilder.Node node, params CypherQueryBuilder.Node[] otherNodes);
```
#### Parameters

<a name='CypherQueryBuilder.Query.Create(bool,CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).toMerge'></a>

`toMerge` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [to merge].

<a name='CypherQueryBuilder.Query.Create(bool,CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).node'></a>

`node` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

The node.

<a name='CypherQueryBuilder.Query.Create(bool,CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The other nodes.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')

<a name='CypherQueryBuilder.Query.Create(CypherQueryBuilder.Node,CypherQueryBuilder.Node[])'></a>

## Query.Create(Node, Node[]) Method

Creates the specified node.

```csharp
public static CypherQueryBuilder.NodeCreationQuery Create(CypherQueryBuilder.Node node, params CypherQueryBuilder.Node[] otherNodes);
```
#### Parameters

<a name='CypherQueryBuilder.Query.Create(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).node'></a>

`node` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

Node to Instance

<a name='CypherQueryBuilder.Query.Create(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Other nodes to match in case multiple nodes to be created.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')  
NodeCreationQuery

### Example
Example to build create query.  
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var q = Query.Instance(  
                Node<Movie>.Instance(movie)  
                    .WithRelation(Node<Person>.Instance(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))  
                .Return<Movie>(p => new { p.Title, p.ReleaseYear }).Return<Person>(p => new { p.FullName});  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.Query.Match(CypherQueryBuilder.Node,CypherQueryBuilder.Node[])'></a>

## Query.Match(Node, Node[]) Method

Matches the specified node.

```csharp
public static CypherQueryBuilder.MatchQuery Match(CypherQueryBuilder.Node node, params CypherQueryBuilder.Node[] otherNodes);
```
#### Parameters

<a name='CypherQueryBuilder.Query.Match(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).node'></a>

`node` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

Node to Match

<a name='CypherQueryBuilder.Query.Match(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Other nodes to match in case multiple nodes to be matched

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
`MatchQuery`

### Example
  
```csharp  
var q = Query.Match(n).Return("n", "r", "m");  
```

<a name='CypherQueryBuilder.Query.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[])'></a>

## Query.Merge(Node, Node[]) Method

Merges the specified node.

```csharp
public static CypherQueryBuilder.NodeCreationQuery Merge(CypherQueryBuilder.Node node, params CypherQueryBuilder.Node[] otherNodes);
```
#### Parameters

<a name='CypherQueryBuilder.Query.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).node'></a>

`node` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

The node.

<a name='CypherQueryBuilder.Query.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [Node](index.md#CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The other nodes in case multiple nodes to be merged.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')  
NodeCreationQuery

### Example
Example to build merge query.  
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var q = Query.Merge(  
                Node<Movie>.Instance(movie)  
                    .WithRelation(Node<Person>.Instance(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))  
                .Return<Movie>(p => new { p.Title, p.ReleaseYear }).Return<Person>(p => new { p.FullName});  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.QueryBase'></a>

## QueryBase Class

```csharp
public abstract class QueryBase : Utility.Disposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; QueryBase

Derived  
&#8627; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
&#8627; [NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')
### Methods

<a name='CypherQueryBuilder.QueryBase.AssignmentExp()'></a>

## QueryBase.AssignmentExp() Method

```csharp
private static System.Text.RegularExpressions.Regex AssignmentExp();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
(?<K>\\w+)\\s*\\=\\s*(?<V>\\w+(\\.\\w+)?)  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.IgnoreCase  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ "K" capture group.<br/>  
    ○ Match a word character atomically at least once.<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ Match '='.<br/>  
○ Match a whitespace character atomically any number of times.<br/>  
○ "V" capture group.<br/>  
    ○ Match a word character greedily at least once.<br/>  
    ○ Optional (greedy).<br/>  
        ○ 1st capture group.<br/>  
            ○ Match '.'.<br/>  
            ○ Match a word character atomically at least once.<br/>  
```

<a name='CypherQueryBuilder.QueryBase.Compile()'></a>

## QueryBase.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public abstract string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

<a name='CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## QueryBase.Return<T>(Node<T>, Expression<Func<T,object>>, bool) Method

Collect data to build return parts whilde compiling.

```csharp
public virtual CypherQueryBuilder.QueryBase Return<T>(CypherQueryBuilder.Node<T> node, System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).node'></a>

`node` [CypherQueryBuilder.Node&lt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')[T](index.md#CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.QueryBase.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](index.md#CypherQueryBuilder.Node_T_ 'CypherQueryBuilder.Node<T>')

The node.

<a name='CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.QueryBase.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase')

### See Also
- [CypherQueryBuilder.QueryBase.Return(System.String[])](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.QueryBase.Return#CypherQueryBuilder_QueryBase_Return_System_String[]_ 'CypherQueryBuilder.QueryBase.Return(System.String[])')
- [Return&lt;T&gt;(string, Expression&lt;Func&lt;T,object&gt;&gt;, bool)](index.md#CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool) 'CypherQueryBuilder.QueryBase.Return<T>(string, System.Linq.Expressions.Expression<System.Func<T,object>>, bool)')

<a name='CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## QueryBase.Return<T>(string, Expression<Func<T,object>>, bool) Method

Collect data to build return parts whilde compiling.

```csharp
public virtual CypherQueryBuilder.QueryBase Return<T>(string? alias, System.Linq.Expressions.Expression<System.Func<T,object>> f, bool aliasToBeRemoved=true);
```
#### Type parameters

<a name='CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'CypherQueryBuilder.QueryBase.Return<T>(string, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

<a name='CypherQueryBuilder.QueryBase.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__,bool).aliasToBeRemoved'></a>

`aliasToBeRemoved` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [alias to be removed].

#### Returns
[QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase')

### See Also
- [CypherQueryBuilder.QueryBase.Return(System.String[])](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.QueryBase.Return#CypherQueryBuilder_QueryBase_Return_System_String[]_ 'CypherQueryBuilder.QueryBase.Return(System.String[])')
- [Return&lt;T&gt;(Node&lt;T&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, bool)](index.md#CypherQueryBuilder.QueryBase.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool) 'CypherQueryBuilder.QueryBase.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool)')

<a name='CypherQueryBuilder.Relation_T_'></a>

## Relation<T> Class

```csharp
public class Relation<T> : CypherQueryBuilder.Relation
```
#### Type parameters

<a name='CypherQueryBuilder.Relation_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Entity](index.md#CypherQueryBuilder.Entity 'CypherQueryBuilder.Entity') &#129106; [CypherQueryBuilder.Relation](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Relation 'CypherQueryBuilder.Relation') &#129106; Relation<T>
### Methods

<a name='CypherQueryBuilder.Relation_T_.Where(System.Linq.Expressions.Expression_System.Func_T,bool__)'></a>

## Relation<T>.Where(Expression<Func<T,bool>>) Method

Applies filter or Where clause.

```csharp
public CypherQueryBuilder.Relation<T> Where(System.Linq.Expressions.Expression<System.Func<T,bool>> expr);
```
#### Parameters

<a name='CypherQueryBuilder.Relation_T_.Where(System.Linq.Expressions.Expression_System.Func_T,bool__).expr'></a>

`expr` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.Relation_T_.T 'CypherQueryBuilder.Relation<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The expr.

#### Returns
[CypherQueryBuilder.Relation&lt;](index.md#CypherQueryBuilder.Relation_T_ 'CypherQueryBuilder.Relation<T>')[T](index.md#CypherQueryBuilder.Relation_T_.T 'CypherQueryBuilder.Relation<T>.T')[&gt;](index.md#CypherQueryBuilder.Relation_T_ 'CypherQueryBuilder.Relation<T>')  
The same Relation of type T

<a name='CypherQueryBuilder.UnionQuery'></a>

## UnionQuery Class

```csharp
public class UnionQuery : CypherQueryBuilder.MatchQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery') &#129106; UnionQuery
### Methods

<a name='CypherQueryBuilder.UnionQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_)'></a>

## UnionQuery.CompileWithParemeters(Dictionary<string,object>) Method

Compiles the instance to Cypher Query string with paremeters.

```csharp
public override (string query,System.Collections.Generic.Dictionary<string,object?> parameters) CompileWithParemeters(System.Collections.Generic.Dictionary<string,object?>? startParameters=null);
```
#### Parameters

<a name='CypherQueryBuilder.UnionQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_).startParameters'></a>

`startParameters` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
ValueTuple<string, Dictionary<string, Nullable<Object>>>

### Example
  
Usage:  
  
```csharp  
var metaDataCount = 2;  
            var metaDataNodes = new Node<MetaData>[metaDataCount];  
            for (int i = 0; i < metaDataCount; i++)  
            {  
                var id = $"mId_{i}";  
                metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);  
            }  
            var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");  
            var (mq, parameters) = Query.Match(domainNode, metaDataNodes).CompileAsParemeterized();  
```

### See Also
- [CypherQueryBuilder.UnionQuery.Compile](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.UnionQuery.Compile 'CypherQueryBuilder.UnionQuery.Compile')

<a name='CypherQueryBuilder.UpdateQuery'></a>

## UpdateQuery Class

```csharp
public class UpdateQuery : CypherQueryBuilder.MatchQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery') &#129106; UpdateQuery
### Methods

<a name='CypherQueryBuilder.UpdateQuery.Compile()'></a>

## UpdateQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

### See Also
- [CompileWithParemeters(Dictionary&lt;string,object&gt;)](index.md#CypherQueryBuilder.UpdateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_) 'CypherQueryBuilder.UpdateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary<string,object>)')

<a name='CypherQueryBuilder.UpdateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_)'></a>

## UpdateQuery.CompileWithParemeters(Dictionary<string,object>) Method

Compiles the instance to Cypher Query string with paremeters.

```csharp
public override (string query,System.Collections.Generic.Dictionary<string,object?> parameters) CompileWithParemeters(System.Collections.Generic.Dictionary<string,object?>? startParameters=null);
```
#### Parameters

<a name='CypherQueryBuilder.UpdateQuery.CompileWithParemeters(System.Collections.Generic.Dictionary_string,object_).startParameters'></a>

`startParameters` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
ValueTuple<string, Dictionary<string, Nullable<Object>>>

### Example
  
Usage:  
  
```csharp  
var metaDataCount = 2;  
            var metaDataNodes = new Node<MetaData>[metaDataCount];  
            for (int i = 0; i < metaDataCount; i++)  
            {  
                var id = $"mId_{i}";  
                metaDataNodes[i] = Node<MetaData>.Instance(i).Where(p => p.Uid == id);  
            }  
            var domainNode = Node<Domain>.Instance().Where(p => p.Uid == "TestDomain");  
            var (mq, parameters) = Query.Match(domainNode, metaDataNodes).CompileAsParemeterized();  
```

### See Also
- [Compile()](index.md#CypherQueryBuilder.UpdateQuery.Compile() 'CypherQueryBuilder.UpdateQuery.Compile()')