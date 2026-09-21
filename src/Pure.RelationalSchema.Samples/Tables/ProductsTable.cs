using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record ProductsTable : ITable
{
    public IString Name => new String("products");

    public IEnumerable<IColumn> Columns =>
        [
            new ProductIdColumn(),
            new ProductNameColumn(),
            new ProductDescriptionColumn(),
            new ProductPriceColumn(),
            new ProductInStockColumn(),
        ];

    public IEnumerable<IIndex> Indexes => [new ProductsPrimaryIndex()];
}
