using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record StatusIsFinalColumnTests
{
    [Fact]
    public void NameIsStatusIsFinal()
    {
        IColumn column = new StatusIsFinalColumn();

        Assert.Equal("status_is_final", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsBoolColumnType()
    {
        IColumn column = new StatusIsFinalColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new BoolColumnType())
            )
        );
    }
}
