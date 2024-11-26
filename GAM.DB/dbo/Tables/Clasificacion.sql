CREATE TABLE [dbo].[Clasificacion] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (50) NULL,
    [IdConfiguracion] INT           NULL,
    CONSTRAINT [PK_Clasificacion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

