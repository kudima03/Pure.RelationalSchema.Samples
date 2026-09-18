using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record RelationalSchemaWithSelfReferencingTable : ISchema
{
    public IString Name => new String("schema_with_self_referencing_table");

    public IEnumerable<ITable> Tables => [new EmployeesTable()];

    public IEnumerable<IForeignKey> ForeignKeys => [new SelfReferencingForeignKey()];
}
