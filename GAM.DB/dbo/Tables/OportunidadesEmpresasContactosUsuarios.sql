CREATE TABLE [dbo].[OportunidadesEmpresasContactosUsuarios] (
    [IdOportunidad]   INT NULL,
    [IdEmpresa]       INT NULL,
    [IdUsuario]       INT NULL,
    [IdConfiguracion] INT NULL,
    CONSTRAINT [FK_OportunidadesActividadesEmpresasContactosUsuarios_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id]),
    CONSTRAINT [FK_OportunidadesActividadesEmpresasContactosUsuarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);



