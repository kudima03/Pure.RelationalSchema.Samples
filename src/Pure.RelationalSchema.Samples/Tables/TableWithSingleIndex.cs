using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Indexes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record TableWithSingleIndex : ITable
{
    public IString Name => new String("table_with_single_index");

    public IEnumerable<IColumn> Columns => [new IdColumn(), new NameColumn()];

    public IEnumerable<IIndex> Indexes => [new SingleColumnUniqueIndex()];
}
