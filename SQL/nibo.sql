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

CREATE TABLE [Status] (
    [CODE] integer NOT NULL IDENTITY,
    [SEVERITY] VARCHAR(5) NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY ([CODE])
);

GO

CREATE TABLE [Transactions] (
    [Id] uniqueidentifier NOT NULL,
    [BankStatementId] uniqueidentifier NOT NULL,
    [TRNTYPE] varchar(10) NOT NULL,
    [DTPOSTED] datetime NOT NULL,
    [TRNAMT] decimal(5,2) NOT NULL,
    [MEMO] varchar(100) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_BankStatements_BankStatementId] FOREIGN KEY ([BankStatementId]) REFERENCES [BankStatements] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SignOn] (
    [SIGONID] uniqueidentifier NOT NULL,
    [StatusCode] integer NULL,
    [DTSERVER] datetime NOT NULL,
    [LANGUAGE] varchar(3) NULL,
    CONSTRAINT [PK_SignOn] PRIMARY KEY ([SIGONID]),
    CONSTRAINT [FK_SignOn_Status_StatusCode] FOREIGN KEY ([StatusCode]) REFERENCES [Status] ([CODE]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_SignOn_StatusCode] ON [SignOn] ([StatusCode]);

GO

CREATE INDEX [IX_Transactions_BankStatementId] ON [Transactions] ([BankStatementId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200613171906_inicio', N'3.1.5');

GO

