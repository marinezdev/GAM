CREATE TABLE [dbo].[UsuariosEmpresasOportunidades] (
    [IdUsuario]     INT NULL,
    [IdEmpresa]     INT NULL,
    [IdOportunidad] INT NULL,
    [IdBitacora]    INT NULL,
    CONSTRAINT [FK_UsuariosEmpresasOportunidades_Bitacora] FOREIGN KEY ([IdBitacora]) REFERENCES [dbo].[Bitacora] ([Id]),
    CONSTRAINT [FK_UsuariosEmpresasOportunidades_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_UsuariosEmpresasOportunidades_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id]),
    CONSTRAINT [FK_UsuariosEmpresasOportunidades_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

