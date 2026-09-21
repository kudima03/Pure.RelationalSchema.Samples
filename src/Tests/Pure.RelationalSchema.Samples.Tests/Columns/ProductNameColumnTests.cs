using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ProductNameColumnTests
{
    [Fact]
    public void NameIsProductName()
    {
        IColumn column = new ProductNameColumn();

        Assert.Equal("product_name", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsStringColumnType()
    {
        IColumn column = new ProductNameColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new StringColumnType())
            )
        );
    }
}
