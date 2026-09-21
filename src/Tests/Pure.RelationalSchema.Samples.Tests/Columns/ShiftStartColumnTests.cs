using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record ShiftStartColumnTests
{
    [Fact]
    public void NameIsShiftStart()
    {
        IColumn column = new ShiftStartColumn();

        Assert.Equal("shift_start", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsTimeColumnType()
    {
        IColumn column = new ShiftStartColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new TimeColumnType())
            )
        );
    }
}
