CREATE TABLE [dbo].[Organizacion]
(
	[Cedula] BIGINT NOT NULL, 
    [Nombre] VARCHAR(50) NULL, 
    [ID_Cliente] INT NOT NULL,
    [ID_Contacto] INT,
    CONSTRAINT [PK_Organizacion] PRIMARY KEY ([Cedula]), 
    CONSTRAINT [AK_Organizacion] UNIQUE ([Nombre]),
    CONSTRAINT [FK_IDCliente_Organizacion] FOREIGN KEY ([ID_Cliente]) REFERENCES [Cliente]([ID_Cliente]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_IDContacto_Organizacion] FOREIGN KEY (ID_Contacto,Cedula) REFERENCES Contacto(ID_Contacto, Cedula_Organizacion)

)
