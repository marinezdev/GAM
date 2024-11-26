CREATE TABLE [dbo].[ClasificacionRolesContactos] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ClasificacionRolesContactos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

