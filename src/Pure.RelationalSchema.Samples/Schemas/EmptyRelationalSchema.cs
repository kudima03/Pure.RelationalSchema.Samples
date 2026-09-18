using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record EmptyRelationalSchema : ISchema
{
    public IString Name => new String("empty_schema");

    public IEnumerable<ITable> Tables => [];

    public IEnumerable<IForeignKey> ForeignKeys => [];
}
