using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record CompositeForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsOrderItemsTable()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new OrderItemsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsOrdersTable()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new OrdersTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs2()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Equal(2, foreignKey.ReferencingColumns.Count());
    }

    [Fact]
    public void ReferencedColumnsCountIs2()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Equal(2, foreignKey.ReferencedColumns.Count());
    }

    [Fact]
    public void ReferencingColumnsContainsItemOrderIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemOrderIdColumn()))
        );
    }

    [Fact]
    public void ReferencingColumnsContainsItemTenantIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemTenantIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsOrderIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsOrderTenantIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderTenantIdColumn()))
        );
    }
}
