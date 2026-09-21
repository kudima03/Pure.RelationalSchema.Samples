using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.ColumnTypes;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record CrossDomainColumnTypesAreReadableTests
{
    private static readonly IEnumerable<ITable> DomainRelations =
    [
        new UsersTable(),
        new OrdersTable(),
        new ProductsTable(),
        new OrderItemsTable(),
        new EmployeesTable(),
        new LoginsTable(),
        new StatusesTable(),
    ];

    private static readonly IEnumerable<IColumnType> ReadableTypes =
    [
        new BoolColumnType(),
        new DateColumnType(),
        new DateTimeColumnType(),
        new DoubleColumnType(),
        new StringColumnType(),
        new TimeColumnType(),
        new UuidColumnType(),
    ];

    [Fact]
    public void EveryDomainColumnTypeIsReadable()
    {
        IEnumerable<IColumn> columns = DomainRelations.SelectMany(t => t.Columns);

        Assert.All(
            columns,
            c =>
                Assert.Contains(
                    ReadableTypes,
                    t => new ColumnTypeHash(t).SequenceEqual(new ColumnTypeHash(c.Type))
                )
        );
    }
}
