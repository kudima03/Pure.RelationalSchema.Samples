# Changelog

All notable changes to `Pure.RelationalSchema.Samples` are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Because every sample is public API, renaming a sample or changing the contents of an
existing one is a breaking change and is released as such.

## [Unreleased]

### Added

- Full schema catalogue tree in the README, listing every sample schema with its
  tables, columns, indexes and foreign keys.
- README is now packed into the NuGet package, so it renders on the package page.

### Changed

- Solution migrated from `.sln` to the `.slnx` format.
- Package validation enabled against baseline `0.1.0-preview.0.1.0`, so breaking API
  changes fail the build.

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
  - `ForeignKeys` — empty-columns, single-column, composite and self-referencing
    foreign keys.
  - `Schemas` — graded from `EmptyRelationalSchema` through index, column-type and
    foreign-key variants to `FullRelationalSchema`.
- xUnit test project asserting every sample by structural hash, at 100% line coverage
  and 100% mutation score.
- Multi-targeting for net7.0, net8.0, net9.0 and net10.0, AOT-compatible.

[Unreleased]: https://github.com/kudima03/Pure.RelationalSchema.Samples/compare/0.1.0-preview.0.1.0...HEAD
[0.1.0-preview.0.1.0]: https://github.com/kudima03/Pure.RelationalSchema.Samples/releases/tag/0.1.0-preview.0.1.0
