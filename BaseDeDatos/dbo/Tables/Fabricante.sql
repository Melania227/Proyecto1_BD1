CREATE TABLE [dbo].[Fabricante]
(
	[ID_Fabricante] INT identity (0,1) NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL UNIQUE, 
    CONSTRAINT [PK_Fabricante] PRIMARY KEY ([ID_Fabricante]),
	CONSTRAINT [AK_Fabricante] UNIQUE ([Nombre])
	
)
