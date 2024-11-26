CREATE TABLE [dbo].[UsuarioConfiguracion] (
    [IdUsuario]       INT NULL,
    [IdConfiguracion] INT NULL,
    CONSTRAINT [FK_UsuarioConfiguracion_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

