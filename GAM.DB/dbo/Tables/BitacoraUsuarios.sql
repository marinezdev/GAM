CREATE TABLE [dbo].[BitacoraUsuarios] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Notas]           NVARCHAR (50) NULL,
    [Fecha]           DATETIME      CONSTRAINT [DF_BitacoraUsuarios_Fecha] DEFAULT (getdate()) NULL,
    [Estado]          INT           NULL,
    [IdResponsable]   INT           NULL,
    [IdOportunidad]   INT           NULL,
    [IdTipoActividad] INT           NULL
);

