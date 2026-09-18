using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record RelationalSchemaWithoutForeignKeys : ISchema
{
    public IString Name => new String("schema_without_foreign_keys");

    public IEnumerable<ITable> Tables =>
        [new EmptyTable(), new SingleColumnTable(), new TableWithoutIndexes()];

    public IEnumerable<IForeignKey> ForeignKeys => [];
}
