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
- `Tables` — `ITable` samples (empty, single-column, indexed, all-column-types, and the `users`/`orders`/`products`/`order_items`/`employees` domain set)
- `ForeignKeys` — `IForeignKey` samples (empty-columns, single-column, composite, self-referencing)
- `Schemas` — `ISchema` samples, graded from `EmptyRelationalSchema` to `FullRelationalSchema`

**Everything is public API.** Consumers reference individual components (`new UsersTable()`), not only whole schemas, so no type here is an implementation detail. Renaming or changing the contents of an existing sample is a breaking change for every repository that asserts against it.

**Determinism is the contract.** Samples must never use randomness, ambient state, time or culture-sensitive formatting. Two instances of the same sample type must always produce identical structural hashes. `Pure.RelationalSchema.Random` is the package for random fixtures; this one is the opposite.

**The catalogue is graded.** When adding a case, keep the progression from empty → minimal → complex → full-set intact, and add the new table/foreign key to `FullRelationalSchema` if it belongs to the exhaustive set.

**Dependencies are deliberately minimal:** `Pure.RelationalSchema.Abstractions` for the interfaces and `Pure.Primitives` for `String`/`True`/`False`. Do **not** reference `Pure.RelationalSchema` or any other implementation package — the implementations themselves consume these samples, and a reference would create a cycle.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All types must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation** is present but commented out in the csproj — there is no published baseline yet. Uncomment `EnablePackageValidation` and set `PackageValidationBaselineVersion` to the latest released version once the first tag is published, so breaking API changes fail the build.

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
- Private fields: `_camelCase`
- Max line length: 90 characters
- Prefer the dedicated `Pure.Primitives` type over a parameterised one — `new EmptyString()`, not `new String("")`
- Use `string.Empty` rather than `""` in test assertions
- Use `_ = Assert.Single(...)` in tests — an unused expression value trips IDE0058

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
