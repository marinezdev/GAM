CREATE TABLE [dbo].[ArchivosBitacora] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]     NVARCHAR (150) NULL,
    [IdBitacora] INT            NULL,
    [Fecha]      DATETIME       CONSTRAINT [DF_ArchivosBitacora_Fecha] DEFAULT (getdate()) NULL,
    [Notas]      NVARCHAR (250) NULL,
    [Version]    NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ArchivosBitacora] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ArchivosBitacora_Bitacora] FOREIGN KEY ([IdBitacora]) REFERENCES [dbo].[Bitacora] ([Id])
);

