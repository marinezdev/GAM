CREATE TABLE [dbo].[Oportunidades] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                  NVARCHAR (50)  NULL,
    [Importe]                 DECIMAL (18)   CONSTRAINT [DF_Oportunidades_Importe] DEFAULT ((0)) NULL,
    [Cierre]                  DATE           NULL,
    [Asignado]                INT            CONSTRAINT [DF_Oportunidades_Asignado] DEFAULT ((0)) NULL,
    [Probabilidad]            INT            CONSTRAINT [DF_Oportunidades_Probabilidad] DEFAULT ((0)) NULL,
    [Etapa]                   INT            CONSTRAINT [DF_Oportunidades_Etapa] DEFAULT ((0)) NULL,
    [Avance]                  INT            CONSTRAINT [DF_Oportunidades_Avance] DEFAULT ((0)) NULL,
    [Notas]                   NVARCHAR (250) NULL,
    [Fecha]                   DATETIME       CONSTRAINT [DF_Oportunidades_Fecha] DEFAULT (getdate()) NULL,
    [IdUsuario]               INT            NULL,
    [IdClasificacion]         INT            NULL,
    [IdSubClasificacion]      INT            NULL,
    [PeriodoAtencion]         INT            NULL,
    [Aviso]                   DATETIME       NULL,
    [Estado]                  INT            CONSTRAINT [DF_Oportunidades_Estado] DEFAULT ((1)) NULL,
    [ComentariosFinales]      NVARCHAR (MAX) NULL,
    [IdConfiguracion]         INT            NULL,
    [Contraparte]             NVARCHAR (250) NULL,
    [Caracteristicas]         NVARCHAR (250) NULL,
    [IdUDN]                   INT            NULL,
    [ImporteOtro]             DECIMAL (18)   CONSTRAINT [DF_Oportunidades_ImporteUSD] DEFAULT ((0)) NULL,
    [IdTipoMoneda]            INT            NULL,
    [RepetirProximoAño]       INT            CONSTRAINT [DF_Oportunidades_RepetirProximoAño] DEFAULT ((4)) NULL,
    [FechaProximoVencimiento] DATETIME       NULL,
    [PalabrasClave]           NVARCHAR (100) NULL,
    CONSTRAINT [PK_Oportunidades] PRIMARY KEY CLUSTERED ([Id] ASC)
);





