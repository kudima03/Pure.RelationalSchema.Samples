using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ItemProductIdColumnTests
{
    [Fact]
    public void NameIsItemProductId()
    {
        IColumn column = new ItemProductIdColumn();

        Assert.Equal("item_product_id", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsUuidColumnType()
    {
        IColumn column = new ItemProductIdColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new UuidColumnType())
            )
        );
    }
}
