CREATE TABLE [dbo].[Escalacion] (
    [IdOportunidad]     INT  NULL,
    [Fecha]             DATE NULL,
    [IdUsuarioContacto] INT  NULL,
    CONSTRAINT [FK_Escalacion_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);

