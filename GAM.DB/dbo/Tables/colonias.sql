CREATE TABLE [dbo].[colonias] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [IdCP]           INT           NOT NULL,
    [Colonia]        VARCHAR (250) NULL,
    [Activo]         BIT           NULL,
    [Fecha_Registro] DATETIME      NULL
);

