using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record OrdersTableTests
{
    [Fact]
    public void NameIsOrders()
    {
        ITable table = new OrdersTable();

        Assert.Equal("orders", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs7()
    {
        ITable table = new OrdersTable();

        Assert.Equal(7, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs2()
    {
        ITable table = new OrdersTable();

        Assert.Equal(2, table.Indexes.Count());
    }

    [Fact]
    public void ColumnsContainsOrderIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderTenantIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderTenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderUserIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderUserIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderTotalColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderTotalColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsPlacedAtColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new PlacedAtColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsOrderStatusColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new OrderStatusColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsPlacedOnColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new PlacedOnColumn()))
        );
    }

    [Fact]
    public void IndexesContainsOrdersPrimaryIndex()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new OrdersPrimaryIndex()))
        );
    }

    [Fact]
    public void IndexesContainsOrdersTenantUniqueIndex()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new OrdersTenantUniqueIndex())
                )
        );
    }
}
