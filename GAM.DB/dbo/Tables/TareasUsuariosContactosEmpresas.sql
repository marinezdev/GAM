CREATE TABLE [dbo].[TareasUsuariosContactosEmpresas] (
    [IdTarea]    INT NULL,
    [IdUsuario]  INT NULL,
    [IdContacto] INT NULL,
    [IdEmpresa]  INT NULL,
    CONSTRAINT [FK_TareasUsuariosContactosEmpresas_Contactos] FOREIGN KEY ([IdContacto]) REFERENCES [dbo].[Contactos] ([Id]),
    CONSTRAINT [FK_TareasUsuariosContactosEmpresas_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_TareasUsuariosContactosEmpresas_Tareas] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tareas] ([Id]),
    CONSTRAINT [FK_TareasUsuariosContactosEmpresas_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

