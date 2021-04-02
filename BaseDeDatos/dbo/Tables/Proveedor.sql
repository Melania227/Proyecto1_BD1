CREATE TABLE [dbo].[Proveedor]
(
    [ID_Proveedor] INT IDENTITY (0, 1) NOT NULL,
	[NombreProveedor] VARCHAR(50) NOT NULL, 
    [Direccion] VARCHAR(50) NOT NULL, 
    [NombreContacto] VARCHAR(50) NOT NULL, 
    [Ciudad] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED ([ID_Proveedor] ASC), 
    CONSTRAINT [AK_Proveedor] UNIQUE ([NombreProveedor])
)
