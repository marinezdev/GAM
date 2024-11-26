CREATE TABLE [dbo].[SubClasificacion] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (50) NULL,
    [IdClasificacion] INT           NULL,
    CONSTRAINT [PK_SubClasificacion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SubClasificacion_Clasificacion] FOREIGN KEY ([IdClasificacion]) REFERENCES [dbo].[Clasificacion] ([Id])
);

