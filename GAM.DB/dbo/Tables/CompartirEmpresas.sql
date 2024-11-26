CREATE TABLE [dbo].[CompartirEmpresas] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [IdEmpresa] INT NULL,
    [IdUsuario] INT NULL,
    [Activo]    BIT CONSTRAINT [DF_CompartirEmpresas_Activo] DEFAULT ((1)) NULL
);

