CREATE TABLE [dbo].[EtapasBitacoraUsuarios] (
    [IdBitacora] INT      NULL,
    [Estado]     INT      NULL,
    [Fecha]      DATETIME CONSTRAINT [DF_EtapasBitacoraUsuarios_Fecha] DEFAULT (getdate()) NULL
);

