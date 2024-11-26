CREATE TABLE [dbo].[OportunidadesResponsables] (
    [IdOportunidad]                 INT NULL,
    [IdAsignado]                    INT NULL,
    [IdClasificacionResponsable]    INT NULL,
    [IdSubClasificacionResponsable] INT NULL,
    CONSTRAINT [FK_OportunidadesResponsables_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);

