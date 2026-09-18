using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record QuantityColumnTests
{
    [Fact]
    public void NameIsQuantity()
    {
        IColumn column = new QuantityColumn();

        Assert.Equal("quantity", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsLongColumnType()
    {
        IColumn column = new QuantityColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new LongColumnType())
            )
        );
    }
}
