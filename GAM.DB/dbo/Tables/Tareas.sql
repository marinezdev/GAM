CREATE TABLE [dbo].[Tareas] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Asunto]     NVARCHAR (50)  NULL,
    [Inicio]     DATE           NULL,
    [Fin]        DATE           NULL,
    [HoraInicio] TIME (7)       NULL,
    [HoraFin]    TIME (7)       NULL,
    [Actividad]  INT            NULL,
    [Estado]     INT            NULL,
    [Notas]      NVARCHAR (150) NULL,
    [Avance]     INT            NULL,
    [Prioridad]  INT            NULL,
    [Alta]       DATETIME       CONSTRAINT [DF_Tareas_Alta] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tareas_Actividades] FOREIGN KEY ([Actividad]) REFERENCES [dbo].[Actividades] ([Id])
);

