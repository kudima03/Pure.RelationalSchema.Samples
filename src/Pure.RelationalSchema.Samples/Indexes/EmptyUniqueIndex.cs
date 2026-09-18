using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;

namespace Pure.RelationalSchema.Samples.Indexes;

public sealed record EmptyUniqueIndex : IIndex
{
    public IBool IsUnique => new True();

    public IEnumerable<IColumn> Columns => [];
}
