CREATE TABLE [dbo].[Proveidas_por]
(
	[ID_Proveedor] INT NOT NULL,
	[ID_Parte] INT NOT NULL, 
    [Precio] DECIMAL(9,2) NOT NULL, 
    [PrecioCliente] DECIMAL(9,2) NOT NULL, 
    [PorciónGanada] INT NOT NULL, 
    CONSTRAINT [FK_ProveidasPorProveedor] FOREIGN KEY ([ID_Proveedor]) REFERENCES [Proveedor]([ID_Proveedor]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_ProveidasPorParte] FOREIGN KEY ([ID_Parte]) REFERENCES [Parte]([ID_Parte]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [PK_ProveídasPor] PRIMARY KEY ([ID_Proveedor],[ID_Parte]), 

)
