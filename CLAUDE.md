# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet tool restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes              # check code style (CI enforces this)
dotnet csharpier check .                       # check code style (CI enforces this)
dotnet format && dotnet csharpier format .     # auto-fix code style
dotnet test --no-build --verbosity normal --logger trx --collect:"XPlat Code Coverage"
dotnet stryker --mutation-level Complete       # mutation testing (CI enforces this)
dotnet pack --configuration Release -p:Version=<version> --output .
```

## Architecture

This is a **sample-data NuGet library**: a catalogue of named, predefined relational schema instances used as fixtures by other repositories in the ecosystem. There is no logic here — every type is a sealed record with parameterless construction and hard-coded contents.

**Sub-namespaces, one sealed record per file:**

- `ColumnTypes` — `IColumnType` samples (`IntColumnType`, `UuidColumnType`, …, plus `EmptyNameColumnType`)
- `Columns` — `IColumn` samples (`IdColumn`, `NameColumn`, …, plus `EmptyNameColumn`)
- `Indexes` — `IIndex` samples (empty, single-column, composite, duplicate-column; unique and non-unique)
- `Tables` — `ITable` samples (empty, single-column, indexed, all-column-types, and the query-grade `users`/`orders`/`products`/`order_items`/`employees`/`logins`/`statuses` domain set)
- `ForeignKeys` — `IForeignKey` samples (empty-columns, single-column, composite, self-referencing, plus the cross-domain edges)
- `Schemas` — `ISchema` samples, graded from `EmptyRelationalSchema` to `FullRelationalSchema`, plus the `audit` and `refs` cross-domain schemas

**Everything is public API.** Consumers reference individual components (`new UsersTable()`), not only whole schemas, so no type here is an implementation detail. Renaming or changing the contents of an existing sample is a breaking change for every repository that asserts against it.

**Determinism is the contract.** Samples must never use randomness, ambient state, time or culture-sensitive formatting. Two instances of the same sample type must always produce identical structural hashes. `Pure.RelationalSchema.Random` is the package for random fixtures; this one is the opposite.

**The catalogue is graded.** When adding a case, keep the progression from empty → minimal → complex → full-set intact, and add the new table/foreign key to `FullRelationalSchema` if it belongs to the exhaustive set.

**Two grades coexist on purpose.** The shape tables (`EmptyTable`, `SingleColumnTable`, `TableWithoutIndexes`, `TableWithSingleIndex`, `TableWithIndexes`, `AllColumnTypesTable`) keep generic `id`/`name`/`tenant_id`/`created_at` columns and `int`/`long` types — they exist to exercise structural shapes, not queries. The domain relations (`users`, `orders`, `products`, `order_items`, `employees`, `logins`, `statuses`) are query-grade: every column is prefixed with its relation name and typed with one of the seven projection-readable `IColumnType`s (`bool`, `date`, `datetime`, `double`, `string`, `time`, `uuid`). Because `FullRelationalSchema` holds both grades, it is the one schema where `id`, `name`, `created_at` and `tenant_id` are deliberately ambiguous across relations — never use it as a qualifier for a cross-domain query.

### The cross-domain contract

`schema_with_foreign_keys` (core), `audit` and `refs` are query-grade schemas joined by foreign keys crossing schema boundaries. Five invariants keep a cross-domain query writable as the catalogue grows, each enforced by a test in `Tests/…/Schemas/CrossDomain*Tests.cs`:

- **CD1** — column names are globally unique across all domain relations, so a bare field reference resolves without qualification.
- **CD2** — every domain column is a projection-readable type (`bool`, `date`, `datetime`, `double`, `string`, `time`, `uuid`); no `int`/`long` on a domain relation.
- **CD3** — every foreign key's `ReferencingColumns`/`ReferencedColumns` have equal counts and pairwise-matching `ColumnTypeHash`.
- **CD4** — the domain relations, treated as nodes with foreign keys as undirected edges, form one connected graph.
- **CD5** — `id`, `name`, `created_at` and `tenant_id` stay out of every domain schema; their ambiguity is confined to `FullRelationalSchema`.

**Adding a domain relation later** must preserve all five:

1. Prefix every column with the relation name; no name may already exist anywhere in the domain set (CD1).
2. Use only the seven readable types (CD2).
3. Give the relation at least one foreign key to or from an existing domain relation, with pairwise-matching key types (CD3, CD4).
4. Give it a home schema — a new `ISchema` sample if it is a new domain, named for the domain and nothing else. A relation may appear in other sample schemas too, but its home is the one a cross-domain query qualifies it with.
5. Add it to `FullRelationalSchema`, which stays the exhaustive fixture.
6. Extend the CD1–CD5 tests' explicit relation list — they are written over an explicit list, not reflection, so a forgotten addition shows up as a failing count rather than a test that quietly checks less than it did.

**Dependencies are deliberately minimal:** `Pure.RelationalSchema.Abstractions` for the interfaces and `Pure.Primitives` for `String`/`True`/`False`. Do **not** reference `Pure.RelationalSchema` or any other implementation package — the implementations themselves consume these samples, and a reference would create a cycle.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All types must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation** is enabled in the csproj (`EnablePackageValidation`, `PackageValidationBaselineVersion`), so breaking API changes fail the build. Bump the baseline version once a new tag is published.

**Tests:** xUnit project targeting net10.0, mirroring the source layout one `…Tests` record per sample. Membership is asserted by structural hash (`ColumnHash`, `IndexHash`, `TableHash`, `ForeignKeyHash` from `Pure.RelationalSchema.HashCodes`), never by reference equality. Every sample needs: its name, the count of each collection, and a `Assert.Contains` per element — this is what keeps the mutation score at 100%.

**CI thresholds** (`.github/workflows/build-and-test.yml`): line coverage 98 (warning at 99) and mutation score 98. The repository currently sits at 100% for both; a new sample without matching tests will fail the build.

**Publishing:** triggered by pushing a semver tag matching `*.*.*`. The tag name becomes the package version. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format` + `csharpier` in CI:

- No `var` — always use explicit types
- No expression-bodied methods or constructors — use block bodies
- Properties use expression bodies (`=>`)
- File-scoped namespaces (`namespace Foo.Bar;`)
- No implicit object creation when the type is not apparent — `new Foo()`, not `new()`
- Private instance fields: `_camelCase`; private `static readonly` fields: `PascalCase` (StyleCop naming rule, `.editorconfig`)
- Max line length: 90 characters
- Prefer the dedicated `Pure.Primitives` type over a parameterised one — `new EmptyString()`, not `new String("")`
- Use `string.Empty` rather than `""` in test assertions
- Use `_ = Assert.Single(...)` in tests — an unused expression value trips IDE0058

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
