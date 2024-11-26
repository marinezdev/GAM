CREATE TABLE [dbo].[Empresas] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (50)  NULL,
    [Telefono]        NVARCHAR (50)  NULL,
    [Correo]          NVARCHAR (150) NULL,
    [PaginaWeb]       NVARCHAR (150) NULL,
    [Direccion]       NVARCHAR (250) NULL,
    [Ciudad]          NVARCHAR (150) NULL,
    [Estado]          INT            NULL,
    [Prospecto]       BIT            NULL,
    [Cliente]         BIT            NULL,
    [Competidor]      BIT            NULL,
    [Sector]          INT            NULL,
    [Alta]            DATETIME       CONSTRAINT [DF_Empresas_Alta] DEFAULT (getdate()) NULL,
    [IdUsuario]       INT            NULL,
    [RFC]             NVARCHAR (50)  NULL,
    [IdConfiguracion] INT            NULL,
    [InternaExterna]  INT            CONSTRAINT [DF_Empresas_InternaExterna] DEFAULT ((2)) NULL,
    [IdUDN]           INT            NULL,
    [CP]              NVARCHAR (5)   NULL,
    [Pais]            INT            NULL,
    [Activo]          BIT            CONSTRAINT [DF_Empresas_Activo] DEFAULT ((1)) NULL,
    [Extension]       NVARCHAR (50)  NULL,
    [Tipo]            INT            CONSTRAINT [DF_Empresas_Tipo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED ([Id] ASC)
);





