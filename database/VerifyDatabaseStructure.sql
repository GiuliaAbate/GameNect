-- elenco tabelle
SELECT   TABLE_SCHEMA,
         TABLE_NAME
FROM     INFORMATION_SCHEMA.TABLES
WHERE    TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

-- elenco chiavi esterne
SELECT   fk.name AS ForeignKeyName,
         OBJECT_NAME(fk.parent_object_id) AS TableName,
         OBJECT_NAME(fk.referenced_object_id) AS ReferencedTable
FROM     sys.foreign_keys AS fk
ORDER BY TableName, ForeignKeyName;

-- elenco indiici
SELECT   t.name AS TableName,
         i.name AS IndexName,
         i.type_desc AS IndexType,
         i.is_unique AS IsUnique,
         i.is_primary_key AS IsPrimaryKey,
         i.has_filter AS HasFilter,
         i.filter_definition AS FilterDefinition
FROM     sys.indexes AS i
         INNER JOIN
         sys.tables AS t
         ON i.object_id = t.object_id
WHERE    i.index_id > 0
ORDER BY t.name, i.name;