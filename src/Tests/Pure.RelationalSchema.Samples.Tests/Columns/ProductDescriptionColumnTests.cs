using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ProductDescriptionColumnTests
{
    [Fact]
    public void NameIsProductDescription()
    {
        IColumn column = new ProductDescriptionColumn();

        Assert.Equal("product_description", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsStringColumnType()
    {
        IColumn column = new ProductDescriptionColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new StringColumnType())
            )
        );
    }
}
