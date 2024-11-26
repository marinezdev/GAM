CREATE TABLE [dbo].[Configuracion] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]                  NVARCHAR (50) NULL,
    [Logo]                    NVARCHAR (50) NULL,
    [Alta]                    DATETIME      CONSTRAINT [DF_Configuracion_Alta] DEFAULT (getdate()) NULL,
    [TituloIntermedioPestaña] NVARCHAR (50) NULL,
    [ClaseLogo]               NVARCHAR (50) NULL,
    [ClaseNavegacion]         NVARCHAR (50) NULL,
    CONSTRAINT [FK_Configuracion_Clasificacion] FOREIGN KEY ([Id]) REFERENCES [dbo].[Clasificacion] ([Id])
);



