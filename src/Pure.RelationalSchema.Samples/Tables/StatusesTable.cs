using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record StatusesTable : ITable
{
    public IString Name => new String("statuses");

    public IEnumerable<IColumn> Columns =>
        [new StatusCodeColumn(), new StatusLabelColumn(), new StatusIsFinalColumn()];

    public IEnumerable<IIndex> Indexes => [];
}
