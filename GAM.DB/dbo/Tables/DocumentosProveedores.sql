CREATE TABLE [dbo].[DocumentosProveedores] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (150) NULL,
    [IdProveedor]   INT            NULL,
    [Notas]         NVARCHAR (500) NULL,
    [Consecutivo]   INT            NULL,
    [Fecha]         DATETIME       CONSTRAINT [DF_DocumentosProveedores_Fecha] DEFAULT (getdate()) NULL,
    [PalabrasClave] NVARCHAR (50)  NULL
);

