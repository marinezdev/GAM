--Checar los ids de usuarios a partir de cuáles se puede borrar.

truncate table archivos
truncate table bitacorausuariosdetalle
truncate table documentosempresas
truncate table documentosproveedores
truncate table empresasusuarios
truncate table estadooportunidad
truncate table etapasoportunidad
truncate table fechavencimientocambios
truncate table oportunidadesusuarios
truncate table oportunidadesresponsables

/* Sólo estas tablas se limpian así */
delete from oecu --No necesita reiniciarse
delete from bitacora
delete from empresas
delete from oportunidades

--Reiniciar el índice de las tablas anteriores a 0 (menos oecu)
DBCC CHECKIDENT ('[bitacora]', RESEED, 0);
GO
DBCC CHECKIDENT ('[empresas]', RESEED, 0);
GO
DBCC CHECKIDENT ('[oportunidades]', RESEED, 0);
GO