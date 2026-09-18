using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record OrderItemsToProductsForeignKey : IForeignKey
{
    public ITable ReferencingTable => new OrderItemsTable();

    public IEnumerable<IColumn> ReferencingColumns => [new ProductIdColumn()];

    public ITable ReferencedTable => new ProductsTable();

    public IEnumerable<IColumn> ReferencedColumns => [new IdColumn()];
}
