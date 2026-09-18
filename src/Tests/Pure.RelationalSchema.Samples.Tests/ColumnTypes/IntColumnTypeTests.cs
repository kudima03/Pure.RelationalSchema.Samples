using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record IntColumnTypeTests
{
    [Fact]
    public void NameIsInt()
    {
        IColumnType columnType = new IntColumnType();

        Assert.Equal("int", columnType.Name.TextValue);
    }
}
