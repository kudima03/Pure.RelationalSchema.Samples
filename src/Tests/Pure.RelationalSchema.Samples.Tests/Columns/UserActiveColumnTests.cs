using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record UserActiveColumnTests
{
    [Fact]
    public void NameIsUserActive()
    {
        IColumn column = new UserActiveColumn();

        Assert.Equal("user_active", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsBoolColumnType()
    {
        IColumn column = new UserActiveColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new BoolColumnType())
            )
        );
    }
}
