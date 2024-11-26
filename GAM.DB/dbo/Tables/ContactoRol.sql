CREATE TABLE [dbo].[ContactoRol] (
    [Id]                            INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                        NVARCHAR (250) NULL,
    [IdClasificacionRolesContactos] INT            NULL,
    CONSTRAINT [PK_ContactoRol] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContactoRol_ClasificacionRolesContactos] FOREIGN KEY ([IdClasificacionRolesContactos]) REFERENCES [dbo].[ClasificacionRolesContactos] ([Id])
);

