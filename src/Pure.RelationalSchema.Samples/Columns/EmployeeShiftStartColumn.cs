using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Columns;

public sealed record EmployeeShiftStartColumn : IColumn
{
    public IString Name => new String("employee_shift_start");

    public IColumnType Type => new TimeColumnType();
}
