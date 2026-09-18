using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record LongColumnTypeTests
{
    [Fact]
    public void NameIsLong()
    {
        IColumnType columnType = new LongColumnType();

        Assert.Equal("long", columnType.Name.TextValue);
    }
}
