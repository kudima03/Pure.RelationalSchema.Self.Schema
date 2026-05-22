# Pure.RelationalSchema.Self.Schema

A concrete `ISchema` implementation that describes the relational schema metadata model itself — schemas, tables, columns, indexes, and foreign keys represented as a first-class database schema.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.Self.Schema/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Self.Schema/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.Self.Schema/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.Self.Schema/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.Self.Schema)](https://www.nuget.org/packages/Pure.RelationalSchema.Self.Schema)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.Self.Schema` provides `RelationalSchemaSchema` — a sealed record that implements `ISchema` and models the database structure used to store relational schema metadata. The schema name is `"schemas"` and it contains 13 tables and 17 foreign keys representing the entities and relationships of a schema registry (schemas, tables, columns, column types, indexes, and foreign keys) along with all their join tables.

This package is the canonical self-description of the Pure relational schema storage model. It can be passed directly to a storage adapter (e.g. `Pure.RelationalSchema.Storage.PostgreSQL`) to create or migrate the metadata database.

## Public API

### `RelationalSchemaSchema`

```
namespace Pure.RelationalSchema.Self.Schema
public sealed record RelationalSchemaSchema : ISchema
```

| Member | Value |
|---|---|
| `Name` | `"schemas"` |
| `Tables` | 13 tables (see below) |
| `ForeignKeys` | 17 foreign keys (see below) |

### Tables

| Class | SQL name | Columns |
|---|---|---|
| `ColumnTypesTable` | `column_types` | `uuid`, `name` |
| `ColumnsTable` | `columns` | `uuid`, `name`, `reference_to_column_type` |
| `IndexesTable` | `indexes` | `uuid`, `is_unique` |
| `TablesTable` | `tables` | `uuid`, `name` |
| `ForeignKeysTable` | `foreign_keys` | `uuid`, `referencing_table`, `referenced_table` |
| `SchemasTable` | `schemas` | `uuid`, `name` |
| `TablesToColumnsTable` | `tables_to_columns` | `reference_to_table`, `reference_to_column` |
| `TablesToIndexesTable` | `tables_to_indexes` | `reference_to_table`, `reference_to_index` |
| `IndexesToColumnsTable` | `indexes_to_columns` | `reference_to_index`, `reference_to_column` |
| `ForeignKeysToReferencingColumnsTable` | `foreign_keys_to_referencing_columns` | `reference_to_foreign_key`, `reference_to_column` |
| `ForeignKeysToReferencedColumnsTable` | `foreign_keys_to_referenced_columns` | `reference_to_foreign_key`, `reference_to_column` |
| `SchemasToTablesTable` | `schemas_to_tables` | `reference_to_schema`, `reference_to_table` |
| `SchemasToForeignKeysTable` | `schemas_to_foreign_keys` | `reference_to_schema`, `reference_to_foreign_key` |

All entity tables (`column_types`, `columns`, `indexes`, `tables`, `foreign_keys`, `schemas`) carry a `uuid` unique index.

### Foreign Keys

| Class | Referencing table → column | Referenced table → column |
|---|---|---|
| `ColumnsColumnTypesForeignKey` | `columns.reference_to_column_type` | `column_types.uuid` |
| `TablesToColumnsTableForeignKey` | `tables_to_columns.reference_to_table` | `tables.uuid` |
| `TablesToColumnsColumnForeignKey` | `tables_to_columns.reference_to_column` | `columns.uuid` |
| `TablesToIndexesTableForeignKey` | `tables_to_indexes.reference_to_table` | `tables.uuid` |
| `TablesToIndexesIndexesForeignKey` | `tables_to_indexes.reference_to_index` | `indexes.uuid` |
| `IndexesToColumnsIndexForeignKey` | `indexes_to_columns.reference_to_index` | `indexes.uuid` |
| `IndexesToColumnsColumnForeignKey` | `indexes_to_columns.reference_to_column` | `columns.uuid` |
| `ForeignKeysReferencingTableForeignKey` | `foreign_keys.referencing_table` | `tables.uuid` |
| `ForeignKeysReferencedTableForeignKey` | `foreign_keys.referenced_table` | `tables.uuid` |
| `ForeignKeysToReferencingColumnsTableForeignKeyForeignKey` | `foreign_keys_to_referencing_columns.reference_to_foreign_key` | `foreign_keys.uuid` |
| `ForeignKeysToReferencingColumnsTableColumnForeignKey` | `foreign_keys_to_referencing_columns.reference_to_column` | `columns.uuid` |
| `ForeignKeysToReferencedColumnsTableForeignKeyForeignKey` | `foreign_keys_to_referenced_columns.reference_to_foreign_key` | `foreign_keys.uuid` |
| `ForeignKeysToReferencedColumnsTableColumnForeignKey` | `foreign_keys_to_referenced_columns.reference_to_column` | `columns.uuid` |
| `SchemasToTablesSchemaForeignKey` | `schemas_to_tables.reference_to_schema` | `schemas.uuid` |
| `SchemasToTablesTableForeignKey` | `schemas_to_tables.reference_to_table` | `tables.uuid` |
| `SchemasToForeignKeysSchemaForeignKey` | `schemas_to_foreign_keys.reference_to_schema` | `schemas.uuid` |
| `SchemasToForeignKeysForeignKeyForeignKey` | `schemas_to_foreign_keys.reference_to_foreign_key` | `foreign_keys.uuid` |

## Dependencies

- [`Pure.RelationalSchema`](https://github.com/kudima03/Pure.RelationalSchema/tree/2.0.0) — concrete column type implementations (`StringColumnType`, `UuidColumnType`, etc.) and base record types used by all table, column, index, and foreign key implementations

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```
dotnet add package Pure.RelationalSchema.Self.Schema
```

## Usage

```csharp
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Self.Schema;

ISchema schema = new RelationalSchemaSchema();

// schema.Name.TextValue  == "schemas"
// schema.Tables.Count()  == 13
// schema.ForeignKeys.Count() == 17

// Pass to a storage adapter to create/migrate the metadata database
PostgreSqlCreatedSchema created = new PostgreSqlCreatedSchema(schema, connection);
```
