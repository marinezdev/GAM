using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class OportunidadesRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected int Eliminar(int id)
        {
            b.ExecuteCommandQuery("update Oportunidades  set Activo = 0 where Id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
        protected List<Modelos> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT opo.Id, opo.Nombre, ISNULL(emp.Nombre, 'No Asignada') AS Empresa," +
            "opo.Estado," +
            "opo.Fecha " +
            "FROM oportunidades opo " +
            "INNER JOIN oecu ON oecu.IdOportunidad=opo.id " +
            "LEFt JOIN empresas emp ON oecu.IdEmpresa=emp.id");

            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Oportunidades.Estado = int.Parse(reader["Estado"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["Fecha"].ToString());

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Obtiene los últimos 5 registros agregados
        /// </summary>
        /// <returns></returns>
        protected List<Modelos> SeleccionarTop5(string IdConfiguracion, string IdRol)
        {
            string consulta = "SELECT TOP 5 opo.Id, opo.Nombre, emp.Nombre AS Empresa " +
            "FROM oportunidades opo " +
            "INNER JOIN OECU ON oecu.IdOportunidad=opo.id " +
            "INNER JOIN Empresas emp ON emp.Id = oecu.IdEmpresa " +
            "INNER JOIN UsuariosRoles ur ON ur.IdUsuario=oecu.IdUsuario " +
            "WHERE opo.Etapa=1 " +
            "AND opo.idconfiguracion=@idconfiguracion ";
            if (!string.IsNullOrEmpty(IdRol) && IdRol=="3")
                consulta += "AND ur.IdRol = @idrol ORDER BY opo.Id DESC";
            else
                consulta += "ORDER BY opo.Id DESC";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", IdConfiguracion, SqlDbType.Int);
            if (!string.IsNullOrEmpty(IdRol) && IdRol == "3")
                b.AddParameter("@idrol", IdRol, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Empresas.Nombre = reader["Empresa"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<OportunidadesBuscar> Buscar(string Nombre, string Empresa, string Inicio, string Fin, string Clasificacion, string SubClasificacion)
        {
            string consulta = "SELECT opo.Id AS IdOportunidad, opo.Nombre, opo.Importe, opo.Cierre, opo.Asignado, opo.Probabilidad, opo.Etapa, opo.Avance, opo.Notas, opo.IdUsuario, opo.Contraparte, " +
            "emp.nombre + iif (len(emp.sucursal) > 0, ' (' + emp.sucursal + ')', '') AS empresanombre, " +
            "con.Nombre + ' ' + con.ApellidoPaterno + ' ' + con.ApellidoMaterno AS ContactoNombre " +
            "FROM oportunidades opo " +
            "INNER JOIN OportunidadesEmpresasContactosUsuarios OPOECU ON opo.Id = OPOECU.IdOportunidad " +
            "INNER JOIN Empresas emp ON emp.Id = OPOECU.IdEmpresa " +
            "INNER JOIN Contactos con ON con.Id = OPOECU.IdContacto " +
            "INNER JOIN Usuarios usu ON usu.Id = OPOECU.IdUsuario " +
            "WHERE 1 = 1 ";

            if (Nombre != "")
                consulta += "AND opo.Nombre LIKE @nombre ";
            if (Empresa != "")
                consulta += "OR emp.Nombre LIKE @nombre ";
            if (Clasificacion != "")
                consulta += "AND opo.IdClasificacion = @clasificacion ";
            if (SubClasificacion != "")
                consulta += "AND opo.IdSubClasificacion=@subclasificacion";

            b.ExecuteCommandQuery(consulta);

            if (Nombre != "" || Empresa != "")
                b.AddParameter("@nombre", "%" + Nombre + "%", SqlDbType.NVarChar);
            if (Clasificacion != "")
                b.AddParameter("@clasificacion", Clasificacion, SqlDbType.Int);
            if (SubClasificacion != "")
                b.AddParameter("@subclasificacion", SubClasificacion, SqlDbType.Int);

            List<OportunidadesBuscar> resultado = new List<OportunidadesBuscar>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                OportunidadesBuscar item = new OportunidadesBuscar();

                item.Oportunidades.Id = int.Parse(reader["IdOportunidad"].ToString());
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Oportunidades.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                item.Empresas.Nombre = reader["EmpresaNombre"].ToString();
                
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected OportunidadesECU SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT opo.id, opo.Nombre, opo.Importe, opo.ImporteOtro, opo.idtipomoneda, opo.Caracteristicas,  opo.Cierre, opo.asignado, opo.probabilidad, opo.Etapa, opo.palabrasclave, " +
            "opo.avance, opo.notas, opo.Contraparte, opo.PeriodoAtencion," +
            "(SELECT TOP 1 edoopo.Estado FROM estadooportunidad WHERE idoportunidad=@id) AS Estado, " +
            "opo.IdUsuario, opo.comentariosfinales, opo.RepetirProximoAño, opo.FechaProximoVencimiento, " +
            "oecu.idempresa, emp.nombre AS empresanombre, usu.nombre AS usuarionombre " +
            "FROM oportunidades opo " +
            "LEFT JOIN OportunidadesEmpresasContactosUsuarios oecu ON opo.Id = oecu.IdOportunidad " +
            "INNER JOIN estadooportunidad edoopo ON edoopo.idoportunidad=opo.id " +
            "INNER JOIN empresas emp ON emp.id = oecu.idempresa " +
            "INNER JOIN usuarios usu ON usu.id=opo.idusuario " +
            "WHERE opo.id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            OportunidadesECU resultado = new OportunidadesECU();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Oportunidades.Id                  = int.Parse(reader["Id"].ToString());
                resultado.Oportunidades.Nombre              = reader["Nombre"].ToString();
                resultado.Oportunidades.Caracteristicas     = reader["Caracteristicas"].ToString();
                resultado.Oportunidades.Importe             = reader["Importe"].ToString() == "" ? 0 : decimal.Parse(reader["Importe"].ToString());
                resultado.Oportunidades.ImporteOtro         = reader["ImporteOtro"].ToString() == "" ? 0 : decimal.Parse(reader["ImporteOtro"].ToString());
                resultado.Oportunidades.IdTipoMoneda        = reader["IdTipoMoneda"].ToString() == "" ? 0 : int.Parse(reader["IdTipoMoneda"].ToString());
                resultado.Oportunidades.Cierre              = reader["Cierre"].ToString() == "" ? DateTime.Now : DateTime.Parse(reader["Cierre"].ToString());
                resultado.Oportunidades.Asignado            = reader["Asignado"].ToString() == "" ? 0 : int.Parse(reader["Asignado"].ToString());
                resultado.Oportunidades.Probabilidad        = reader["Probabilidad"].ToString() == "" ? 0 : int.Parse(reader["Probabilidad"].ToString());
                resultado.Oportunidades.Etapa               = reader["Etapa"].ToString() == "" ? 0 : int.Parse(reader["Etapa"].ToString());
                resultado.Oportunidades.Avance              = reader["Avance"].ToString() == "" ? 0 : int.Parse(reader["Avance"].ToString());
                resultado.Oportunidades.Notas               = reader["Notas"].ToString();
                resultado.Oportunidades.PeriodoAtencion     = reader["PeriodoAtencion"].ToString() == "" ? 0 : int.Parse(reader["PeriodoAtencion"].ToString());
                resultado.Oportunidades.PeriodoAtencionNombre = Utilerias.Funciones.PeriodoAtencionNombre(resultado.Oportunidades.PeriodoAtencion.ToString());
                resultado.Oportunidades.Estado              = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
                resultado.Oportunidades.IdUsuario           = reader["IdUsuario"].ToString() == "" ? 0 : int.Parse(reader["IdUsuario"].ToString());
                resultado.Oportunidades.ComentariosFinales  = reader["ComentariosFinales"].ToString();
                resultado.Oportunidades.Contraparte         = reader["Contraparte"].ToString();
                resultado.Oportunidades.RepetirProximoAño   = int.Parse(reader["RepetirProximoAño"].ToString());
                resultado.Oportunidades.FechaProximoVencimiento = reader["fechaproximovencimiento"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fechaproximovencimiento"].ToString());
                resultado.Oportunidades.PalabrasClave       = reader["palabrasclave"].ToString();
                resultado.OECU.IdEmpresa                    = reader["IdEmpresa"].ToString() == "" ? 0 : int.Parse(reader["IdEmpresa"].ToString());
                resultado.Empresas.Nombre                   = reader["empresanombre"].ToString();
                resultado.Usuarios.Nombre                   = reader["usuarionombre"].ToString();
                //resultado.OECU.IdContacto                   = reader["IdContacto"].ToString() == "" ? 0 : int.Parse(reader["IdContacto"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //PUNTO INVESTIGAR
        protected List<Modelos> SeleccionarOportunidadesPorIdResponsable(string id)
        {
            string consulta = "SELECT usu.id,opo.Id AS IdOportunidad,opo.Nombre,opo.cierre,bic.Id AS IdBitacora " +
            ",CASE " +
            "WHEN edoopo.Estado = 1 AND DATEDIFF(DAY, opo.cierre, getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN edoopo.Estado = 1 AND(DATEDIFF(DAY, opo.cierre, getdate()) IN(-59, -58, -57, -56, -55, -54, -53, -52, -51, -50, -49, -48, -47, -46, -45, -44, -43, -42, -41, -40, -39, -38, -37, -36, -35, -34, -33, -32, -31)) THEN 'EnProceso2' " +
            "WHEN edoopo.Estado = 1 AND(DATEDIFF(DAY, opo.cierre, getdate()) IN(-30, -29, -28, -27, -26, -25, -24, -23, -22, -21, -20, -19, -18, -17, -16, -15, -14, -13, -12, -11, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1)) THEN 'EnProceso3' " +
            "WHEN edoopo.Estado = 1 AND DATEDIFF(DAY, opo.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN edoopo.Estado = 3 THEN 'CerradoPerdido' " +
            "WHEN edoopo.Estado = 4 THEN 'CerradoGanado' " +
            "WHEN edoopo.Estado = 5 THEN 'Terminado' " +
            "WHEN edoopo.Estado = 6 THEN 'Cancelado' " +
            "WHEN edoopo.Estado = 7 THEN 'Suspendido' " +
            "WHEN edoopo.Estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual " +
            "FROM usuarios usu " +
            "INNER JOIN OportunidadesResponsables opor ON opor.IdAsignado = usu.id " +
            "INNER JOIN Oportunidades opo ON opo.id = opor.IdOportunidad " +
            "LEFT JOIN Bitacora bic ON( " +
            "    bic.idresponsable = usu.Id " +
            "    AND " +
            "    opo.id = bic.IdOportunidad " +
            ") " +
            "INNER JOIN estadooportunidad edoopo ON edoopo.idoportunidad=opo.id " +
            " WHERE usu.Id=@id"; /* AND Activo =1*/
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();
                item.Usuarios.Id                    = int.Parse(reader["Id"].ToString());
                item.Oportunidades.Id               = int.Parse(reader["IdOportunidad"].ToString());
                item.Oportunidades.Nombre           = reader["Nombre"].ToString();
                item.Oportunidades.Cierre           = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Cierre"].ToString());                
                item.Bitacora.Id                    = reader["IdBitacora"].ToString() == "" ? 0 : int.Parse(reader["IdBitacora"].ToString());
                item.Oportunidades.Contraparte      = reader["estadoactual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SeleccionarOportunidadesPorIdResponsableEstado1(string id)
        {
            b.ExecuteCommandQuery("SELECT COUNT(1) " +
            "FROM contactos con " +
            "INNER JOIN usuarios usu ON usu.id = con.idusuarioresponsable " +
            "INNER JOIN OportunidadesResponsables opor ON opor.IdAsignado = con.Id " +
            "INNER JOIN oportunidades opo ON opo.id = opor.IdOportunidad " +
            "LEFT JOIN bitacora bic ON bic.IdResponsable=usu.id " +
            "WHERE con.IdUsuarioResponsable=@id " +
            "AND bic.idresponsable=@id " +
            "AND bic.id=null");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarNombreTemaPorIdoportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT nombre FROM oportunidades WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarNombreEmpresaPorIdOportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT emp.nombre " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "INNER JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "WHERE opor.id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarVencimientoTemaPorIdoportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT cierre FROM oportunidades WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected List<Modelos> SeleccionarFechasOportunidad(string id)
        { 
            b.ExecuteCommandQuery("SELECT opor.fecha, opor.cierre, opor.aviso, esc.Fecha AS Escalacion  " +
            "FROM Oportunidades opor " +
            "LEFT JOIN escalacion esc ON esc.IdOportunidad = opor.Id " +
            "WHERE opor.id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();
                item.Oportunidades.Fecha    = DateTime.Parse(reader["Fecha"].ToString());
                item.Oportunidades.Cierre   = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["Cierre"].ToString());
                item.Oportunidades.Aviso    = reader["Aviso"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["Aviso"].ToString());
                item.Escalacion.Fecha       = reader["Escalacion"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["Escalacion"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Oportunidades> SeleccionarContactoEnOportunidades(string idcontacto)
        {
            string consulta = "SELECT opor.id, opor.nombre " +
            "FROM OportunidadesContactos oc " +
            "INNER JOIN oportunidades opor ON opor.id = oc.IdOportunidad " +
            "WHERE oc.IdContacto = @idcontacto";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcontacto", idcontacto, SqlDbType.Int);
            List<Oportunidades> resultado = new List<Oportunidades>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Oportunidades item = new Oportunidades();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

        protected List<Oportunidades> SeleccionarEmpresasEnOportunidades(string idempresa)
        {
            string consulta = "SELECT opor.id, opor.nombre, opor.cierre " +
            "FROM oecu " +
            "INNER JOIN oportunidades opor ON opor.id = oecu.IdOportunidad " +
            "WHERE oecu.IdEmpresa = @idempresa AND opor.activo =1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            List<Oportunidades> resultado = new List<Oportunidades>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Oportunidades item = new Oportunidades();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.Cierre = reader["cierre"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["cierre"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

        protected Modelos Seleccionar1()
        {
            Modelos resultado = new Modelos();
            resultado.OECU.IdContacto = 1;
            resultado.OECU.IdEmpresa = 1;
            resultado.Roles.Nombre = "Juan";
            return resultado;
        }

        protected List<Modelos> Seleccionar2()
        {
            List<Modelos> resultado = new List<Modelos>();
            for (int i = 0; i < 10; i++)
            {
                Modelos item = new Modelos();
                item.Contactos.Id = 1;
                item.Oportunidades.Nombre = "Oportunidad";
                resultado.Add(item);
                i += 1;
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene los procesos que están en proceso o terminados para saber su estado actual respecto a las asignaciones a los responsables
        /// </summary>
        /// <returns></returns>
        protected List<Modelos> SeleccionarTemasEnProceso(string idconfiguracion, string idrol, string idusuario)
        {
            string consulta = "SELECT opor.Id, opor.Nombre, emp.Nombre AS Empresa,emp.Id As Idempresa, opor.Importe, opor.Estado, opor.Fecha, opor.Cierre, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre,getdate()) <=-60 THEN 'EnProceso1' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre, getdate()) >=0 THEN 'EnProceso4' " +
            //"WHEN opor.Estado=2 THEN 'Cerrado' " +
            "WHEN opor.Estado=3 THEN 'CerradoPerdido' " +
            "WHEN opor.Estado=4 THEN 'CerradoGanado' " +
            "WHEN opor.Estado=5 THEN 'Terminado' " +
            "WHEN opor.Estado=6 THEN 'Cancelado' " +
            "WHEN opor.Estado=7 THEN 'Suspendido' " +
            "WHEN opor.Estado=8 THEN 'Reasignar' " +
            "END AS EstadoActual," +
            "opor.idusuario AS idusuario " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad=opor.Id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "INNER JOIN usuarios usu ON usu.Id=oecu.IdUsuario " +
            "INNER JOIN UsuariosRoles ur ON ur.IdUsuario=oecu.IdUsuario " +
            "WHERE oecu.idconfiguracion=@idconfiguracion AND opor.Activo =1";            
            if (!string.IsNullOrEmpty(idrol) && idrol == "3")
                consulta += "AND ur.IdRol=3 ";
            if (!string.IsNullOrEmpty(idrol) && idrol == "6")
                consulta += "AND ur.IdRol>=6 OR ur.IdRol=7";
            else if (!string.IsNullOrEmpty(idrol) && idrol == "7")
                consulta += "AND ur.IdRol=7 ";
            if (!string.IsNullOrEmpty(idusuario))
                consulta += "AND usu.id=@idusuario";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            if (!string.IsNullOrEmpty(idrol))
                b.AddParameter("@idrol", idrol, SqlDbType.Int);
            if (!string.IsNullOrEmpty(idusuario))
                b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List <Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id        = int.Parse(reader["Id"].ToString());
                item.Empresas.Id        = int.Parse(reader["Idempresa"].ToString());
                item.Empresas.Nombre         = reader["Empresa"].ToString();
                item.Oportunidades.Importe   = reader["Importe"].ToString() == "" ? 0 : decimal.Parse(reader["Importe"].ToString());
                item.Oportunidades.Nombre    = reader["Nombre"].ToString();
                item.Oportunidades.Estado    = int.Parse(reader["Estado"].ToString());
                item.Oportunidades.Fecha     = DateTime.Parse(reader["Fecha"].ToString());
                item.Oportunidades.Cierre    = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Cierre"].ToString());
                item.Usuarios.Id             = int.Parse(reader["idusuario"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                //item.UDN.Nombre = reader["UDN"].ToString();
                

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SeleccionarEstadoActual(string idoportunidad)
        {
            string consulta = "SELECT " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre,getdate()) <=-60 THEN 'EnProceso1' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre, getdate()) >=0 THEN 'EnProceso4' " +
            "WHEN opor.Estado=3 THEN 'CerradoPerdido' " +
            "WHEN opor.Estado=4 THEN 'CerradoGanado' " +
            "WHEN opor.Estado=5 THEN 'Terminado' " +
            "WHEN opor.Estado=6 THEN 'Cancelado' " +
            "WHEN opor.Estado=7 THEN 'Suspendido' " +
            "WHEN opor.Estado=8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad=opor.Id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "INNER JOIN usuarios usu ON usu.Id=oecu.IdUsuario " +
            "INNER JOIN UsuariosRoles ur ON ur.IdUsuario=oecu.IdUsuario " +
            "WHERE opor.id=@idoportunidad";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            return b.SelectString();
        }

        /// <summary>
        /// Obtiene todos los temas en proceso de la unidad de negocio redes sociales sin importar quien los haya creado
        /// </summary>
        /// <param name="idconfiguracion"></param>
        /// <param name="idrol"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        protected List<Modelos> SeleccionarTemasEnProcesoRedesSociales(string idconfiguracion, string idrol, string idusuario)
        {
            string consulta = "SELECT opor.Id, opor.Nombre, emp.Nombre AS Empresa, opor.Importe, opor.Estado, opor.Fecha, opor.Cierre, udn.nombre AS UDN, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre,getdate()) <=-60 THEN 'EnProceso1' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.Estado=1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY, opor.cierre, getdate()) >=0 THEN 'EnProceso4' " +
            //"WHEN opor.Estado=2 THEN 'Cerrado' " +
            "WHEN opor.Estado=3 THEN 'CerradoPerdido' " +
            "WHEN opor.Estado=4 THEN 'CerradoGanado' " +
            "WHEN opor.Estado=5 THEN 'Terminado' " +
            "WHEN opor.Estado=6 THEN 'Cancelado' " +
            "WHEN opor.Estado=7 THEN 'Suspendido' " +
            "WHEN opor.Estado=8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad=opor.Id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "INNER JOIN usuarios usu ON usu.Id=oecu.IdUsuario " +
            "INNER JOIN UsuariosRoles ur ON ur.IdUsuario=oecu.IdUsuario " +
            "LEFT JOIN udn ON udn.id=opor.idudn " +
            "WHERE oecu.idconfiguracion=@idconfiguracion " +
            "AND opor.idudn=7" +
            "AND opor.Activo =1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Oportunidades.Importe = reader["Importe"].ToString() == "" ? 0 : decimal.Parse(reader["Importe"].ToString());
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Oportunidades.Estado = int.Parse(reader["Estado"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                item.Oportunidades.Cierre = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                item.UDN.Nombre = reader["UDN"].ToString();


                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarTemasEnProcesoParaUsuarios(string idusuario)
        {
            string consulta = "SELECT opor.Id, opor.Nombre, emp.Nombre AS Empresa, opor.Estado, opor.Importe, opor.Fecha, opor.Cierre, " +
            "CASE " +
            "WHEN opor.Estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) <= -16 THEN 'EnProceso1' " +
            "WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-15, -14, -13, -12, -11, -10, -9, -8, -7)) THEN 'EnProceso2' " +
            "WHEN opor.Estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN(-6, -5, -4, -3, -2, -1)) THEN 'EnProceso3' " +
            "WHEN opor.Estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            //"WHEN opor.Estado = 2 THEN 'Cerrado' " +
            "WHEN opor.Estado=3 THEN 'CerradoPerdido' " +
            "WHEN opor.Estado=4 THEN 'CerradoGanado' " +
            "WHEN opor.Estado = 5 THEN 'Terminado' " +
            "WHEN opor.Estado = 6 THEN 'Cancelado' " +
            "WHEN opor.Estado = 7 THEN 'Suspendido' " +
            "WHEN opor.Estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual, " +
            "opor.id AS idusuario " +
            "FROM Oportunidades opor " +
            "INNER JOIN OportunidadesUsuarios ou ON ou.IdOportunidad = opor.id " +
            "INNER JOIN oecu ON oecu.IdOportunidad = opor.Id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            //"INNER JOIN estadooportunidad edoopo ON edoopo.idoportunidad=opor.id " +
            "WHERE ou.IdAsignado = @idusuario AND opor.Activo = 1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Oportunidades.Estado = int.Parse(reader["Estado"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                item.Oportunidades.Importe = reader["Importe"].ToString() == "" ? 0 : decimal.Parse(reader["Importe"].ToString());
                item.Oportunidades.Cierre = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Cierre"].ToString());
                item.Usuarios.Id = int.Parse(reader["idusuario"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Cuantos asuntos van a repetirse
        /// </summary>
        /// <param name="repetir"></param>
        /// <returns></returns>
        protected int SeleccionarAsuntosARepetirse(string repetir)
        {
            string consulta = "SELECT COUNT(opor.id) " +
            "FROM oportunidades opor " +
            "WHERE opor.IdConfiguracion = 3 " +
            "AND RepetirProximoAño = @repetir";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@repetir", repetir, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        /// <summary>
        /// Detalle de los asuntos que van a repetirse
        /// </summary>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        protected List<Modelos> SeleccionarAsuntosQueVanARepetirse(string repetir)
        {
            string consulta = "SELECT opor.id,  opor.Nombre AS Asunto,  emp.Nombre AS Empresa, opor.RepetirProximoAño " +
            "FROM oportunidades opor " +
            "INNER JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "INNER JOIN Empresas emp ON emp.id = oecu.idempresa " +
            "WHERE opor.IdConfiguracion = 3 " +
            "AND RepetirProximoAño = @repetir";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@repetir", repetir, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Oportunidades.Nombre = reader["asunto"].ToString();
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Oportunidades.RepetirProximoAño = int.Parse(reader["repetirproximoaño"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Agrega una nueva oportunidad y agrega la primera etapa del proceso
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        protected int Agregar(Oportunidades items)
        {
            //Consulta
            string consulta = "DECLARE @creado INT; " +
            "INSERT INTO oportunidades (nombre,cierre,caracteristicas,idusuario,idconfiguracion,palabrasclave,activo) " +
            "VALUES(@nombre,@cierre,@caracteristicas,@idusuario,@idconfiguracion,@palabrasclave,1); " +
            "SET @creado=@@IDENTITY; " +
            "INSERT INTO etapasoportunidad (idoportunidad, etapa) VALUES(@creado, 1); " +
            "SELECT @creado";
            b.ExecuteCommandQuery(consulta);

            //Parametros
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@cierre", items.Cierre, SqlDbType.DateTime);
            b.AddParameter("@caracteristicas", items.Caracteristicas, SqlDbType.NVarChar);            
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            b.AddParameter("@palabrasclave", items.PalabrasClave, SqlDbType.NVarChar);
            
            //Ejecución
            return b.SelectWithReturnValue();
        }

        protected int AgregarCompleto(Oportunidades items)
        {
            //Consulta
            string consulta = "DECLARE @creado INT; " +
            "INSERT INTO oportunidades (nombre,etapa,";
            if (items.IdClasificacion > 0)
                consulta += "idclasificacion,";
            if (items.IdSubClasificacion > 0)
                consulta += "idsubclasificacion,";
            if (items.Importe > 0)
                consulta += "importe,";
            if (items.PeriodoAtencion > 0)
                consulta += "periodoatencion,";
            if (items.Cierre > DateTime.Parse("1900-01-01"))
                consulta += "cierre,";
            if (items.Notas != "")
                consulta += "notas,";
            if (items.UDN > 0)
                consulta += "idudn,";
            consulta += "idconfiguracion) " +
            "VALUES(@nombre,1,";
            if (items.IdClasificacion > 0)
                consulta += "@clasificacion,";
            if (items.IdSubClasificacion > 0)
                consulta += "@subclasificacion,";
            if (items.Importe > 0)
                consulta += "@importe,";
            if (items.PeriodoAtencion > 0)
                consulta += "@atencion,";
            if (items.Cierre > DateTime.Parse("1900-01-01"))
                consulta += "@cierre,";
            if (items.Notas != "")
                consulta += "@notas,";
            if (items.UDN > 0)
                consulta += "@idudn,";
            consulta += "@idconfiguracion); " +
            "SET @creado=@@IDENTITY; " +
            "INSERT INTO etapasoportunidad (idoportunidad, etapa) VALUES(@creado, 1); " +
            "SELECT @creado";
            b.ExecuteCommandQuery(consulta);
            
            //Parametros
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            if (items.IdClasificacion > 0)
                b.AddParameter("@clasificacion", items.IdClasificacion, SqlDbType.Int);
            if (items.IdSubClasificacion > 0)
                b.AddParameter("@subclasificacion", items.IdSubClasificacion, SqlDbType.Int);
            if (items.Importe > 0)
                b.AddParameter("@importe", items.Importe, SqlDbType.Decimal);
            if (items.PeriodoAtencion > 0)
                b.AddParameter("@atencion", items.PeriodoAtencion, SqlDbType.Int);
            if (items.Cierre > DateTime.Parse("1900-01-01"))
                b.AddParameter("@cierre", items.Cierre, SqlDbType.DateTime);
            if (items.Notas != "")
                b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar);            
            if (items.UDN > 0)
                b.AddParameter("@idudn", items.UDN, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            
            //Ejecución
            return b.SelectWithReturnValue();
        }

        protected int AgregarOportunidadContactos(string IdOportunidad, string IdContacto, string IdTipoPersona)
        {
            string consulta = "IF NOT EXISTS(SELECT 1 FROM oportunidadescontactos WHERE idoportunidad=@idoportunidad AND idcontacto=@idcontacto)" +
                "BEGIN INSERT INTO oportunidadescontactos VALUES(@idoportunidad, @idcontacto, @idtipopersona) END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idoportunidad", IdOportunidad, SqlDbType.Int);
            b.AddParameter("@idcontacto", IdContacto, SqlDbType.Int);
            b.AddParameter("@idtipopersona", IdTipoPersona, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Modificar(Oportunidades items)
        {
            string consulta = "UPDATE oportunidades SET " +
            "nombre=@nombre," +
            "caracteristicas=@caracteristicas," +
            "cierre = @cierre";
            //if (items.FechaProximoVencimiento > DateTime.Parse("1900/01/01"))
            //    consulta += ",FechaProximoVencimiento=@fechaproximovencimiento ";
            consulta += ",palabrasclave=@palabrasclave " +
            "WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@caracteristicas", items.Caracteristicas, SqlDbType.NVarChar, 250);
            b.AddParameter("@cierre", items.Cierre, SqlDbType.Date);
            //if (items.FechaProximoVencimiento > DateTime.Parse("1900/01/01"))
            //    b.AddParameter("@fechaproximovencimiento", items.FechaProximoVencimiento, SqlDbType.DateTime);
            b.AddParameter("@palabrasclave", items.PalabrasClave, SqlDbType.NVarChar);
            b.AddParameter("@id", items.Id, SqlDbType.Int);                       
            return b.InsertUpdateDelete();
        }

        protected int ModificarEstadoOportunidad(string id, string estado) 
        {
            b.ExecuteCommandQuery("UPDATE oportunidades SET estado=@estado WHERE id=@id");
            b.AddParameter("@estado", estado, SqlDbType.Int);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int ModificarEstadoOportunidadMasComentarios(string id, string estado, string comentarios)
        {
            b.ExecuteCommandQuery("UPDATE oportunidades SET estado=@estado WHERE id=@id");
            b.AddParameter("@estado", estado, SqlDbType.Int);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int ModificarReasignacionOportunidad(string idresponsableanterior, string idoportunidad, string idnuevoresponsable, string responsableanterior, string responsablenuevo)
        {            
            var comentarios = "Se ha reasignado esta oportunidad de " + responsableanterior + " a " + responsablenuevo;
            string consulta = "UPDATE oportunidades SET Estado=1 WHERE id=@idoportunidad; " +
            "INSERT INTO estadooportunidad (idoportunidad, estado, comentarios) VALUES(@idoportunidad, 1, @comentarios); " +
            "UPDATE oecu SET idusuario=@idnuevoresponsable WHERE idoportunidad=@idoportunidad; " +
            "SELECT 1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            b.AddParameter("@idnuevoresponsable", idnuevoresponsable, SqlDbType.Int);
            b.AddParameter("@comentarios", comentarios, SqlDbType.NVarChar);
            return b.SelectWithReturnValue();
        }
    }
}