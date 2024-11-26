CREATE TABLE [dbo].[poblaciones] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [IdEstado]       INT           NOT NULL,
    [Poblacion]      VARCHAR (250) NULL,
    [Activo]         BIT           NULL,
    [Fecha_Registro] DATETIME      NULL
);

