using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ItemQtyColumnTests
{
    [Fact]
    public void NameIsItemQty()
    {
        IColumn column = new ItemQtyColumn();

        Assert.Equal("item_qty", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDoubleColumnType()
    {
        IColumn column = new ItemQtyColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DoubleColumnType())
            )
        );
    }
}
