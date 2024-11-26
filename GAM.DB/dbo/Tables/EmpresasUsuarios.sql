CREATE TABLE [dbo].[EmpresasUsuarios] (
    [IdEmpresa] INT NULL,
    [IdUsuario] INT NULL,
    [Activo]    BIT NULL,
    CONSTRAINT [FK_EmpresasUsuarios_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_EmpresasUsuarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

