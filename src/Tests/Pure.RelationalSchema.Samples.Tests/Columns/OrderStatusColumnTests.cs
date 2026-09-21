using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record OrderStatusColumnTests
{
    [Fact]
    public void NameIsOrderStatus()
    {
        IColumn column = new OrderStatusColumn();

        Assert.Equal("order_status", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsStringColumnType()
    {
        IColumn column = new OrderStatusColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new StringColumnType())
            )
        );
    }
}
