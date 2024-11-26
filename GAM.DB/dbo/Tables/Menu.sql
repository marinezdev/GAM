CREATE TABLE [dbo].[Menu] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [IdJQuery]        NVARCHAR (50) NULL,
    [Ruta]            NVARCHAR (50) NULL,
    [Icono]           NVARCHAR (50) NULL,
    [Nombre]          NVARCHAR (50) NULL,
    [IdConfiguracion] INT           NULL,
    [Disponible]      BIT           NULL
);

