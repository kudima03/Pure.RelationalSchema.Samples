using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Tests.Columns;

public sealed record EmployeeShiftStartColumnTests
{
    [Fact]
    public void NameIsEmployeeShiftStart()
    {
        IColumn column = new EmployeeShiftStartColumn();

        Assert.Equal("employee_shift_start", column.Name.TextValue);
    }

    [Fact]
    public void TypeIsTimeColumnType()
    {
        IColumn column = new EmployeeShiftStartColumn();

        Assert.True(
            new ColumnTypeHash(column.Type).SequenceEqual(
                new ColumnTypeHash(new TimeColumnType())
            )
        );
    }
}
