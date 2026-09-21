using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record EmployeesTable : ITable
{
    public IString Name => new String("employees");

    public IEnumerable<IColumn> Columns =>
        [
            new EmployeeIdColumn(),
            new EmployeeNameColumn(),
            new EmployeeManagerIdColumn(),
            new EmployeeShiftStartColumn(),
            new EmployeeUserIdColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [new EmployeesPrimaryIndex()];
}
