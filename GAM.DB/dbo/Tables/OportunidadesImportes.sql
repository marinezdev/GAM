CREATE TABLE [dbo].[OportunidadesImportes] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [IdOportunidad] INT            NULL,
    [Importe]       FLOAT (53)     NULL,
    [Moneda]        INT            NULL,
    [TipoCambio]    FLOAT (53)     CONSTRAINT [DF_OportunidadesImportes_TipoCambio] DEFAULT ((0)) NULL,
    [Rubro]         INT            NULL,
    [Observaciones] NVARCHAR (250) NULL
);

