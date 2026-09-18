using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record EmptyNameTable : ITable
{
    public IString Name => new String("");

    public IEnumerable<IColumn> Columns => [];

    public IEnumerable<IIndex> Indexes => [];
}
