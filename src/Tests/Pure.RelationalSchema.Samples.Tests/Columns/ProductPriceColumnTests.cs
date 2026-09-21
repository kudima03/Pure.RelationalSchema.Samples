using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ProductPriceColumnTests
{
    [Fact]
    public void NameIsProductPrice()
    {
        IColumn column = new ProductPriceColumn();

        Assert.Equal("product_price", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDoubleColumnType()
    {
        IColumn column = new ProductPriceColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DoubleColumnType())
            )
        );
    }
}
