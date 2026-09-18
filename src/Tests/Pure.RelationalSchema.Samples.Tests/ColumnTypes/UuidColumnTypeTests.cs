using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record UuidColumnTypeTests
{
    [Fact]
    public void NameIsUuid()
    {
        IColumnType columnType = new UuidColumnType();

        Assert.Equal("uuid", columnType.Name.TextValue);
    }
}
