CREATE TABLE [dbo].[Telefono_Proveedor]
(
	[ID_Proveedor] INT NOT NULL,
	[Telefono] INT NOT NULL, 
    CONSTRAINT [PK_TelefonoProveedor] PRIMARY KEY ([ID_Proveedor],[Telefono]),
    CONSTRAINT [FK_Proveedor] FOREIGN KEY ([ID_Proveedor]) REFERENCES [Proveedor]([ID_Proveedor]) ON DELETE CASCADE ON UPDATE CASCADE
)