CREATE TABLE [dbo].[Archivos] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (250) NULL,
    [IdOportunidad] INT            NULL,
    [Fecha]         DATETIME       CONSTRAINT [DF_Archivos_Fecha] DEFAULT (getdate()) NULL,
    [Notas]         NVARCHAR (250) NULL,
    [Version]       INT            NULL,
    CONSTRAINT [PK_Archivos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Archivos_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);



