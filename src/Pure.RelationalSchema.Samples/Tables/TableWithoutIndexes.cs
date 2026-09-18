using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record TableWithoutIndexes : ITable
{
    public IString Name => new String("table_without_indexes");

    public IEnumerable<IColumn> Columns =>
        [new IdColumn(), new NameColumn(), new CreatedAtColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
