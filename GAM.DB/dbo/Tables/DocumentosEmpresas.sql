CREATE TABLE [dbo].[DocumentosEmpresas] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (150) NULL,
    [IdEmpresa]     INT            NULL,
    [Notas]         NVARCHAR (500) NULL,
    [Consecutivo]   INT            NULL,
    [Fecha]         DATETIME       CONSTRAINT [DF_DocumentosEmpresas_Fecha] DEFAULT (getdate()) NULL,
    [PalabrasClave] NVARCHAR (50)  NULL
);

