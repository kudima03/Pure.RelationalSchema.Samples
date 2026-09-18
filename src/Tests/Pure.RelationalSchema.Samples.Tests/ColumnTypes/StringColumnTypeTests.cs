using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record StringColumnTypeTests
{
    [Fact]
    public void NameIsString()
    {
        IColumnType columnType = new StringColumnType();

        Assert.Equal("string", columnType.Name.TextValue);
    }
}
