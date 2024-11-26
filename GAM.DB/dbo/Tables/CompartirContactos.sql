CREATE TABLE [dbo].[CompartirContactos] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [IdContacto] INT NULL,
    [IdUsuario]  INT NULL,
    [Activo]     BIT CONSTRAINT [DF_CompartirContactos_Activo] DEFAULT ((1)) NULL
);

