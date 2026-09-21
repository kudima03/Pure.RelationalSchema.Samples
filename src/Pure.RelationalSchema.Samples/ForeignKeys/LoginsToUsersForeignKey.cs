using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Samples.Tables;

namespace Pure.RelationalSchema.Samples.ForeignKeys;

public sealed record LoginsToUsersForeignKey : IForeignKey
{
    public ITable ReferencingTable => new LoginsTable();

    public IEnumerable<IColumn> ReferencingColumns => [new LoginUserIdColumn()];

    public ITable ReferencedTable => new UsersTable();

    public IEnumerable<IColumn> ReferencedColumns => [new UserIdColumn()];
}
