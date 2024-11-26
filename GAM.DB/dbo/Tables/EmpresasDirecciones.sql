CREATE TABLE [dbo].[EmpresasDirecciones] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]       INT            NULL,
    [IdTipoDireccion] INT            NULL,
    [Direccion]       NVARCHAR (250) NULL,
    [CP]              NCHAR (5)      NULL,
    [Ciudad]          NVARCHAR (250) NULL,
    [IdPais]          INT            NULL
);

