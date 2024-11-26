CREATE TABLE [dbo].[ClassSubClass] (
    [IdOportunidad]      INT            NULL,
    [Campo1]             NVARCHAR (MAX) NULL,
    [Campo2]             NVARCHAR (MAX) NULL,
    [Campo3]             NVARCHAR (MAX) NULL,
    [Campo4]             NVARCHAR (MAX) NULL,
    [IdClasificacion]    INT            NULL,
    [IdSubClasificacion] INT            NULL,
    CONSTRAINT [FK_ClassSubClass_Oportunidades] FOREIGN KEY ([IdOportunidad]) REFERENCES [dbo].[Oportunidades] ([Id])
);

