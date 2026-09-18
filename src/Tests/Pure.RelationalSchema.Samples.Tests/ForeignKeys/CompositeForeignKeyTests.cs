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
    public void ReferencingColumnsContainsOrderIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }

    [Fact]
    public void ReferencingColumnsContainsTenantIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsTenantIdColumn()
    {
        IForeignKey foreignKey = new CompositeForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }
}
