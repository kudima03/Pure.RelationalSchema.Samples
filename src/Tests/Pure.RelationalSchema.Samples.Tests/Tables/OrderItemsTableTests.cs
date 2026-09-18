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
    public void ColumnsContainsIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsTenantIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsProductIdColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsQuantityColumn()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new QuantityColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new OrderItemsTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnUniqueIndex())
                )
        );
    }
}
