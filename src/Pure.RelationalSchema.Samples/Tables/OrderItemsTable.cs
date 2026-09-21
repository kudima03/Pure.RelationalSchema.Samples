using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record OrderItemsTable : ITable
{
    public IString Name => new String("order_items");

    public IEnumerable<IColumn> Columns =>
        [
            new ItemIdColumn(),
            new ItemTenantIdColumn(),
            new ItemOrderIdColumn(),
            new ItemProductIdColumn(),
            new ItemQtyColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [new OrderItemsPrimaryIndex()];
}
