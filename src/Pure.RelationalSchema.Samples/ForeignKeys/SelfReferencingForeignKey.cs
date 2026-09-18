using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record SelfReferencingForeignKey : IForeignKey
{
    public ITable ReferencingTable => new EmployeesTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ManagerIdColumn()];

    public ITable ReferencedTable => new EmployeesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new IdColumn()];
}
