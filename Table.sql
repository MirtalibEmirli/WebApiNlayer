CREATE TABLE [dbo].[Tables] (
    [Id]		   INT			IDENTITY(1,1)	 NOT NULL,
    [TableNumber]  varchar(200) Not null,
    [Capacity]     INT Not null DEFAULT(2) ,
    [IsReserved]   BIT             DEFAULT((0)) NOT NULL,
    [CreatedBy]    INT            NULL,
    [UpdatedBy]    INT            NULL,
    [DeletedBy]    INT            NULL,
    [CreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]  DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    [IsDeleted]    BIT            DEFAULT ((0)) NOT NULL,

)