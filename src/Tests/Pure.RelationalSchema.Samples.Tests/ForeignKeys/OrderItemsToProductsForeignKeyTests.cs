using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.ForeignKeys;

public sealed record OrderItemsToProductsForeignKeyTests
{
    [Fact]
    public void ReferencingTableIsOrderItemsTable()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencingTable).SequenceEqual(
                new TableHash(new OrderItemsTable())
            )
        );
    }

    [Fact]
    public void ReferencedTableIsProductsTable()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        Assert.True(
            new TableHash(foreignKey.ReferencedTable).SequenceEqual(
                new TableHash(new ProductsTable())
            )
        );
    }

    [Fact]
    public void ReferencingColumnsCountIs1()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        _ = Assert.Single(foreignKey.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsCountIs1()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        _ = Assert.Single(foreignKey.ReferencedColumns);
    }

    [Fact]
    public void ReferencingColumnsContainsItemProductIdColumn()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        Assert.Contains(
            foreignKey.ReferencingColumns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemProductIdColumn()))
        );
    }

    [Fact]
    public void ReferencedColumnsContainsProductIdColumn()
    {
        IForeignKey foreignKey = new OrderItemsToProductsForeignKey();

        Assert.Contains(
            foreignKey.ReferencedColumns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductIdColumn()))
        );
    }
}
