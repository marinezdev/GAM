CREATE TABLE [dbo].[cp] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [IdPoblacion]    INT           NOT NULL,
    [CP]             VARCHAR (250) NULL,
    [Activo]         BIT           NULL,
    [Fecha_Registro] DATETIME      NULL
);

