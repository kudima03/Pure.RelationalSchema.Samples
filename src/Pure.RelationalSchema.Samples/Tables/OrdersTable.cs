using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record OrdersTable : ITable
{
    public IString Name => new String("orders");

    public IEnumerable<IColumn> Columns =>
        [
            new OrderIdColumn(),
            new OrderTenantIdColumn(),
            new OrderUserIdColumn(),
            new OrderTotalColumn(),
            new PlacedAtColumn(),
            new OrderStatusColumn(),
            new PlacedOnColumn(),
        ];

    public IEnumerable<IIndex> Indexes =>
        [new OrdersPrimaryIndex(), new OrdersTenantUniqueIndex()];
}
