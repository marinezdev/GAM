CREATE TABLE [dbo].[FechaVencimientoCambios] (
    [Id]                       INT      IDENTITY (1, 1) NOT NULL,
    [FechaVencimientoAnterior] DATETIME NULL,
    [IdOportunidad]            INT      NULL,
    [IdUsuario]                INT      NULL
);

