IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [BankStatements] (
    [Id] uniqueidentifier NOT NULL,
    [NAME] varchar(100) NULL,
    [DTSTART] datetime NOT NULL,
    [DTEND] datetime NOT NULL,
    CONSTRAINT [PK_BankStatements] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Transactions] (
    [Id] uniqueidentifier NOT NULL,
    [BankStatementId] uniqueidentifier NOT NULL,
    [TRNTYPE] integer NOT NULL,
    [DTPOSTED] datetime NOT NULL,
    [TRNAMT] decimal(5,2) NOT NULL,
    [MEMO] varchar(100) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_BankStatements_BankStatementId] FOREIGN KEY ([BankStatementId]) REFERENCES [BankStatements] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Transactions_BankStatementId] ON [Transactions] ([BankStatementId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200613204508_v3', N'3.1.5');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200623151025_v4', N'3.1.5');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BankStatements]') AND [c].[name] = N'NAME');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [BankStatements] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [BankStatements] DROP COLUMN [NAME];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BankStatements]') AND [c].[name] = N'DTEND');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [BankStatements] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [BankStatements] DROP COLUMN [DTEND];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BankStatements]') AND [c].[name] = N'DTSTART');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [BankStatements] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [BankStatements] DROP COLUMN [DTSTART];

GO

EXEC sp_rename N'[Transactions].[TRNTYPE]', N'Trntype', N'COLUMN';

GO

EXEC sp_rename N'[Transactions].[DTPOSTED]', N'Dtposted', N'COLUMN';

GO

EXEC sp_rename N'[Transactions].[MEMO]', N'Memo', N'COLUMN';

GO

EXEC sp_rename N'[Transactions].[TRNAMT]', N'Trnamt', N'COLUMN';

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Trnamt');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Transactions] ALTER COLUMN [Trnamt] decimal NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200623162231_v5', N'3.1.5');

GO

