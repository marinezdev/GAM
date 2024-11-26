CREATE TABLE [dbo].[CompartirOportunidades] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [IdOportunidad] INT NULL,
    [IdUsuario]     INT NULL,
    [Activo]        BIT CONSTRAINT [DF_CompartirOportunidades_Activo] DEFAULT ((1)) NULL
);

