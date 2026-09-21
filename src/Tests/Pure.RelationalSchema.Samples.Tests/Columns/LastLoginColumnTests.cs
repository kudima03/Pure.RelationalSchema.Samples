using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record LastLoginColumnTests
{
    [Fact]
    public void NameIsLastLogin()
    {
        IColumn column = new LastLoginColumn();

        Assert.Equal("last_login", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateTimeColumnType()
    {
        IColumn column = new LastLoginColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateTimeColumnType())
            )
        );
    }
}
