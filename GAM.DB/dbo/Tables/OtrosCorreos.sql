CREATE TABLE [dbo].[OtrosCorreos] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Correo]    NVARCHAR (250) NULL,
    [Fecha]     DATETIME       CONSTRAINT [DF_OtrosCorreo_Fecha] DEFAULT (getdate()) NULL,
    [IdUsuario] INT            NULL
);

