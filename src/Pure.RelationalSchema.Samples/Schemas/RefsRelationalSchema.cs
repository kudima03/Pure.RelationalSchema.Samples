using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record RefsRelationalSchema : ISchema
{
    public IString Name => new String("refs");

    public IEnumerable<ITable> Tables => [new StatusesTable()];

    public IEnumerable<IForeignKey> ForeignKeys => [];
}
