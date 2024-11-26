-- =============================================
-- Author:		José Luis Villarreal Ruiz
-- Create date: 21/10/20
-- Description:	Agregar empresa
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_Agregar]
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(50), 
	@rfc NVARCHAR(50), 
	@internaexterna INT,
	@direccion NVARCHAR(250),
	@pais INT,
	@ciudad NVARCHAR(150),
	@cp NVARCHAR(5),
	@idusuario INT,
	@estado INT,
	@sector INT,
	@tipo INT,
	@telefono NVARCHAR(50),
	@extension NVARCHAR(50),
	@paginaweb NVARCHAR(150),
	@idconfiguracion INT,
	@idudn INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT nombre FROM empresas WHERE nombre LIKE '%' + @nombre + '%' AND idconfiguracion=@idconfiguracion) 
		BEGIN 
			SELECT nombre FROM empresas WHERE nombre LIKE '%' + @nombre + '%' AND idconfiguracion=@idconfiguracion
			SELECT 'Se encontraron coincidencias parecidas, verifíque'
		END 
    ELSE 
		BEGIN 
			IF EXISTS(SELECT nombre FROM empresas WHERE nombre LIKE @nombre AND idconfiguracion=@idconfiguracion) 
				BEGIN 
				   SELECT 0 
				END 
            ELSE 
               BEGIN
					DECLARE @consulta NVARCHAR(3000); 
					SET @consulta = N'INSERT INTO empresas (nombre,rfc,internaexterna,direccion,pais,ciudad,';
					IF (@cp<>'')
						SET @consulta += N'cp,';
					SET @consulta += N'idusuario,';
					IF (@estado > 0)
						SET @consulta += N'estado,';
					IF (@sector > 0)
						SET @consulta += N'sector,';
					IF (@tipo > 0)
						SET @consulta += N'tipo,';
					SET @consulta += N'telefono,extension,paginaweb,idconfiguracion,idudn) ' + 
					'VALUES(@nombre,@rfc,@internaexterna,@direccion,@pais,@ciudad,';
					IF (@cp>0)
						SET @consulta += N'@cp,';
					SET @consulta += N'@idusuario,';
					IF (@estado > 0)
						SET @consulta += N'@estado,';
					IF (@sector > 0)
						SET @consulta += N'@sector,';
					IF (@tipo > 0)
						SET @consulta += N'@tipo,';
					SET @consulta += N'@telefono,@extension,@paginaweb,@idconfiguracion,@idudn);'; 
					SET @consulta += 'SELECT @@IDENTITY;';  
					EXECUTE sp_executesql @consulta,
					N'@nombre NVARCHAR(50), @rfc NVARCHAR(50), @internaexterna INT, @direccion NVARCHAR(250), @pais INT, @ciudad NVARCHAR(150),
					@cp NVARCHAR(5), @idusuario INT, @estado INT, @sector INT, @tipo INT, @telefono NVARCHAR(50), @extension NVARCHAR(50), @paginaweb NVARCHAR(150),
					@idconfiguracion INT, @idudn INT',
					@nombre             = @nombre, 
					@rfc  				= @rfc,  
					@internaexterna 	= @internaexterna, 
					@direccion			= @direccion,
					@pais 				= @pais, 
					@ciudad 			= @ciudad, 
					@cp 				= @cp, 
					@idusuario			= @idusuario,
					@estado 			= @estado, 
					@sector 			= @sector, 
					@tipo 				= @tipo, 
					@telefono 			= @telefono, 
					@extension 			= @extension, 
					@paginaweb 			= @paginaweb, 
					@idconfiguracion 	= @idconfiguracion, 
					@idudn				= @idudn;
				END
		END
END