using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record IsActiveColumnTests
{
    [Fact]
    public void NameIsIsActive()
    {
        IColumn column = new IsActiveColumn();

        Assert.Equal("is_active", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsBoolColumnType()
    {
        IColumn column = new IsActiveColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new BoolColumnType())
            )
        );
    }
}
