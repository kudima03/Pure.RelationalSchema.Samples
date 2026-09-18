using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Samples.Columns;

namespace Pure.RelationalSchema.Samples.Indexes;

public sealed record CompositeNonUniqueIndex : IIndex
{
    public IBool IsUnique => new False();

    public IEnumerable<IColumn> Columns => [new NameColumn(), new CreatedAtColumn()];
}
