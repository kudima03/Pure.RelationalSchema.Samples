using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record TableWithIndexes : ITable
{
    public IString Name => new String("table_with_indexes");

    public IEnumerable<IColumn> Columns =>
        [new IdColumn(), new TenantIdColumn(), new NameColumn(), new CreatedAtColumn()];

    public IEnumerable<IIndex> Indexes =>
        [
            new SingleColumnUniqueIndex(),
            new SingleColumnNonUniqueIndex(),
            new CompositeUniqueIndex(),
            new CompositeNonUniqueIndex(),
        ];
}
