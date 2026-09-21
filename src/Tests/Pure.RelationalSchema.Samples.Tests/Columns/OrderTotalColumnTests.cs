using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record OrderTotalColumnTests
{
    [Fact]
    public void NameIsOrderTotal()
    {
        IColumn column = new OrderTotalColumn();

        Assert.Equal("order_total", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDoubleColumnType()
    {
        IColumn column = new OrderTotalColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DoubleColumnType())
            )
        );
    }
}
