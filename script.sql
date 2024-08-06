IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Skill] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [UserType] nvarchar(13) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ApplicantSkill] (
    [ApplicantsId] uniqueidentifier NOT NULL,
    [SkillsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ApplicantSkill] PRIMARY KEY ([ApplicantsId], [SkillsId]),
    CONSTRAINT [FK_ApplicantSkill_Skill_SkillsId] FOREIGN KEY ([SkillsId]) REFERENCES [Skill] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ApplicantSkill_User_ApplicantsId] FOREIGN KEY ([ApplicantsId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Education] (
    [Id] uniqueidentifier NOT NULL,
    [EducationType] int NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(500) NULL,
    [ApplicantId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Education] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Education_User_ApplicantId] FOREIGN KEY ([ApplicantId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Experience] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [Start] datetime2 NULL,
    [End] datetime2 NULL,
    [ApplicantId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Experience] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Experience_User_ApplicantId] FOREIGN KEY ([ApplicantId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [JobOffer] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(800) NOT NULL,
    [RecruiterId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JobOffer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobOffer_User_RecruiterId] FOREIGN KEY ([RecruiterId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [JobApplication] (
    [Id] uniqueidentifier NOT NULL,
    [State] int NOT NULL,
    [ApplicantId] uniqueidentifier NOT NULL,
    [JobOfferId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JobApplication] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobApplication_JobOffer_JobOfferId] FOREIGN KEY ([JobOfferId]) REFERENCES [JobOffer] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_JobApplication_User_ApplicantId] FOREIGN KEY ([ApplicantId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ApplicantSkill_SkillsId] ON [ApplicantSkill] ([SkillsId]);
GO

CREATE INDEX [IX_Education_ApplicantId] ON [Education] ([ApplicantId]);
GO

CREATE INDEX [IX_Experience_ApplicantId] ON [Experience] ([ApplicantId]);
GO

CREATE INDEX [IX_JobApplication_ApplicantId] ON [JobApplication] ([ApplicantId]);
GO

CREATE INDEX [IX_JobApplication_JobOfferId] ON [JobApplication] ([JobOfferId]);
GO

CREATE INDEX [IX_JobOffer_RecruiterId] ON [JobOffer] ([RecruiterId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240616161809_Initial', N'8.0.7');
GO

COMMIT;
GO

