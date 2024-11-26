CREATE TABLE [dbo].[Actividades] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED ([Id] ASC)
);

