-- =============================================
-- Author:		Jose Luis Villarreal
-- Create date: 24/06/2020
-- Description:	Guarda una oportunidad en la tabla correspondiente, controla qué campos guardar y cuales no
-- Ejemplo de uso: Oportunidades_Agregar 'subestacion electrica 012', 200.00, '1900-01-01', 0, 0, 0, 0, '', '1900-01-01', 0,	0, 0, 0, '1900-01-01',0, '', 2,	'', '', 0, 0, 0
-- =============================================
CREATE PROCEDURE [dbo].[Oportunidades_Agregar]
	@nombre				nvarchar(50),	--Obligatorio
	@importe			decimal,		--Opcional
	@cierre				datetime,		--Opcional
	@asignado			int,			--Opcional
	@probabilidad		int,			--Opcional
	@etapa				int,			--Opcional
	@avance				int,			--Opcional
	@notas				nvarchar,		--Opcional
	@fecha				datetime,		--Auto
	@idusuario			int,			--Obligatorio
	@idclasificacion	int,			--Opcional
	@idsubclasificacion	int,			--Opcional
	@periodoatencion	int,			--Opcional
	@aviso				datetime,		--Opcional
	@estado				int,			--Auto
	@comentariosfinales	nvarchar,		--Opcional
	@idconfiguracion	int,			--Obligatorio
	@contraparte		nvarchar,		--Opcional
	@caracteristicas	nvarchar,		--Opcional
	@idudn				int,			--Opcional
	@importeotro		decimal,		--Opcional
	@idtipomoneda		int				--Opcional

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @consulta NVARCHAR(3000);
	
	SET @consulta = N'INSERT INTO oportunidades ';
	SET @consulta += N'(nombre';
	IF (@importe >= 1)
		SET @consulta += N',importe';
	IF (@cierre > '1900-01-01')
		SET @consulta += N',cierre';
	IF (@asignado >= 1)
		SET @consulta += N',asignado';
	IF (@probabilidad >= 1)
		SET @consulta += N',probabilidad';
	IF (@etapa >= 1)
		SET @consulta += N',etapa';
	IF (@avance >= 1)
		SET @consulta += N',avance';
	IF (@notas <> '')
		SET @consulta += N',notas';
	IF (@fecha > '1900-01-01')
		SET @consulta += N',fecha';
	IF (@idusuario >= 1)
		SET @consulta += N',idusuario';
	IF (@idclasificacion >= 1)
		SET @consulta += N',idclasificacion';
	IF (@idsubclasificacion >= 1)
		SET @consulta += N',idsubclasificacion';
	IF (@periodoatencion >= 1)
		SET @consulta += N',periodoatencion';
	IF (@aviso > '1900-01-01')
		SET @consulta += N',aviso';
	IF (@estado >= 1)
		SET @consulta += N',estado';
	IF (@comentariosfinales <> '')
		SET @consulta += N',comentariosfinales';
	IF (@idconfiguracion >= 1)
		SET @consulta += N',idconfiguracion';
	IF (@contraparte <> '')
		SET @consulta += N',contraparte';
	IF (@caracteristicas <> '')
		SET @consulta += N',caracteristicas';
	IF (@idudn >= 1)
		SET @consulta += N',idudn';
	IF (@importeotro >= 1)
		SET @consulta += N',importeotro';
	IF (@idtipomoneda >= 1)
		SET @consulta += N',idtipomoneda';

	SET @consulta += N') VALUES (';
	SET @consulta += N'@nombre';
	IF (@importe >= 1)
		SET @consulta += N',@importe';
	IF (@cierre > '1900-01-01')
		SET @consulta += N',@cierre';
	IF (@asignado >= 1)
		SET @consulta += N',@asignado';
	IF (@probabilidad >= 1)
		SET @consulta += N',@probabilidad';
	IF (@etapa >= 1)
		SET @consulta += N',@etapa';
	IF (@avance >= 1)
		SET @consulta += N',@avance';
	IF (@notas <> '')
		SET @consulta += N',@notas';
	IF (@fecha > '1900-01-01')
		SET @consulta += N',@fecha';
	IF (@idusuario >= 1)
		SET @consulta += N',@idusuario';
	IF (@idclasificacion >= 1)
		SET @consulta += N',@idclasificacion';
	IF (@idsubclasificacion >= 1)
		SET @consulta += N',@idsubclasificacion';
	IF (@periodoatencion >= 1)
		SET @consulta += N',@periodoatencion';
	IF (@aviso > '1900-01-01')
		SET @consulta += N',@aviso';
	IF (@estado >= 1)
		SET @consulta += N',@estado';
	IF (@comentariosfinales <> '')
		SET @consulta += N',@comentariosfinales';
	IF (@idconfiguracion >= 1)
		SET @consulta += N',@idconfiguracion';
	IF (@contraparte <> '')
		SET @consulta += N',@contraparte';
	IF (@caracteristicas <> '')
		SET @consulta += N',@caracteristicas';
	IF (@idudn >= 1)
		SET @consulta += N',@idudn';
	IF (@importeotro >= 1)
		SET @consulta += N',@importeotro';
	IF (@idtipomoneda >= 1)
		SET @consulta += N',@idtipomoneda';

	SET @consulta += N'); SELECT @@IDENTITY';
	
	PRINT @consulta;
	EXECUTE sp_executesql @consulta,
		N'@nombre nvarchar(50), @importe decimal, @cierre DateTime, @asignado int, @probabilidad int, @etapa int, @avance int, @notas nvarchar,	@fecha datetime, 
		@idusuario int,	@idclasificacion int, @idsubclasificacion int, @periodoatencion	int, @aviso	datetime, @estado int, @comentariosfinales nvarchar, @idconfiguracion int,
		@contraparte nvarchar, @caracteristicas	nvarchar, @idudn int, @importeotro decimal, @idtipomoneda int',
        @nombre				= @nombre,
        @importe			= @importe,
        @cierre				= @cierre,
		@asignado			= @asignado,
		@probabilidad		= @probabilidad,		
		@etapa				= @etapa,		
		@avance				= @avance,		
		@notas				= @notas,			
		@fecha				= @fecha,			
		@idusuario			= @idusuario,
		@idclasificacion	= @idclasificacion,	
		@idsubclasificacion = @idsubclasificacion,
		@periodoatencion	= @periodoatencion,
		@aviso				= @aviso,	
		@estado				= @estado,
		@comentariosfinales	= @comentariosfinales,
		@idconfiguracion	= @idconfiguracion,
		@contraparte		= @contraparte,	
		@caracteristicas	= @caracteristicas,
		@idudn				= @idudn,		
		@importeotro		= @importeotro,		
		@idtipomoneda		= @idtipomoneda;
	
END
