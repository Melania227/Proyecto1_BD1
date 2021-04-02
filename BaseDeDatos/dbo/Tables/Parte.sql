CREATE TABLE [dbo].[Parte]
(
	[ID_Parte] INT identity (0,1) NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL, 
    [Marca] VARCHAR(50) NOT NULL,
	[ID_Fabricante] int NOT NULL,
	UNIQUE(Nombre,Marca),
	CONSTRAINT [PK_Parte] PRIMARY KEY ([ID_Parte]),
	CONSTRAINT [FK_IDFabricante] FOREIGN KEY ([ID_Fabricante]) REFERENCES [dbo].[Fabricante] ([ID_Fabricante]) ON DELETE CASCADE ON UPDATE CASCADE
)
