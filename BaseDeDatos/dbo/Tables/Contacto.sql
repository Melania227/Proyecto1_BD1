CREATE TABLE [dbo].[Contacto]
(
	[ID_Contacto] INT          IDENTITY (0, 1) NOT NULL,
    [Nombre] VARCHAR(50) NOT NULL, 
    [Telefono] INT NOT NULL, 
    [Cargo] VARCHAR(50) NOT NULL, 
    [Cedula_Organizacion] BIGINT NOT NULL,
    CONSTRAINT [PK_Contacto] PRIMARY KEY ([ID_Contacto],[Cedula_Organizacion]), 
    CONSTRAINT [AK_Contacto] UNIQUE ([Nombre]),
    CONSTRAINT [FK_CedulaOrganizacion] FOREIGN KEY ([Cedula_Organizacion]) REFERENCES [Organizacion]([Cedula]) ON DELETE CASCADE ON UPDATE CASCADE
)
