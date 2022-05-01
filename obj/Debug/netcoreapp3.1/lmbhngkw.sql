IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Turmas] (
    [Id] int NOT NULL IDENTITY,
    [nome] nvarchar(max) NOT NULL,
    [AlunoId] int NOT NULL,
    CONSTRAINT [PK_Turmas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Aluno] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Nota1] decimal(18,4) NOT NULL,
    [Nota2] decimal(18,4) NOT NULL,
    [Nota3] decimal(18,4) NOT NULL,
    [MediaFinal] decimal(18,4) NOT NULL,
    [TurmaId] int NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Aluno_Turmas_TurmaId] FOREIGN KEY ([TurmaId]) REFERENCES [Turmas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Aluno_TurmaId] ON [Aluno] ([TurmaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220430153013_initialClass', N'3.1.24');

GO

