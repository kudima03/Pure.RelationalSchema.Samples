using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record TimeColumnTypeTests
{
    [Fact]
    public void NameIsTime()
    {
        IColumnType columnType = new TimeColumnType();

        Assert.Equal("time", columnType.Name.TextValue);
    }
}
