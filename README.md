# Pure.RelationalSchema.Samples

Named, predefined `ISchema` instances — and the tables, columns, indexes, column types and foreign keys they are built from — for the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.Samples/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Samples/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.Samples/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Samples/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.Samples)](https://www.nuget.org/packages/Pure.RelationalSchema.Samples)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.Samples` provides a fixed, deterministic catalogue of relational schema shapes implemented as sealed records over the interfaces from `Pure.RelationalSchema.Abstractions`. Every sample is a concrete named type with a parameterless constructor and stable contents — nothing is random, nothing is generated.

The catalogue is graded from trivial to full-set, so a consumer can pick the exact shape it needs:

| Shape | Sample |
|---|---|
| Nothing at all | `EmptyRelationalSchema` |
| One table, one column | `SingleTableRelationalSchema` |
| Several tables, no relations | `RelationalSchemaWithoutForeignKeys` |
| Unique, non-unique and composite indexes | `RelationalSchemaWithIndexes` |
| Every column type in one table | `RelationalSchemaWithAllColumnTypes` |
| A single-column relation | `RelationalSchemaWithForeignKeys` |
| A multi-column relation | `RelationalSchemaWithCompositeForeignKey` |
| A table referencing itself | `RelationalSchemaWithSelfReferencingTable` |
| Everything at once | `FullRelationalSchema` |

Because samples are ordinary `ISchema`/`ITable`/`IColumn`/`IIndex`/`IForeignKey` implementations, they compose with the rest of the ecosystem — hashing, serialization, OpenAPI schemas, storage adapters and conditions — without any adapter code.

## Schemas

`namespace Pure.RelationalSchema.Samples.Schemas`

| Class | `Name` | Tables | Foreign keys |
|---|---|---|---|
| `EmptyRelationalSchema` | `empty_schema` | 0 | 0 |
| `SingleTableRelationalSchema` | `single_table_schema` | 1 | 0 |
| `RelationalSchemaWithoutForeignKeys` | `schema_without_foreign_keys` | 3 | 0 |
| `RelationalSchemaWithIndexes` | `schema_with_indexes` | 2 | 0 |
| `RelationalSchemaWithAllColumnTypes` | `schema_with_all_column_types` | 1 | 0 |
| `RelationalSchemaWithForeignKeys` | `schema_with_foreign_keys` | 2 | 1 |
| `RelationalSchemaWithCompositeForeignKey` | `schema_with_composite_foreign_key` | 2 | 1 |
| `RelationalSchemaWithSelfReferencingTable` | `schema_with_self_referencing_table` | 1 | 1 |
| `FullRelationalSchema` | `full_schema` | 11 | 5 |

## Tables

`namespace Pure.RelationalSchema.Samples.Tables`

| Class | `Name` | Columns | Indexes |
|---|---|---|---|
| `EmptyTable` | `empty_table` | 0 | 0 |
| `EmptyNameTable` | *(empty string)* | 0 | 0 |
| `SingleColumnTable` | `single_column_table` | 1 | 0 |
| `TableWithoutIndexes` | `table_without_indexes` | 3 | 0 |
| `TableWithSingleIndex` | `table_with_single_index` | 2 | 1 |
| `TableWithIndexes` | `table_with_indexes` | 4 | 4 |
| `AllColumnTypesTable` | `all_column_types_table` | 10 | 0 |
| `UsersTable` | `users` | 6 | 2 |
| `OrdersTable` | `orders` | 5 | 2 |
| `ProductsTable` | `products` | 4 | 1 |
| `OrderItemsTable` | `order_items` | 5 | 1 |
| `EmployeesTable` | `employees` | 4 | 1 |

## Foreign Keys

`namespace Pure.RelationalSchema.Samples.ForeignKeys`

| Class | Referencing | Referenced |
|---|---|---|
| `EmptyColumnsForeignKey` | `empty_table` *(no columns)* | `single_column_table` *(no columns)* |
| `SingleColumnForeignKey` | `orders.user_id` | `users.id` |
| `CompositeForeignKey` | `order_items.order_id`, `order_items.tenant_id` | `orders.id`, `orders.tenant_id` |
| `SelfReferencingForeignKey` | `employees.manager_id` | `employees.id` |
| `OrderItemsToProductsForeignKey` | `order_items.product_id` | `products.id` |

## Indexes

`namespace Pure.RelationalSchema.Samples.Indexes`

| Class | Unique | Columns |
|---|---|---|
| `EmptyIndex` | no | *(none)* |
| `EmptyUniqueIndex` | yes | *(none)* |
| `SingleColumnUniqueIndex` | yes | `id` |
| `SingleColumnNonUniqueIndex` | no | `name` |
| `CompositeUniqueIndex` | yes | `tenant_id`, `id` |
| `CompositeNonUniqueIndex` | no | `name`, `created_at` |
| `DuplicateColumnsIndex` | no | `id`, `id` |

## Columns

`namespace Pure.RelationalSchema.Samples.Columns`

| Class | `Name` | Type |
|---|---|---|
| `IdColumn` | `id` | `UuidColumnType` |
| `NameColumn` | `name` | `StringColumnType` |
| `DescriptionColumn` | `description` | `StringColumnType` |
| `AgeColumn` | `age` | `IntColumnType` |
| `QuantityColumn` | `quantity` | `LongColumnType` |
| `PriceColumn` | `price` | `DoubleColumnType` |
| `IsActiveColumn` | `is_active` | `BoolColumnType` |
| `BirthDateColumn` | `birth_date` | `DateColumnType` |
| `StartTimeColumn` | `start_time` | `TimeColumnType` |
| `CreatedAtColumn` | `created_at` | `DateTimeColumnType` |
| `UserIdColumn` | `user_id` | `UuidColumnType` |
| `OrderIdColumn` | `order_id` | `UuidColumnType` |
| `ProductIdColumn` | `product_id` | `UuidColumnType` |
| `ManagerIdColumn` | `manager_id` | `UuidColumnType` |
| `TenantIdColumn` | `tenant_id` | `UuidColumnType` |
| `EmptyNameColumn` | *(empty string)* | `EmptyNameColumnType` |

## Column Types

`namespace Pure.RelationalSchema.Samples.ColumnTypes`

| Class | `Name` |
|---|---|
| `BoolColumnType` | `bool` |
| `IntColumnType` | `int` |
| `LongColumnType` | `long` |
| `DoubleColumnType` | `double` |
| `StringColumnType` | `string` |
| `UuidColumnType` | `uuid` |
| `DateColumnType` | `date` |
| `TimeColumnType` | `time` |
| `DateTimeColumnType` | `datetime` |
| `EmptyNameColumnType` | *(empty string)* |

## Dependencies

- [`Pure.RelationalSchema.Abstractions` 1.2.0](https://github.com/kudima03/Pure.RelationalSchema.Abstractions/tree/1.2.0) — the interfaces every sample implements (`ISchema`, `ITable`, `IColumn`, `IColumnType`, `IIndex`, `IForeignKey`)
- [`Pure.Primitives` 3.6.5](https://github.com/kudima03/Pure.Primitives/tree/3.6.5) — `String`, `True` and `False` used for sample names and index uniqueness

No implementation package (`Pure.RelationalSchema` and friends) is referenced, so the samples can be consumed by any repository in the ecosystem — including the implementations themselves — without a dependency cycle.

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```bash
dotnet add package Pure.RelationalSchema.Samples
```

## Usage

```csharp
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Samples.Schemas;

ISchema schema = new FullRelationalSchema();

// schema.Name.TextValue      == "full_schema"
// schema.Tables.Count()      == 11
// schema.ForeignKeys.Count() == 5
```

Underlying components are usable on their own:

```csharp
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Samples.ForeignKeys;
using Pure.RelationalSchema.Samples.Tables;

ITable table = new UsersTable();
IForeignKey foreignKey = new CompositeForeignKey();
```

Samples are deterministic, so they compare equal across instances by structural hash:

```csharp
using Pure.RelationalSchema.HashCodes;
using Pure.RelationalSchema.Samples.Tables;

bool same = new TableHash(new UsersTable()).SequenceEqual(new TableHash(new UsersTable()));
// true
```
