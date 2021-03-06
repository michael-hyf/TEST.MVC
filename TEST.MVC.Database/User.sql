﻿CREATE TABLE [dbo].[User] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [Created]   DATETIME      NULL DEFAULT getdate(),
    [Author]    INT           NULL,
    [Modified]  DATETIME      NULL DEFAULT getdate(),
    [Editor]    INT           NULL,
    [IsDeleted] BIT           NULL DEFAULT 0,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);


