using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Tables;

public sealed record ProductsTableTests
{
    [Fact]
    public void NameIsProducts()
    {
        ITable table = new ProductsTable();

        Assert.Equal("products", table.Name.TextValue);
    }

    [Fact]
    public void ColumnsCountIs5()
    {
        ITable table = new ProductsTable();

        Assert.Equal(5, table.Columns.Count());
    }

    [Fact]
    public void IndexesCountIs1()
    {
        ITable table = new ProductsTable();

        _ = Assert.Single(table.Indexes);
    }

    [Fact]
    public void ColumnsContainsProductIdColumn()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductIdColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsProductNameColumn()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductNameColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsProductDescriptionColumn()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ProductDescriptionColumn())
                )
        );
    }

    [Fact]
    public void ColumnsContainsProductPriceColumn()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Columns,
            c => new ColumnHash(c).SequenceEqual(new ColumnHash(new ProductPriceColumn()))
        );
    }

    [Fact]
    public void ColumnsContainsProductInStockColumn()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Columns,
            c =>
                new ColumnHash(c).SequenceEqual(
                    new ColumnHash(new ProductInStockColumn())
                )
        );
    }

    [Fact]
    public void IndexesContainsProductsPrimaryIndex()
    {
        ITable table = new ProductsTable();

        Assert.Contains(
            table.Indexes,
            i => new IndexHash(i).SequenceEqual(new IndexHash(new ProductsPrimaryIndex()))
        );
    }
}
