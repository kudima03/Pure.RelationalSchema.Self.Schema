# Changelog

All notable changes to Pure.RelationalSchema.Self.Schema are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.6.0.2] — 2026-08-04

- Maintenance release: dependency and build updates.

## [0.1.0-preview.6.0.1] — 2026-05-28

- Maintenance release: dependency and build updates.

## [0.1.0-preview.6.0.0] — 2026-03-14

### Changed

- **Breaking:** Row identity redesigned across every entity table (`column_types`,
  `columns`, `indexes`, `tables`, `foreign_keys`, `schemas`) — each now carries a
  `uuid` column backed by a unique index, and all foreign keys that previously
  referenced the hash-based identity column now reference `uuid` instead.

### Added

- `UuidColumn` (`uuid`) and a `UuidUniqueIndex` unique index, used by all entity
  tables.

### Removed

- **Breaking:** `CompositionHashColumn` and its `composition_hash`
  (renamed `composition_uuid` shortly before removal) column removed from all
  tables in favor of the `uuid`-based identity.

## [0.1.0-preview.5.1.0] — 2025-12-08

### Added

- Multi-targeting: the package now targets `net7.0`, `net8.0`, `net9.0`, and
  `net10.0` (previously `net9.0` only).

## [0.1.0-preview.5.0.0] — 2025-11-12

- Maintenance release: dependency and build updates.

## [0.1.0-preview.4.0.0] — 2025-11-03

### Fixed

- `SchemasToTablesSchemaForeignKey` referenced the wrong table — the
  `reference_to_schema` foreign key on `schemas_to_tables` pointed at `tables`
  instead of `schemas`; it now points at `schemas`.

## [0.1.0-preview.3.3.1] — 2025-11-03

### Fixed

- Corrected the declaration order of `RelationalSchemaSchema.Tables` so that
  referenced entity tables are listed before the join tables that depend on
  them.

## [0.1.0-preview.3.3.0] — 2025-10-29

### Added

- `CompositionHashColumn` (`composition_hash`) added to `ForeignKeysTable`,
  `IndexesTable`, `SchemasTable`, and `TablesTable`.

## [0.1.0-preview.3.2.0] — 2025-10-28

### Added

- `SchemasToForeignKeysTable` (`schemas_to_foreign_keys`) join table, with
  foreign keys linking it to `SchemasTable` and `ForeignKeysTable`.

## [0.1.0-preview.3.1.0] — 2025-10-28

### Added

- `IndexesToColumnsTable` (`indexes_to_columns`) join table, with foreign
  keys linking it to `IndexesTable` and `ColumnsTable`.

## [0.1.0-preview.3.0.0] — 2025-10-25

### Changed

- **Breaking:** Removed the redundant `guid` column from the join tables
  `tables_to_columns`, `tables_to_indexes`, `foreign_keys_to_referencing_columns`,
  `foreign_keys_to_referenced_columns`, and `schemas_to_tables` — each now
  carries only its two reference columns.

## [0.1.0-preview.2.0.0] — 2025-10-07

### Removed

- **Breaking:** `AdaptersTable` and `AdaptersToSchemasTable`, along with their
  foreign keys, removed — the schema no longer models adapters.

## [0.1.0-preview.1.0.0] — 2025-10-06

### Fixed

- `ColumnTypesTable` no longer declares an erroneous self-referencing column
  type column; it now has only `name`.

## [0.1.0-preview.0.1.0] — 2025-10-02

### Added

- Initial release: `RelationalSchemaSchema`, a sealed record implementing
  `ISchema` that describes the relational schema metadata model itself —
  schemas, tables, columns, column types, indexes, and foreign keys, along
  with their join tables, and (at this version) an `adapters` table and its
  schema association.
