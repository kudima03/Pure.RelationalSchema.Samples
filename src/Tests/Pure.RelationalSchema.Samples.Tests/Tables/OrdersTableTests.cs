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
    public void ColumnsCountIs5()
    {
        ITable table = new OrdersTable();

        Assert.Equal(5, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs2()
    {
        ITable table = new OrdersTable();

        Assert.Equal(2, table.Indexes.Count());
    }

    [Fact]
    public void ColumnsContainsIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new IdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsTenantIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new TenantIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsUserIdColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new UserIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsPriceColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new PriceColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsCreatedAtColumn()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new CreatedAtColumn()))
        );
    }

    [Fact]
    public void IndexesContainsSingleColumnUniqueIndex()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Indexes,
            i =>
                new IndexHash(i).SequenceEqual(
                    new IndexHash(new SingleColumnUniqueIndex())
                )
        );
    }

    [Fact]
    public void IndexesContainsCompositeUniqueIndex()
    {
        ITable table = new OrdersTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new CompositeUniqueIndex()))
        );
    }
}
