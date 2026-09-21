using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ProductInStockColumnTests
{
    [Fact]
    public void NameIsProductInStock()
    {
        IColumn column = new ProductInStockColumn();

        Assert.Equal("product_in_stock", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsBoolColumnType()
    {
        IColumn column = new ProductInStockColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new BoolColumnType())
            )
        );
    }
}
