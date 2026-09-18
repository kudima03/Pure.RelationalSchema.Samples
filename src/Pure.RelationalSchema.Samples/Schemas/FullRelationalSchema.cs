using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Schemas;

public sealed record FullRelationalSchema : ISchema
{
    public IString Name => new String("full_schema");

    public IEnumerable<ITable> Tables =>
        [
            new EmptyTable(),
            new SingleColumnTable(),
            new TableWithoutIndexes(),
            new TableWithSingleIndex(),
            new TableWithIndexes(),
            new AllColumnTypesTable(),
            new UsersTable(),
            new OrdersTable(),
            new ProductsTable(),
            new OrderItemsTable(),
            new EmployeesTable(),
        ];

    public IEnumerable<IForeignKey> ForeignKeys =>
        [
            new EmptyColumnsForeignKey(),
            new SingleColumnForeignKey(),
            new CompositeForeignKey(),
            new OrderItemsToProductsForeignKey(),
            new SelfReferencingForeignKey(),
        ];
}
