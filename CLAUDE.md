# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
csharpier check .                             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet test --no-build --verbosity normal --logger trx --collect:"XPlat Code Coverage"
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

Tests require Docker — the test project uses Testcontainers to spin up a real PostgreSQL container.

## Architecture

This is a **single-type NuGet library** — one public class, no service abstractions, no DI.

**Entry point:** `RelationalSchemaSchema` (sealed record implementing `ISchema`) — exposes 13 tables and 17 foreign keys that model the relational schema metadata storage layer itself (a self-description schema).

**The schema named `"schemas"` describes these entities:**

- `column_types` — registry of column types (uuid, name)
- `columns` — columns with a type reference (uuid, name, reference_to_column_type)
- `indexes` — indexes with uniqueness flag (uuid, is_unique)
- `tables` — tables (uuid, name)
- `foreign_keys` — foreign key declarations with referencing/referenced table references
- `schemas` — schema registry (uuid, name)

**Join tables** link entities in many-to-many relationships: `tables_to_columns`, `tables_to_indexes`, `indexes_to_columns`, `foreign_keys_to_referencing_columns`, `foreign_keys_to_referenced_columns`, `schemas_to_tables`, `schemas_to_foreign_keys`.

**Physical layout:** sub-namespaces `Tables`, `Columns`, `Indexes`, `ForeignKeys` hold one sealed record each. None of these types are part of the public API surface beyond what `ISchema` exposes — they are implementation detail.

**Dependency on `Pure.RelationalSchema` v2.0.0:** provides concrete `IColumnType` implementations (`StringColumnType`, `UuidColumnType`, `BoolColumnType`, etc.) used by column records, as well as the `ITable`, `IColumn`, `IIndex`, `IForeignKey` interfaces (transitively via `Pure.RelationalSchema.Abstractions`).

**Tests:** xUnit project targeting net10.0. Verifies table and foreign key membership by hash equality (`TableHash`, `ForeignKeyHash` from `Pure.RelationalSchema.HashCodes`). Includes one integration test (`Migrate`) that applies the schema against a real PostgreSQL container via `PostgreSqlCreatedSchema`.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All types must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.6.0.0`. Breaking API changes fail the build.

**Publishing:** triggered by pushing a semver tag matching `*.*.*`. The tag name becomes the `PackageVersion`. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format` + `csharpier` in CI:

- No `var` — always use explicit types
- No expression-bodied methods or constructors — use block bodies
- Properties use expression bodies (`=>`)
- File-scoped namespaces (`namespace Foo.Bar;`)
- No implicit object creation when the type is not apparent — `new Foo()`, not `new()`
- Private fields: `_camelCase`
- Max line length: 90 characters

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
