using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.Samples.Columns;

public sealed record LoginAtColumn : IColumn
{
    public IString Name => new String("login_at");

    public IColumnType Type => new DateTimeColumnType();
}
