CREATE TABLE [dbo].[ContactosEmpresas] (
    [IdContacto] INT NULL,
    [IdEmpresa]  INT NULL,
    CONSTRAINT [FK_ContactosEmpresas_Contactos] FOREIGN KEY ([IdContacto]) REFERENCES [dbo].[Contactos] ([Id]),
    CONSTRAINT [FK_ContactosEmpresas_Empresas] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresas] ([Id])
);

