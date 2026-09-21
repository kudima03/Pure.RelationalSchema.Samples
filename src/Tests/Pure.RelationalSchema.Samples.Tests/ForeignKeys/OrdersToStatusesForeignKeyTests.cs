using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record OrdersToStatusesForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsOrdersTable()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new OrdersTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsStatusesTable()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new StatusesTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs1()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        _ = Assert.Single(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsCountIs1()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        _ = Assert.Single(foreignKey.ReferencedColumns);
    }

    [Fact]
    public void ReferencingColumnsContainsOrderStatusColumn()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderStatusColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsStatusCodeColumn()
    {
        IForeignKey foreignKey = new OrdersToStatusesForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new StatusCodeColumn()))
        );
    }
}
