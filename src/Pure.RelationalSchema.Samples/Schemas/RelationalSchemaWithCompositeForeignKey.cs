using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record RelationalSchemaWithCompositeForeignKey : ISchema
{
    public IString Name => new String("schema_with_composite_foreign_key");

    public IEnumerable<ITable> Tables => [new OrdersTable(), new OrderItemsTable()];

    public IEnumerable<IForeignKey> ForeignKeys => [new CompositeForeignKey()];
}
