using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Samples.Tables;

public sealed record EmptyNameTable : ITable
{
    public IString Name => new EmptyString();

    public IEnumerable<IColumn> Columns => [];

    public IEnumerable<IIndex> Indexes => [];
}
