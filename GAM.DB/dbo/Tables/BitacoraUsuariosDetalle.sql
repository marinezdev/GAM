CREATE TABLE [dbo].[BitacoraUsuariosDetalle] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [IdBitacora]      INT            NULL,
    [IdUsuario]       INT            NULL,
    [IdTipoActividad] INT            NULL,
    [Fecha]           DATETIME       NULL,
    [Notas]           NVARCHAR (500) NULL,
    [Creado]          DATETIME       CONSTRAINT [DF_BitacoraUsuariosDetalle_Creado] DEFAULT (getdate()) NULL
);

