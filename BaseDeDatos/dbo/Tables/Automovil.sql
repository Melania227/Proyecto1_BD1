CREATE TABLE [dbo].[Automovil]
(
	[ID_Automovil] INT IDENTITY (0, 1) NOT NULL, 
    [añoFabricacion] INT NOT NULL, 
    [Fabricante] VARCHAR(50) NOT NULL, 
    [Modelo] VARCHAR(50) NOT NULL, 
    [Detalle] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Automóvil] PRIMARY KEY ([ID_Automovil]), 
    CONSTRAINT [AK_Automóvil] UNIQUE ([Fabricante],[Modelo],[añoFabricacion]) 

)
