using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;

namespace Pure.RelationalSchema.Samples.Indexes;

public sealed record EmptyIndex : IIndex
{
    public IBool IsUnique => new False();

    public IEnumerable<IColumn> Columns => [];
}
