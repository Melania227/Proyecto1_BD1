CREATE TABLE [dbo].[Cliente] (
    [ID_Cliente]        INT          IDENTITY (0, 1) NOT NULL,
    [Ciudad]    VARCHAR (50) NOT NULL,
    [Direccion] VARCHAR (250) NOT NULL,
    [ID_Estado] INT          NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([ID_Cliente] ASC),
    CONSTRAINT [FK_IDEstado] FOREIGN KEY ([ID_Estado]) REFERENCES [dbo].[Estado] ([ID_Estado]) ON DELETE CASCADE ON UPDATE CASCADE
);

