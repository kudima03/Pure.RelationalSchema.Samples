using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record RelationalSchemaWithIndexes : ISchema
{
    public IString Name => new String("schema_with_indexes");

    public IEnumerable<ITable> Tables =>
        [new TableWithSingleIndex(), new TableWithIndexes()];

    public IEnumerable<IForeignKey> ForeignKeys => [];
}
