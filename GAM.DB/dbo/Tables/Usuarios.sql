CREATE TABLE [dbo].[Usuarios] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (250) NULL,
    [ApellidoPaterno] NVARCHAR (150) NULL,
    [ApellidoMaterno] NVARCHAR (150) NULL,
    [Correo]          NVARCHAR (150) NULL,
    [Clave]           NVARCHAR (50)  NULL,
    [Contraseña]      NVARCHAR (150) NULL,
    [Activo]          BIT            NULL,
    [Conectado]       BIT            NULL,
    [Alta]            DATETIME       CONSTRAINT [DF_Usuarios_Alta] DEFAULT (getdate()) NULL,
    [Recordarme]      BIT            NULL,
    [Telefono]        NCHAR (10)     NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);



