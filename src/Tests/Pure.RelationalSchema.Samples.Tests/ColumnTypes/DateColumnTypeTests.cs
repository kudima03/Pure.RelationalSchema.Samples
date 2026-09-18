using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record DateColumnTypeTests
{
    [Fact]
    public void NameIsDate()
    {
        IColumnType columnType = new DateColumnType();

        Assert.Equal("date", columnType.Name.TextValue);
    }
}
