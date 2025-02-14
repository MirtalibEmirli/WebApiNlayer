CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1,1) NOT NULL PRIMARY KEY,
    [Name]        NVARCHAR(255)  NOT NULL,
    [UpdatedBy]   INT            NOT NULL DEFAULT 0,
    [CreatedBy]   INT            NOT NULL DEFAULT 0,
    [DeletedBy]   INT            NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [DeletedDate] DATETIME2 (7)  NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL DEFAULT 0
);
