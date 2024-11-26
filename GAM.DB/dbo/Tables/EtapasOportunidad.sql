CREATE TABLE [dbo].[EtapasOportunidad] (
    [IdOportunidad]   INT      NULL,
    [Etapa]           INT      NULL,
    [Fecha]           DATETIME CONSTRAINT [DF_Etapas_Fecha] DEFAULT (getdate()) NULL,
    [Completada]      INT      CONSTRAINT [DF_EtapasOportunidad_Completada] DEFAULT ((0)) NULL,
    [FechaCompletada] DATE     NULL,
    CONSTRAINT [FK_Etapas_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);

