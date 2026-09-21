using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record OrdersToStatusesForeignKey : IForeignKey
{
    public ITable ReferencingTable => new OrdersTable();

    public IEnumerable<IColumn> ReferencingColumns => [new OrderStatusColumn()];

    public ITable ReferencedTable => new StatusesTable();

    public IEnumerable<IColumn> ReferencedColumns => [new StatusCodeColumn()];
}
