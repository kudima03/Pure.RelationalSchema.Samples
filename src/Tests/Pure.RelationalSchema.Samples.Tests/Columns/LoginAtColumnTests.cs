using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record LoginAtColumnTests
{
    [Fact]
    public void NameIsLoginAt()
    {
        IColumn column = new LoginAtColumn();

        Assert.Equal("login_at", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsDateTimeColumnType()
    {
        IColumn column = new LoginAtColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new DateTimeColumnType())
            )
        );
    }
}
