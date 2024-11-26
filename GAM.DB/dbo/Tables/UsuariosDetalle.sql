CREATE TABLE [dbo].[UsuariosDetalle] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [IdUsuario]      INT            NULL,
    [Telefono]       NVARCHAR (50)  NULL,
    [Celular]        NVARCHAR (50)  NULL,
    [Empresa]        INT            NULL,
    [Direccion]      NVARCHAR (50)  NULL,
    [Ciudad]         NVARCHAR (50)  NULL,
    [Notas]          NVARCHAR (MAX) NULL,
    [FisicaMoral]    INT            NULL,
    [RFC]            NVARCHAR (18)  NULL,
    [InternoExterno] INT            NULL
);





