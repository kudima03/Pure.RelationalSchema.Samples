using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record SingleColumnForeignKey : IForeignKey
{
    public ITable ReferencingTable => new OrdersTable();

    public IEnumerable<IColumn> ReferencingColumns => [new UserIdColumn()];

    public ITable ReferencedTable => new UsersTable();

    public IEnumerable<IColumn> ReferencedColumns => [new IdColumn()];
}
