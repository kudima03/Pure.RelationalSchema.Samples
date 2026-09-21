# Changelog

All notable changes to `Pure.RelationalSchema.Samples` are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Because every sample is public API, renaming a sample or changing the contents of an
existing one is a breaking change and is released as such.

## [Unreleased]

## [0.1.0-preview.1.0.0] - 2026-09-21

### Added

- Full schema catalogue tree in the README, listing every sample schema with its
  tables, columns, indexes and foreign keys.
- README is now packed into the NuGet package, so it renders on the package page.
- 38 query-grade columns for the `users`, `orders`, `products`, `order_items` and
  `employees` domain relations, plus the new `logins` and `statuses` relations —
  every domain column is now one of the seven projection-readable types (`bool`,
  `date`, `datetime`, `double`, `string`, `time`, `uuid`) and globally unique by name.
- 7 new indexes (`UsersPrimaryIndex`, `UsersNameIndex`, `OrdersPrimaryIndex`,
  `OrdersTenantUniqueIndex`, `ProductsPrimaryIndex`, `OrderItemsPrimaryIndex`,
  `EmployeesPrimaryIndex`) replacing the column-bound index samples the domain
  relations can no longer use after the rename.
- `LoginsTable` (`logins`) and `StatusesTable` (`statuses`) — the `audit` and `refs`
  domains' sole relations.
- `LoginsToUsersForeignKey`, `OrdersToStatusesForeignKey` and
  `EmployeesToUsersForeignKey` — the edges that make the domain join graph connected
  and cross schema boundaries in both directions (uuid inbound, string outbound).
- `AuditRelationalSchema` (`audit`) and `RefsRelationalSchema` (`refs`) — cross-domain
  schemas joined to `schema_with_foreign_keys` by foreign keys.
- Five cross-domain contract tests (CD1–CD5) asserting, over the whole domain relation
  set, that column names stay globally unique, every domain column stays
  projection-readable, join keys stay pairwise type-compatible, the domain join graph
  stays connected, and the `id`/`name`/`created_at`/`tenant_id` ambiguity stays
  confined to `FullRelationalSchema`.

### Changed

- **Breaking:** `UsersTable`, `OrdersTable`, `ProductsTable`, `OrderItemsTable` and
  `EmployeesTable` are renamed and re-typed to query grade — every column is prefixed
  with its relation name (`id` → `user_id`, `price` → `order_total`, `quantity`
  (long) → `item_qty` (double), …) and typed with a projection-readable
  `IColumnType`. Column counts change: `users` 6 → 13, `orders` 5 → 7, `products`
  4 → 5, `order_items` 5 → 5 (all renamed), `employees` 4 → 5. See the README's
  Schema Catalogue and Columns tables for the full rename map.
- **Breaking:** `SingleColumnForeignKey`, `CompositeForeignKey`,
  `OrderItemsToProductsForeignKey` and `SelfReferencingForeignKey` now reference the
  renamed columns.
- **Breaking:** `RelationalSchemaWithForeignKeys` grows from 2 tables/1 foreign key to
  5 tables/6 foreign keys — it is now the query-grade core domain schema.
- **Breaking:** `FullRelationalSchema` grows from 11 tables/5 foreign keys to
  13 tables/8 foreign keys (`+ logins`, `+ statuses`, `+ LoginsToUsersForeignKey`,
  `+ OrdersToStatusesForeignKey`, `+ EmployeesToUsersForeignKey`).
- `RelationalSchemaWithCompositeForeignKey` and
  `RelationalSchemaWithSelfReferencingTable` keep their table/foreign-key counts, but
  every structural hash changes transitively through the renamed relations they hold.
- Every `TableHash`/`ForeignKeyHash`/`SchemaHash` of the samples above changes;
  consumers pinning hashes must retake them.
- Package validation enabled against baseline `0.1.0-preview.0.1.0`, so breaking API
  changes fail the build.
- `CLAUDE.md` documents the query-grade vs. shape grading, the cross-domain contract
  (CD1–CD5) and the recipe for adding a domain relation later.

## [0.1.0-preview.0.1.0] - 2026-09-18

### Added

- Initial deterministic sample catalogue over the interfaces from
  `Pure.RelationalSchema.Abstractions`, one sealed record per file:
  - `ColumnTypes` — `Bool`, `Date`, `DateTime`, `Double`, `Int`, `Long`, `String`,
    `Time`, `Uuid` and `EmptyName` column types.
  - `Columns` — `Id`, `Name`, `Age`, `BirthDate`, `CreatedAt`, `Description`,
    `IsActive`, `ManagerId`, `OrderId`, `Price`, `ProductId`, `Quantity`,
    `StartTime`, `TenantId`, `UserId` and `EmptyName` columns.
  - `Indexes` — empty, single-column and composite indexes in unique and non-unique
    variants, plus a duplicate-column index.
  - `Tables` — empty, empty-name, single-column, indexed and all-column-types tables,
    plus the `users`, `orders`, `products`, `order_items` and `employees` domain set.
  - `ForeignKeys` — empty-columns, single-column, composite, self-referencing and
    `order_items` → `products` foreign keys.
  - `Schemas` — graded from `EmptyRelationalSchema` through index, column-type and
    foreign-key variants to `FullRelationalSchema`.
- xUnit test project asserting every sample by structural hash, meeting the
  CI-enforced line coverage and mutation score thresholds.
- Multi-targeting for net7.0, net8.0, net9.0 and net10.0, AOT-compatible.

[Unreleased]: https://github.com/kudima03/Pure.RelationalSchema.Samples/compare/0.1.0-preview.1.0.0...HEAD
[0.1.0-preview.1.0.0]: https://github.com/kudima03/Pure.RelationalSchema.Samples/compare/0.1.0-preview.0.1.0...0.1.0-preview.1.0.0
[0.1.0-preview.0.1.0]: https://github.com/kudima03/Pure.RelationalSchema.Samples/releases/tag/0.1.0-preview.0.1.0
