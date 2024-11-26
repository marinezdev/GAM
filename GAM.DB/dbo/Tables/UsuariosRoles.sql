CREATE TABLE [dbo].[UsuariosRoles] (
    [IdUsuario] INT NULL,
    [IdRol]     INT NULL,
    CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_UsuariosRoles_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

