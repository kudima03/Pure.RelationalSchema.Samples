using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record DoubleColumnTypeTests
{
    [Fact]
    public void NameIsDouble()
    {
        IColumnType columnType = new DoubleColumnType();

        Assert.Equal("double", columnType.Name.TextValue);
    }
}
