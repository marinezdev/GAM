
using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class UDNRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<UDN> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre FROM udn");
            List<UDN> resultado = new List<UDN>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDN item = new UDN();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected UDN SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT Id,Nombre FROM udn WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            UDN resultado = new UDN();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        #region Estadísticas

        //Proyectos
        protected List<UDNEstadisticas> SeleccionarProyectosPorUDN()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=1 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";
            
            b.ExecuteCommandQuery(consulta);            
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosAcumuladosAlMesPorUDN()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) IN (1,2,3,4,5,6,7,8,9,10,11,12) " +
            "AND opor.estado=1 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosPorUDNCerrados()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=2 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosAcumuladosAlMesPorUDNCerrados()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) IN (1,2,3,4,5,6,7,8,9,10,11,12) " +
            "AND opor.estado=2 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /* Proyectos e importes por mes acumulado y por mes en curso obtenidos por estado ************************/
        protected List<UDNEstadisticas> SeleccionarProyectosAcumuladosAlMesPorUDNPorEstado(string estado)
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) IN (1,2,3,4,5,6,7,8,9,10,11,12) " +
            "AND opor.estado=@estado " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        
        protected List<UDNEstadisticas> SeleccionarProyectosPorUDNEnElMesPorEstado(string estado)
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) = MONTH(GETDATE()) " +
            "AND opor.estado=@estado " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id"; 
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Selecciona los proyectos en el mes sólo para el estado 3 ó 4
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        protected List<UDNEstadisticas> SeleccionarProyectosEnElMesPorUDNPorEstado34(string estado)
        {
            string consulta1 = "SELECT ISNULL(COUNT(opor.id), 0) AS proyectos, udn.nombre AS UDN " +
            "FROM udn " +
            "LEFT JOIN oportunidades opor ON opor.idudn = udn.id AND opor.estado = @estado " +
            "LEFT JOIN estadooportunidad eo ON eo.idoportunidad = opor.id OR MONTH(eo.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND eo.estado = @estado " +
            "GROUP BY udn.nombre, udn.id";

            string consulta = "SELECT " + 	 
	        "    ( " +
		    "        SELECT COUNT(Oportunidades.Id) " +
		    "        FROM Oportunidades " +
		    "        INNER JOIN estadooportunidad ON Oportunidades.id = EstadoOportunidad.IdOportunidad " +
		    "        WHERE Oportunidades.IdUDN = UDN.Id " +
			"            AND EstadoOportunidad.Estado = @estado " +
			"            AND MONTH(EstadoOportunidad.Fecha) = MONTH(GETDATE()) " +
	        "    ) AS Proyectos, " +
	        "    UDN.Nombre AS UDN " +
            "FROM UDN";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarImportesPorUDNAlMesPorEstado(string estado)
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) " +
            "AND opor.estado=@estado " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarImportesPorUDNEnElMesPorEstado(string estado)
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=@estado " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Selecciona los importes en el mes sólo para el estado 3 ó 4
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        protected List<UDNEstadisticas> SeleccionarImportesPorUDNEnElMesPorEstado34(string estado)
        {
            string consulta1 = "SELECT ISNULL(SUM(opor.importe), 0) AS proyectos, udn.nombre AS UDN " +
            "FROM udn " +
            "LEFT JOIN oportunidades opor ON opor.idudn = udn.id AND opor.estado = @estado " +
            "LEFT JOIN estadooportunidad eo ON eo.idoportunidad = opor.id OR MONTH(eo.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND eo.estado = @estado " +
            "GROUP BY udn.nombre, udn.id";

            string consulta = "SELECT " +
            "    ( " +
            "        SELECT ISNULL(SUM(oportunidades.importe), 0) AS Proyectos " +
            "        FROM Oportunidades " +
            "        INNER JOIN estadooportunidad ON Oportunidades.id = EstadoOportunidad.IdOportunidad " +
            "        WHERE Oportunidades.IdUDN = UDN.Id " +
            "            AND EstadoOportunidad.Estado = @estado " +
            "            AND MONTH(EstadoOportunidad.Fecha) = MONTH(GETDATE()) " +
            "    ) AS Proyectos, " +
            "    UDN.Nombre AS UDN " +
            "FROM UDN";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /*********************************************************************************************************/

        /* Proyectos e importes por mes acumulado y por mes en curso obtenidos por estado para gráficos **********/

        protected List<Modelos> SeleccionarProyectosImportesAcumuladoPorEstado(string estado)
        {
            string consulta = "SELECT udn.nombre AS udn, emp.nombre AS empresa, opor.nombre AS oportunidad, opor.importe AS monto, " +            
            "opor.fecha AS creado, opor.cierre, " +
            "CASE " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) <= -16) THEN 'EnProceso1' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-15, -14, -13, -12, -11, -10, -9, -8, -7)) THEN 'EnProceso2' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-6, -5, -4, -3, -2, -1)) THEN 'EnProceso3' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) >= 0) THEN 'EnProceso4' " +
            "   WHEN opor.Estado = 3 THEN 'CerradoPerdido' " +
            "   WHEN opor.Estado = 4 THEN 'CerradoGanado' " +
            "   WHEN opor.Estado = 5 THEN 'Terminado' " +
            "   WHEN opor.Estado = 6 THEN 'Cancelado' " +
            "   WHEN opor.Estado = 7 THEN 'Suspendido' " +
            "   WHEN opor.Estado = 8 THEN 'Reasignar' " +
            "   END AS estadoactual, " +
            "opor.id " +
            "FROM oportunidades opor " +
            "INNER JOIN udn ON udn.id = opor.idudn " +
            "INNER JOIN oecu ON oecu.idoportunidad = opor.id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.idempresa " +
            "WHERE opor.estado = @estado " +
            "AND opor.idconfiguracion = 2 " +
            "AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) " +
            "AND opor.idudn IN(1,2,3,4,5,6,7,8)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();
                item.UDN.Nombre =  reader["udn"].ToString();
                item.Empresas.Nombre = reader["empresa"].ToString();
                item.Oportunidades.Nombre = reader["oportunidad"].ToString();
                item.Oportunidades.Importe = decimal.Parse(reader["monto"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["creado"].ToString());
                item.Oportunidades.Cierre = DateTime.Parse(reader["cierre"].ToString());
                item.Actividades.Nombre = reader["estadoactual"].ToString();
                item.Oportunidades.Id = int.Parse(reader["id"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected List<Modelos> SeleccionarProyectosImportesEnElMesPorEstado(string estado)
        {
            string consulta = "SELECT udn.nombre AS udn, emp.nombre AS empresa, opor.nombre AS oportunidad, opor.importe AS monto, " +
            "opor.fecha AS creado, opor.cierre, " +
            "CASE " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) <= -16) THEN 'EnProceso1' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-15, -14, -13, -12, -11, -10, -9, -8, -7)) THEN 'EnProceso2' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-6, -5, -4, -3, -2, -1)) THEN 'EnProceso3' " +
            "   WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) >= 0) THEN 'EnProceso4' " +
            "   WHEN opor.Estado = 3 THEN 'CerradoPerdido' " +
            "   WHEN opor.Estado = 4 THEN 'CerradoGanado' " +
            "   WHEN opor.Estado = 5 THEN 'Terminado' " +
            "   WHEN opor.Estado = 6 THEN 'Cancelado' " +
            "   WHEN opor.Estado = 7 THEN 'Suspendido' " +
            "   WHEN opor.Estado = 8 THEN 'Reasignar' " +
            "   END AS estadoactual, " +
            "opor.id " +
            "FROM oportunidades opor " +
            "INNER JOIN udn ON udn.id = opor.idudn " +
            "INNER JOIN oecu ON oecu.idoportunidad = opor.id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.idempresa " +
            "WHERE opor.estado = @estado " +
            "AND opor.idconfiguracion = 2 " +
            "AND MONTH(opor.fecha) = MONTH(GETDATE()) " +
            "AND opor.idudn IN(1,2,3,4,5,6,7,8)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@estado", estado, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();
                item.UDN.Nombre = reader["udn"].ToString();
                item.Empresas.Nombre = reader["empresa"].ToString();
                item.Oportunidades.Nombre = reader["oportunidad"].ToString();
                item.Oportunidades.Importe = decimal.Parse(reader["monto"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["creado"].ToString());
                item.Oportunidades.Cierre = DateTime.Parse(reader["cierre"].ToString());
                item.Actividades.Nombre = reader["estadoactual"].ToString();
                item.Oportunidades.Id = int.Parse(reader["id"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        /*********************************************************************************************************/

        protected List<UDNEstadisticas> SeleccionarProyectosAcumuladosCerradosPerdidosAlMesPorUDN()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) IN (1,2,3,4,5,6,7,8,9,10,11,12) " +
            "AND opor.estado=3 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosAcumuladosCerradosGanadosAlMesPorUDN()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) IN (1,2,3,4,5,6,7,8,9,10,11,12) " +
            "AND opor.estado=4 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosPorUDNCerradosPerdidosEnElMes()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=3 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarProyectosPorUDNCerradosGanadosEnElMes()
        {
            string consulta = "SELECT ISNULL(COUNT(opor.IdUDN),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=4 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Importes
        protected List<UDNEstadisticas> SeleccionarImportesPorUDN()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND opor.estado=1 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarImportesAcumuladosAlMesPorUDN()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) AND opor.estado=1 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNEstadisticas> SeleccionarImportesPorUDNCerrados()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) AND opor.estado=2 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Montos cerrados perdidos en el mes
        protected List<UDNEstadisticas> SeleccionarImportesPorUDNCerradosPerdidos()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=3 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        //Montos cerrados ganados en el mes
        protected List<UDNEstadisticas> SeleccionarImportesPorUDNCerradosGanados()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) = CONVERT(VARCHAR, MONTH(GETDATE()), 23) " +
            "AND opor.estado=4 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //Montos cerrados perdidos al mes
        protected List<UDNEstadisticas> SeleccionarImportesAcumuladosAlMesPorUDNCerradosPerdidos()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) " +
            "AND opor.estado=3 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        //Montos cerrados ganados al mes
        protected List<UDNEstadisticas> SeleccionarImportesAcumuladosAlMesPorUDNCerradosGanados()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id " +
            "AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) " +
            "AND opor.estado=4 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        //----------

        protected List<UDNEstadisticas> SeleccionarImportesAcumuladosAlMesPorUDNCerrados()
        {
            string consulta = "SELECT ISNULL(SUM(opor.Importe),0) AS Proyectos, udn.Nombre AS udn " +
            "FROM udn " +
            "LEFT join oportunidades opor on opor.IdUDN = udn.Id AND MONTH(opor.fecha) IN(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12) " +
            "AND opor.estado=2 " +
            "GROUP BY udn.nombre, udn.id " +
            "ORDER BY udn.id";

            b.ExecuteCommandQuery(consulta);
            List<UDNEstadisticas> resultado = new List<UDNEstadisticas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNEstadisticas item = new UDNEstadisticas();
                item.Proyectos = int.Parse(reader["Proyectos"].ToString());
                item.UDN = reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNXMes> SeleccionarProyectosPorMes()
        {
            b.ExecuteCommandQuery("SELECT * FROM ProyectosPorMes");
            List<UDNXMes> resultado = new List<UDNXMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNXMes item = new UDNXMes();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Ene = decimal.Parse(reader["Ene"].ToString());
                item.Feb = decimal.Parse(reader["Feb"].ToString());
                item.Mar = decimal.Parse(reader["Mar"].ToString());
                item.Abr = decimal.Parse(reader["Abr"].ToString());
                item.May = decimal.Parse(reader["May"].ToString());
                item.Jun = decimal.Parse(reader["Jun"].ToString());
                item.Jul = decimal.Parse(reader["Jul"].ToString());
                item.Ago = decimal.Parse(reader["Ago"].ToString());
                item.Sep = decimal.Parse(reader["Sep"].ToString());
                item.Oct = decimal.Parse(reader["Oct"].ToString());
                item.Nov = decimal.Parse(reader["Nov"].ToString());
                item.Dic = decimal.Parse(reader["Dic"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<UDNXMes> SeleccionarImportesPorMes()
        {
            b.ExecuteCommandQuery("SELECT * FROM ImportesPorMes");
            List<UDNXMes> resultado = new List<UDNXMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UDNXMes item = new UDNXMes();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Ene = decimal.Parse(reader["Ene"].ToString());
                item.Feb = decimal.Parse(reader["Feb"].ToString());
                item.Mar = decimal.Parse(reader["Mar"].ToString());
                item.Abr = decimal.Parse(reader["Abr"].ToString());
                item.May = decimal.Parse(reader["May"].ToString());
                item.Jun = decimal.Parse(reader["Jun"].ToString());
                item.Jul = decimal.Parse(reader["Jul"].ToString());
                item.Ago = decimal.Parse(reader["Ago"].ToString());
                item.Sep = decimal.Parse(reader["Sep"].ToString());
                item.Oct = decimal.Parse(reader["Oct"].ToString());
                item.Nov = decimal.Parse(reader["Nov"].ToString());
                item.Dic = decimal.Parse(reader["Dic"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }


        protected void ActualizarProyectosImportes()
        {
            b.ExecuteCommandSP("EstadisticasProyectosImportes_Actualizar");
            b.Select();
        }

        #endregion Estadísticas

        protected int Agregar(UDN items)
        {
            string consulta = "INSERT INTO udn (nombre) VALUES(@nombre)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        protected int Modificar(string nombre, string id)
        {
            string consulta = "UPDATE udn SET nombre=@nombre WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
