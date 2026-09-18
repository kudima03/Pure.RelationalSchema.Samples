using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record EmptyColumnsForeignKey : IForeignKey
{
    public ITable ReferencingTable => new EmptyTable();

    public IEnumerable<IColumn> ReferencingColumns => [];

    public ITable ReferencedTable => new SingleColumnTable();

    public IEnumerable<IColumn> ReferencedColumns => [];
}
