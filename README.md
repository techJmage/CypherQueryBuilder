#### [CypherQueryBuilder](index.md 'index')

## CypherQueryBuilder Assembly
### Namespaces

<a name='CypherQueryBuilder'></a>

## CypherQueryBuilder Namespace
### Classes

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

<a name='CypherQueryBuilder.MatchCreationQuery'></a>

## MatchCreationQuery Class

```csharp
public class MatchCreationQuery : CypherQueryBuilder.MatchQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery') &#129106; MatchCreationQuery
### Methods

<a name='CypherQueryBuilder.MatchCreationQuery.Compile()'></a>

## MatchCreationQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

<a name='CypherQueryBuilder.MatchQuery'></a>

## MatchQuery Class

```csharp
public class MatchQuery : CypherQueryBuilder.QueryBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; [QueryBase](index.md#CypherQueryBuilder.QueryBase 'CypherQueryBuilder.QueryBase') &#129106; MatchQuery

Derived  
&#8627; [DeleteQuery](index.md#CypherQueryBuilder.DeleteQuery 'CypherQueryBuilder.DeleteQuery')  
&#8627; [MatchCreationQuery](index.md#CypherQueryBuilder.MatchCreationQuery 'CypherQueryBuilder.MatchCreationQuery')
### Methods

<a name='CypherQueryBuilder.MatchQuery.Compile()'></a>

## MatchQuery.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public override string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object)'></a>

## MatchQuery.CreateRelation(string, string, Node, Node, bool, object) Method

Creates the relation.

```csharp
public virtual CypherQueryBuilder.MatchCreationQuery CreateRelation(string alias, string label, CypherQueryBuilder.Node from, CypherQueryBuilder.Node to, bool toMerge=false, object? properties=null);
```
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).label'></a>

`label` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The label.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).from'></a>

`from` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

From.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).to'></a>

`to` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

To.

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).toMerge'></a>

`toMerge` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

if set to `true` [to merge].

<a name='CypherQueryBuilder.MatchQuery.CreateRelation(string,string,CypherQueryBuilder.Node,CypherQueryBuilder.Node,bool,object).properties'></a>

`properties` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The properties.

#### Returns
[MatchCreationQuery](index.md#CypherQueryBuilder.MatchCreationQuery 'CypherQueryBuilder.MatchCreationQuery')

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

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## MatchQuery.Return<T>(Node<T>, Expression<Func<T,object>>) Method

Returns the specified node.

```csharp
public virtual CypherQueryBuilder.MatchQuery Return<T>(CypherQueryBuilder.Node<T> node, System.Linq.Expressions.Expression<System.Func<T,object>> f);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__).node'></a>

`node` [CypherQueryBuilder.Node&lt;](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node-1 'CypherQueryBuilder.Node`1')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__).T 'CypherQueryBuilder.MatchQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node-1 'CypherQueryBuilder.Node`1')

The node.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(CypherQueryBuilder.Node_T_,System.Linq.Expressions.Expression_System.Func_T,object__).T 'CypherQueryBuilder.MatchQuery.Return<T>(CypherQueryBuilder.Node<T>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## MatchQuery.Return<T>(string, Expression<Func<T,object>>) Method

Returns the specified alias.

```csharp
public virtual CypherQueryBuilder.MatchQuery Return<T>(string? alias, System.Linq.Expressions.Expression<System.Func<T,object>> f);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The alias.

<a name='CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(string,System.Linq.Expressions.Expression_System.Func_T,object__).T 'CypherQueryBuilder.MatchQuery.Return<T>(string, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

#### Returns
[MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## MatchQuery.Return<T>(Expression<Func<T,object>>) Method

Returns the specified f.

```csharp
public CypherQueryBuilder.MatchQuery Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>>? f=null);
```
#### Type parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__).T'></a>

`T`
#### Parameters

<a name='CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__).f'></a>

`f` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](index.md#CypherQueryBuilder.MatchQuery.Return_T_(System.Linq.Expressions.Expression_System.Func_T,object__).T 'CypherQueryBuilder.MatchQuery.Return<T>(System.Linq.Expressions.Expression<System.Func<T,object>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

The f.

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
[CypherQueryBuilder.UnionQuery](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.UnionQuery 'CypherQueryBuilder.UnionQuery')

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
public string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string

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

`node` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

The node.

<a name='CypherQueryBuilder.Query.Create(bool,CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

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

`node` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

Node to Create

<a name='CypherQueryBuilder.Query.Create(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Other nodes to match in case multiple nodes to be created.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')  
NodeCreationQuery

### Example
Example to build create query.  
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var q = Query.Create(  
                Node<Movie>.Create(movie)  
                    .WithRelation(Node<Person>.Create(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))  
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

`node` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

Node to Match

<a name='CypherQueryBuilder.Query.Match(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

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

`node` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')

The node.

<a name='CypherQueryBuilder.Query.Merge(CypherQueryBuilder.Node,CypherQueryBuilder.Node[]).otherNodes'></a>

`otherNodes` [CypherQueryBuilder.Node](https://docs.microsoft.com/en-us/dotnet/api/CypherQueryBuilder.Node 'CypherQueryBuilder.Node')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The other nodes in case multiple nodes to be merged.

#### Returns
[NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')  
NodeCreationQuery

### Example
Example to build merge query.  
  
```csharp  
var movie = new Movie() { ReleaseYear = 2010, Title = "Gambler" };  
            var q = Query.Merge(  
                Node<Movie>.Create(movie)  
                    .WithRelation(Node<Person>.Create(new Person {Age = 30, FullName = "Ray" }), "DIRECTED_BY"))  
                .Return<Movie>(p => new { p.Title, p.ReleaseYear }).Return<Person>(p => new { p.FullName});  
            var str = q.Compile();  
```

<a name='CypherQueryBuilder.QueryBase'></a>

## QueryBase Class

```csharp
public class QueryBase : Utility.Disposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Utility.Disposable](https://docs.microsoft.com/en-us/dotnet/api/Utility.Disposable 'Utility.Disposable') &#129106; QueryBase

Derived  
&#8627; [MatchQuery](index.md#CypherQueryBuilder.MatchQuery 'CypherQueryBuilder.MatchQuery')  
&#8627; [NodeCreationQuery](index.md#CypherQueryBuilder.NodeCreationQuery 'CypherQueryBuilder.NodeCreationQuery')
### Methods

<a name='CypherQueryBuilder.QueryBase.Compile()'></a>

## QueryBase.Compile() Method

Compiles this instance to Cypher Query string.

```csharp
public virtual string Compile();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Cypher Query string