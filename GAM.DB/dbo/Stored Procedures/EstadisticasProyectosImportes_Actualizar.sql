-- =============================================
-- Author:		Jose Luis Villlarreal 
-- Create date: 25-06-2020
-- Description:	Actualiza los datos de los proyectos e importes que se vayan creando, este proceso se llama desde un agendado en el servidor o un servicio de windows, 
--				también desde la misma página para actualizar al instante
--				27-07-2020
--				Se agrega nueva unidad de negocio: Redes Sociales	
-- =============================================
CREATE PROCEDURE [dbo].[EstadisticasProyectosImportes_Actualizar]
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @mes CHAR(3);
	DECLARE @consulta NVARCHAR(1000);
	
	SET LANGUAGE SPANISH
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0)

	--Actualiza proyectos
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=1) WHERE id=1;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=2) WHERE id=2;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=3) WHERE id=3;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=4) WHERE id=4;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=5) WHERE id=5;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=6) WHERE id=6;';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE proyectospormes SET ' + @mes + ' = (SELECT ISNULL(COUNT(IdUDN),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=7) WHERE id=7;';
	EXECUTE sp_executesql @consulta

	--Actualiza importes
	--Actualizar la tabla importespormes
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=1;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=2;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=3;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=4;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=5;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=6;
	UPDATE importespormes SET ene=0, feb=0, mar=0, abr=0, may=0, jun=0, jul=0, ago=0, sep=0, oct=0, nov=0, dic=0 WHERE id=7;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=1), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=1), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=1), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=1), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=1), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=1), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=1),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=1),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=1),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=1),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=1),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=1)
	WHERE id=1;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=2), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=2), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=2), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=2), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=2), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=2), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=2),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=2),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=2),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=2),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=2),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=2)
	WHERE id=2;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=3), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=3), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=3), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=3), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=3), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=3), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=3),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=3),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=3),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=3),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=3),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=3)
	WHERE id=3;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=4), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=4), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=4), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=4), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=4), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=4), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=4),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=4),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=4),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=4),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=4),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=4)
	WHERE id=4;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=5), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=5), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=5), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=5), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=5), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=5), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=5),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=5),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=5),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=5),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=5),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=5)
	WHERE id=5;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=6) 
	,feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=6) 
	,mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=6) 
	,abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=6) 
	,may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=6) 
	,jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=6) 
	,jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=6)
	,ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=6)
	,sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=6)
	,oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=6)
	,nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=6)
	,dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=6)
	WHERE id=6;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=7), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=7), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=7), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=7), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=7), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=7), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=7),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=7),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=7),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=7),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=7),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=7)
	WHERE id=7;

	UPDATE importespormes SET 
	ene=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 1 AND IdUDN=8), 
	feb=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 2 AND IdUDN=8), 
	mar=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 3 AND IdUDN=8), 
	abr=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 4 AND IdUDN=8), 
	may=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 5 AND IdUDN=8), 
	jun=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 6 AND IdUDN=8), 
	jul=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 7 AND IdUDN=8),
	ago=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 8 AND IdUDN=8),
	sep=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 9 AND IdUDN=8),
	oct=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 10 AND IdUDN=8),
	nov=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 11 AND IdUDN=8),
	dic=(SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = 12 AND IdUDN=8)
	WHERE id=8;

	/*
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=1) WHERE id=1';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=2) WHERE id=2';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=3) WHERE id=3';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=4) WHERE id=4';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=5) WHERE id=5';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=6) WHERE id=6';
	EXECUTE sp_executesql @consulta
	SET @mes = CONVERT(CHAR(3), GETDATE(), 0);
	SET @consulta = N'UPDATE importespormes SET ' + @mes + ' = (SELECT ISNULL(SUM(importe),0) FROM oportunidades WHERE MONTH(fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND IdUDN=7) WHERE id=7';
	EXECUTE sp_executesql @consulta
	*/
	SET LANGUAGE US_ENGLISH


END
