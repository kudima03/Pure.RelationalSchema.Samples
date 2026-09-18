using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record SingleColumnTable : ITable
{
    public IString Name => new String("single_column_table");

    public IEnumerable<IColumn> Columns => [new IdColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
