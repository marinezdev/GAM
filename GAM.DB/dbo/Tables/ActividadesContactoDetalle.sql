CREATE TABLE [dbo].[ActividadesContactoDetalle] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [IdActividadContacto] INT            NULL,
    [IdTipoActividad]     INT            NULL,
    [Fecha]               DATETIME       NULL,
    [Notas]               NVARCHAR (300) NULL,
    [Creado]              DATETIME       CONSTRAINT [DF_ActividadesContactoDetalle_Creado] DEFAULT (getdate()) NULL
);

