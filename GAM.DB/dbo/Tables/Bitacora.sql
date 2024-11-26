CREATE TABLE [dbo].[Bitacora] (
    [Id]                            INT            IDENTITY (1, 1) NOT NULL,
    [Notas]                         NVARCHAR (MAX) NULL,
    [Fecha]                         DATETIME       CONSTRAINT [DF_Bitacora_Fecha] DEFAULT (getdate()) NULL,
    [Estado]                        INT            CONSTRAINT [DF_Bitacora_Estado] DEFAULT ((1)) NULL,
    [IdResponsable]                 INT            NULL,
    [IdOportunidad]                 INT            NULL,
    [IdClasificacionResponsable]    INT            NULL,
    [IdSubClasificacionResponsable] INT            NULL,
    CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bitacora_Usuarios] FOREIGN KEY ([IdResponsable]) REFERENCES [dbo].[Usuarios] ([Id])
);

