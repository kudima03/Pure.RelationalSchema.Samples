using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record OrderItemsTableTests
{
    [Fact]
    public void NameIsOrderItems()
    {
        ITable table = new OrderItemsTable();

        Assert.Equal("order_items", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs5()
    {
        ITable table = new OrderItemsTable();

        Assert.Equal(5, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new OrderItemsTable();

        _ = Assert.Single(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsItemIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsItemTenantIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemTenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsItemOrderIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemOrderIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsItemProductIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemProductIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsItemQtyColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ItemQtyColumn()))
        );
    }

    [Fact]
    public void IndexesContainsOrderItemsPrimaryIndex()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new OrderItemsPrimaryIndex())
                )
        );
    }
}
