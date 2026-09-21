using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ForeignKeys;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record CrossDomainForeignKeyJoinKeysAreCompatibleTests
{
    private static readonly IEnumerable<IForeignKey> ForeignKeys =
    [
        new EmptyColumnsForeignKey(),
        new SingleColumnForeignKey(),
        new CompositeForeignKey(),
        new OrderItemsToProductsForeignKey(),
        new SelfReferencingForeignKey(),
        new LoginsToUsersForeignKey(),
        new OrdersToStatusesForeignKey(),
        new EmployeesToUsersForeignKey(),
    ];

    [Fact]
    public void ReferencingAndReferencedColumnCountsMatch()
    {
        Assert.All(
            ForeignKeys,
            f => Assert.Equal(f.ReferencingColumns.Count(), f.ReferencedColumns.Count())
        );
    }

    [Fact]
    public void JoinKeyTypesMatchPositionally()
    {
        Assert.All(
            ForeignKeys,
            f =>
                Assert.All(
                    f.ReferencingColumns.Zip(f.ReferencedColumns, (r, d) => (r, d)),
                    pair =>
                        Assert.True(
                            new ColumnTypeHash(pair.r.Type).SequenceEqual(
                                new ColumnTypeHash(pair.d.Type)
                            )
                        )
                )
        );
    }
}
