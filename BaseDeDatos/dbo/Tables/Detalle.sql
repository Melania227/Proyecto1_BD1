CREATE TABLE [dbo].[Detalle]
(
    [Numero] INT NOT NULL identity (0,1),
    [ID_Orden] INT NOT NULL,
    [ID_Parte] INT NOT NULL,
    [ID_Proveedor] INT NOT NULL,
    [Cantidad] INT NOT NULL, 
    [PrecioPieza] DECIMAL(9,2) NOT NULL,
    CONSTRAINT [FK_DetalleProveedor] FOREIGN KEY ([ID_Proveedor]) REFERENCES [Proveedor]([ID_Proveedor]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_DetalleParte] FOREIGN KEY ([ID_Parte]) REFERENCES [Parte]([ID_Parte]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_DetalleOrden] FOREIGN KEY ([ID_Orden]) REFERENCES [Orden]([ID_Orden]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [PK_Detalle] PRIMARY KEY ([ID_Orden],[Numero]) 
)
