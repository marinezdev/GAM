CREATE TABLE [dbo].[EstadoOportunidad] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [IdOportunidad] INT            NULL,
    [Estado]        INT            NULL,
    [Comentarios]   NVARCHAR (250) NULL,
    [Fecha]         DATETIME       CONSTRAINT [DF_EstadoOportunidad_Fecha] DEFAULT (getdate()) NULL
);

