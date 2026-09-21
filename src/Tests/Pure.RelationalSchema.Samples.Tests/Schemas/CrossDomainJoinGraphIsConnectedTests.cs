using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record CrossDomainJoinGraphIsConnectedTests
{
    private static readonly IEnumerable<ITable> DomainRelations =
    [
        new UsersTable(),
        new OrdersTable(),
        new ProductsTable(),
        new OrderItemsTable(),
        new EmployeesTable(),
        new LoginsTable(),
        new StatusesTable(),
    ];

    private static readonly IEnumerable<IForeignKey> ForeignKeys =
    [
        new SingleColumnForeignKey(),
        new CompositeForeignKey(),
        new OrderItemsToProductsForeignKey(),
        new SelfReferencingForeignKey(),
        new LoginsToUsersForeignKey(),
        new OrdersToStatusesForeignKey(),
        new EmployeesToUsersForeignKey(),
    ];

    [Fact]
    public void EveryDomainRelationIsReachableFromUsers()
    {
        IEnumerable<string> nodes = DomainRelations.Select(t => t.Name.TextValue);
        Dictionary<string, List<string>> adjacency = nodes.ToDictionary(
            n => n,
            _ => new List<string>()
        );

        foreach (IForeignKey foreignKey in ForeignKeys)
        {
            string referencing = foreignKey.ReferencingTable.Name.TextValue;
            string referenced = foreignKey.ReferencedTable.Name.TextValue;

            if (
                adjacency.TryGetValue(referencing, out List<string>? referencingNeighbors)
                && adjacency.TryGetValue(
                    referenced,
                    out List<string>? referencedNeighbors
                )
            )
            {
                referencingNeighbors.Add(referenced);
                referencedNeighbors.Add(referencing);
            }
        }

        HashSet<string> visited = [];
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("users");
        _ = visited.Add("users");

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();

            foreach (string neighbor in adjacency[current])
            {
                if (visited.Add(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        Assert.Equal(adjacency.Count, visited.Count);
    }
}
