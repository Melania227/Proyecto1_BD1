CREATE TABLE [dbo].[Persona]
(
	[Cedula] INT NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL, 
    ID_Cliente INT NOT NULL,
    CONSTRAINT [PK_Persona] PRIMARY KEY ([Cedula]), 
    CONSTRAINT [AK_Persona] UNIQUE ([Nombre]),
    CONSTRAINT [FK_IDCliente_Persona] FOREIGN KEY ([ID_Cliente]) REFERENCES [Cliente]([ID_Cliente]) ON DELETE CASCADE ON UPDATE CASCADE
)
