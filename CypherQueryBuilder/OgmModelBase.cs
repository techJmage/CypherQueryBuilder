using Neo4j.Driver.Mapping;

namespace CypherQueryBuilder;

public class OgmModelBase
{
    [CypherProperty]
    public string Uid { get; set; }
}
public class OgmNodeBase<T> : OgmModelBase where T : class
{
    [MappingIgnored]
    public Node<T> Node { get; set; }
    public Node<T> AsNode(int sequence = 0) => Node<T>.Instance(this as T, sequence);
    public MatchQuery ToMatchQuery() => Node.ToMatchQuery();
}
