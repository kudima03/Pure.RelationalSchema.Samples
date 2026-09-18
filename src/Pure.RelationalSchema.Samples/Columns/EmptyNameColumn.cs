using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Samples.ColumnTypes;

namespace Pure.RelationalSchema.Samples.Columns;

public sealed record EmptyNameColumn : IColumn
{
    public IString Name => new EmptyString();

    public IColumnType Type => new EmptyNameColumnType();
}
