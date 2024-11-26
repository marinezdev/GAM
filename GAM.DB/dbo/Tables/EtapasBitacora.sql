CREATE TABLE [dbo].[EtapasBitacora] (
    [IdBitacora] INT      NULL,
    [Estado]     INT      NULL,
    [Fecha]      DATETIME CONSTRAINT [DF_EtapasBitacora_Fecha] DEFAULT (getdate()) NULL,
    CONSTRAINT [FK_EtapasBitacora_Bitacora] FOREIGN KEY ([IdBitacora]) REFERENCES [dbo].[Bitacora] ([Id])
);

