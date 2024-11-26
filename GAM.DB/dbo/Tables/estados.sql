CREATE TABLE [dbo].[estados] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Estado]         VARCHAR (250) NULL,
    [Activo]         BIT           NULL,
    [Fecha_Registro] DATETIME      NULL
);

