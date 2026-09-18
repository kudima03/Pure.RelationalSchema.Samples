using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record DateTimeColumnTypeTests
{
    [Fact]
    public void NameIsDatetime()
    {
        IColumnType columnType = new DateTimeColumnType();

        Assert.Equal("datetime", columnType.Name.TextValue);
    }
}
