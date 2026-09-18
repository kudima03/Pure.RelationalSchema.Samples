using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record CompositeForeignKey : IForeignKey
{
    public ITable ReferencingTable => new OrderItemsTable();

    public IEnumerable<IColumn> ReferencingColumns =>
        [new OrderIdColumn(), new TenantIdColumn()];

    public ITable ReferencedTable => new OrdersTable();

    public IEnumerable<IColumn> ReferencedColumns =>
        [new IdColumn(), new TenantIdColumn()];
}
