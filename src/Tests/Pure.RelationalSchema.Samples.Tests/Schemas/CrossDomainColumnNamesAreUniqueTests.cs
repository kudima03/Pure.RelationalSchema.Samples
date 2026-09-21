using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.Tests.Schemas;

public sealed record CrossDomainColumnNamesAreUniqueTests
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

    [Fact]
    public void TotalColumnCountIs41()
    {
        IEnumerable<string> names = DomainRelations
            .SelectMany(t => t.Columns)
            .Select(c => c.Name.TextValue);

        Assert.Equal(41, names.Count());
    }

    [Fact]
    public void AllColumnNamesAreDistinct()
    {
        IEnumerable<string> names = DomainRelations
            .SelectMany(t => t.Columns)
            .Select(c => c.Name.TextValue);

        Assert.Equal(names.Count(), names.Distinct().Count());
    }
}
