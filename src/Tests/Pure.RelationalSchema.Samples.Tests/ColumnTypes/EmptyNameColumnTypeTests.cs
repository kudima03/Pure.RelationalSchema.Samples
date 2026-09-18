using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.ColumnTypes;

public sealed record EmptyNameColumnTypeTests
{
    [Fact]
    public void NameIsEmpty()
    {
        IColumnType columnType = new EmptyNameColumnType();

        Assert.Equal(string.Empty, columnType.Name.TextValue);
    }
}
