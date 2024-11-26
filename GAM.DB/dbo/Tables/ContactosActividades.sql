CREATE TABLE [dbo].[ContactosActividades] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [IdBitacora]    INT            NULL,
    [IdContacto]    INT            NULL,
    [TipoActividad] INT            NULL,
    [Fecha]         DATE           NULL,
    [Notas]         NVARCHAR (250) NULL,
    [Creado]        DATETIME       CONSTRAINT [DF_ActividadesResponsable_Creado] DEFAULT (getdate()) NULL
);

