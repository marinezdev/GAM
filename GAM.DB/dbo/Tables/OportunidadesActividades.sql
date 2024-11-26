CREATE TABLE [dbo].[OportunidadesActividades] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [TipoActividad]     INT            NULL,
    [Fecha]             DATE           NULL,
    [Notas]             NVARCHAR (250) NULL,
    [IdOportunidad]     INT            NULL,
    [Agregado]          DATETIME       CONSTRAINT [DF_OportunidadesActividades_Agregado] DEFAULT (getdate()) NULL,
    [IdUsuario]         INT            NULL,
    [IdUsuarioAsignado] INT            NULL,
    CONSTRAINT [PK_OportunidadesActividades] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OportunidadesActividades_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);

