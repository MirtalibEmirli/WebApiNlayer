CREATE TABLE [dbo].[Customers] (
    [Id]          INT            IDENTITY (1,1) NOT NULL PRIMARY KEY,
    [FirstName]   NVARCHAR(255)  NOT NULL,
    [LastName]    NVARCHAR(255)  NOT NULL,
    [Email]       NVARCHAR(255)    NULL,
    [UpdatedBy]   INT            NOT NULL DEFAULT 0,
    [Balance]     INT            DEFAULT 0,
    [Bill]        INT DEFAULT 0,
    [CreatedBy]   INT            NOT NULL DEFAULT 0,
    [DeletedBy]   INT            NOT NULL DEFAULT 0,
    [CreatedDate] DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [DeletedDate] DATETIME2 (7)  NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL DEFAULT 0
);

 