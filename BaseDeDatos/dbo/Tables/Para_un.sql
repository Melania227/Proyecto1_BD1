CREATE TABLE [dbo].[Para_un]
(
	[ID_Parte] INT NOT NULL,
	[ID_Automovil] INT NOT NULL, 
    CONSTRAINT [FK_ParaUn_Parte] FOREIGN KEY ([ID_Parte]) REFERENCES [Parte]([ID_Parte]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_ParaUn_Automovil] FOREIGN KEY ([ID_Automovil]) REFERENCES [Automovil]([ID_Automovil]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [PK_ParaUn] PRIMARY KEY ([ID_Parte],[ID_Automovil])
)
