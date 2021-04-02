CREATE TABLE [dbo].[Telefono_Persona]
(
	[Cedula] INT NOT NULL, 
    [Telefono] INT NOT NULL, 
    CONSTRAINT [PK_TelefonoPersona] PRIMARY KEY ([Cedula],[Telefono]),
    CONSTRAINT [FK_Persona] FOREIGN KEY ([Cedula]) REFERENCES [Persona]([Cedula]) ON DELETE CASCADE ON UPDATE CASCADE
)
