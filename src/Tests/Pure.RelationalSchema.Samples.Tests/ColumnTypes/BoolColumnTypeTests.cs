using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record BoolColumnTypeTests
{
    [Fact]
    public void NameIsBool()
    {
        IColumnType columnType = new BoolColumnType();

        Assert.Equal("bool", columnType.Name.TextValue);
    }
}
