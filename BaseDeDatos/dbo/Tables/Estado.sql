CREATE TABLE [dbo].[Estado] (
    [ID_Estado]   INT          IDENTITY (0, 1) NOT NULL,
    [Tipo] VARCHAR (50) NOT NULL UNIQUE,
    CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([ID_Estado] ASC),
    CONSTRAINT [AK_Estado] UNIQUE ([Tipo])
);

