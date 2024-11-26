using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class EmpresasRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        /// <summary>
        /// Obtener todas las empresas
        /// </summary>
        /// <returns></returns>
        protected int Eliminar(int id)
        {
            b.ExecuteCommandQuery("update Empresas  set Activo = 0 where id = @id");
            
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
        protected List<Empresas> Seleccionar(string idconfiguracion, string IdRol, string idusuario)
        {

            string consulta = "SELECT Id, Nombre FROM empresas WHERE idconfiguracion=@idconfiguracion AND activo=1 ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarCompartidasPorUsuario(string idusuario)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.Tipo " +
            "FROM empresas emp " +
            "INNER JOIN CompartirEmpresas ce ON ce.IdEmpresa = emp.Id " +
            "WHERE ce.IdUsuario = @idusuario " +
            "AND emp.idconfiguracion=2 " +
            "AND emp.activo=1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarCompartidasPorUsuarioPorTipo(string idusuario, string tipo)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "INNER JOIN CompartirEmpresas ce ON ce.IdEmpresa = emp.Id " +
            "LEFT JOIN udn ON udn.id = emp.IdUDN " +
            "WHERE ce.IdUsuario = @idusuario " +
            "AND emp.tipo=@tipo " +
            "AND emp.idconfiguracion=2 " +
            "AND emp.activo=1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@tipo", tipo, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Obtiene todas las empresas que pertenezcana una configuración en particular
        /// </summary>
        /// <param name="idconfiguracion"></param>
        /// <returns></returns>
        protected List<Empresas> SeleccionarTodas(string idconfiguracion, string idusuario)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo " +
            "FROM empresas emp " +
            "INNER JOIN configuracion conf ON conf.id=emp.idconfiguracion " +
            "WHERE emp.idconfiguracion=@idconfiguracion " +
            "AND emp.Activo = 1 ";
            if (!string.IsNullOrEmpty(idusuario))
                consulta += "AND emp.IdUsuario=@idusuario ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            if (!string.IsNullOrEmpty(idusuario))
                b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString();
                item.PaginaWeb = reader["PaginaWeb"].ToString();
                item.Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
                item.CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString();
                item.RFC = reader["RFC"].ToString();
                item.Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString());
                item.InternaExterna = int.Parse(reader["InternaExterna"].ToString());
                item.Activo = bool.Parse(reader["activo"].ToString());
                item.Tipo = int.Parse(reader["tipo"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarTodas(string idconfiguracion)
        {
            string consulta = "SELECT emp.Id,emp.Nombre, emp.Sucursal," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo " +
            "FROM empresas emp " +
            "INNER JOIN configuracion conf ON conf.id=emp.idconfiguracion " +
            "WHERE emp.idconfiguracion=@idconfiguracion " +
            "AND emp.Activo = 1 " +
            "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas();
                item.Id             = int.Parse(reader["Id"].ToString());
                item.Nombre         = reader["Nombre"].ToString();
                item.Sucursal         = reader["Sucursal"].ToString();
                item.Telefono       = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString();
                item.PaginaWeb      = reader["PaginaWeb"].ToString();
                item.Estado         = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
                item.CP             = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString();
                item.RFC            = reader["RFC"].ToString();
                item.Sector         = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString());
                item.InternaExterna = reader["InternaExterna"].ToString() == "" ? 0 : int.Parse(reader["InternaExterna"].ToString());
                item.Activo         = bool.Parse(reader["activo"].ToString());
                item.Tipo           = int.Parse(reader["tipo"].ToString());

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }        

        protected List<Empresas> SeleccionarTodasPorTipo(string idconfiguracion, string idusuario, string tipo)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "INNER JOIN configuracion conf ON conf.id=emp.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=emp.IdUDN " +
            "WHERE emp.idconfiguracion=@idconfiguracion " +
            "AND emp.tipo = @tipo " +
            "AND emp.Activo = 1 ";
            if (!string.IsNullOrEmpty(idusuario))
                consulta += "AND emp.IdUsuario=@idusuario ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@tipo", tipo, SqlDbType.Int);
            if (!string.IsNullOrEmpty(idusuario))
                b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarGteProyectoComisionistas()
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "LEFT JOIN udn ON udn.id=emp.IdUDN " +
            "WHERE emp.idconfiguracion=2 " +
            "AND emp.idudn=4 " +
            "OR emp.idudn=6 " +
            "AND emp.Activo = 1 ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarGteProyectoComisionistasPorTipo(string tipo)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "LEFT JOIN udn ON udn.id=emp.IdUDN " +
            "WHERE emp.idconfiguracion=2 " +
            "AND emp.tipo=@tipo " +
            "AND emp.idudn=4 " +
            "OR emp.idudn=6 " +
            "AND emp.Activo = 1 ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@tipo", tipo, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarRedesSociales()
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "LEFT JOIN udn ON udn.id=emp.IdUDN " +
            "WHERE emp.idconfiguracion=2 " +
            "AND emp.idudn=7 " +
            "AND emp.Activo = 1 ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarRedesSocialesPorTipo(string tipo)
        {
            string consulta = "SELECT emp.Id,emp.Nombre," +
            "emp.telefono," +
            "emp.PaginaWeb,emp.Estado, emp.cp,emp.RFC,emp.Sector, emp.InternaExterna, emp.Activo, emp.tipo, udn.Nombre AS UDN " +
            "FROM empresas emp " +
            "LEFT JOIN udn ON udn.id=emp.IdUDN " +
            "WHERE emp.idconfiguracion=2 " +
            "AND emp.tipo = @tipo " +
            "AND emp.idudn=7 " +
            "AND emp.Activo = 1 ";
            consulta += "ORDER BY nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@tipo", tipo, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString() == "" ? "" : reader["Telefono"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    CP = reader["CP"].ToString() == "" ? "" : reader["CP"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Sector = reader["Sector"].ToString() == "" ? 0 : int.Parse(reader["Sector"].ToString()),
                    InternaExterna = int.Parse(reader["InternaExterna"].ToString()),
                    UDNNombre = reader["UDN"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SeleccionarRFCNoEsteOcupado(string rfc)
        {
            string consulta = "SELECT 1 FROM empresas WHERE rfc=@rfc";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@rfc", rfc, SqlDbType.NVarChar);
            return b.SelectString();
        }

        protected List<Empresas> Buscar(string nombre)
        {
            b.ExecuteCommandQuery("SELECT * FROM empresas WHERE nombre LIKE @nombre");
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.NVarChar);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    PaginaWeb = reader["PaginaWeb"].ToString(),
                    Direccion = reader["Direccion"].ToString(),
                    Ciudad = reader["Ciudad"].ToString(),
                    Estado = int.Parse(reader["Estado"].ToString()),
                    Prospecto = bool.Parse(reader["Prospecto"].ToString()),
                    Cliente = bool.Parse(reader["Cliente"].ToString()),
                    Competidor = bool.Parse(reader["Competidor"].ToString()),
                    Sector = int.Parse(reader["Sector"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected Empresas SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT * FROM empresas WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            Empresas resultado = new Empresas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id                = int.Parse(reader["Id"].ToString());
                resultado.Nombre            = reader["Nombre"].ToString();
                resultado.Sucursal            = reader["Sucursal"].ToString();
                resultado.Sucursal            = reader["Sucursal"].ToString();
                resultado.Direccion         = reader["Direccion"].ToString();
                resultado.Ciudad            = reader["Ciudad"].ToString();
                resultado.Estado            = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
                resultado.RFC               = reader["RFC"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Usuarios> SeleccionarusuariosPorEmpresaId(string id)
        {
            b.ExecuteCommandQuery("SELECT usu.Id, usu.Nombre " +
            "FROM empresasusuarios eu " +
            "INNER JOIN empresas emp ON emp.id = eu.IdEmpresa " +
            "INNER JOIN usuarios usu ON usu.id = eu.IdUsuario " +
            "WHERE emp.id =@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<Usuarios> resultado = new List<Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Usuarios item = new Usuarios()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected Empresas SeleccionarDireccionEmpresa(string id)
        {
            b.ExecuteCommandQuery("SELECT Id, Direccion, cp, ciudad, estado FROM empresas WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            Empresas resultado = new Empresas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Direccion = reader["Direccion"].ToString();
                resultado.CP = reader["CP"].ToString();
                resultado.Ciudad = reader["Ciudad"].ToString();
                resultado.Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Empresas> SeleccionarParecidas(string nombre)
        {
            string consulta = "SELECT  id, nombre FROM empresas WHERE nombre like '%' + @nombre + '%'";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", nombre, SqlDbType.NVarChar);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SeleccionarCreadorEmpresa(string idempresa)
        {
            string consulta = "SELECT idusuario FROM empresas WHERE id=@idempresa";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarNombreEmpresa(string idempresa)
        {
            string consulta = "SELECT nombre FROM empresas WHERE id=@idempresa";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarSiCamposIncompletos(string idempresa)
        {
            string consulta = "SELECT  " +
            "CASE " +
            "    WHEN telefono IS NULL OR telefono='' OR telefono='0' THEN 'Incompleto' " +
            "    WHEN rfc IS NULL OR rfc='' THEN 'Incompleto' " +
            "    WHEN direccion IS NULL OR direccion='' THEN 'Incompleto' " +
            "    WHEN idudn IS NULL OR idudn='' THEN 'Incompleto' " +
            "    WHEN paginaweb IS NULL OR paginaweb='' THEN 'Incompleto' " +
            "    ELSE 'Completo' " +
            "    END  AS Faltante " +
            "FROM empresas " +
            "WHERE id=@idempresa";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectString();
        }

        protected List<Modelos> SeleccionarEmpresasEnTemasEnProceso(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado=1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado=1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado=1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado=2 THEN 'Cerrado' " +
            "WHEN opor.estado=5 THEN 'Terminado' " +
            "WHEN opor.estado=6 THEN 'Cancelado' " +
            "WHEN opor.estado=7 THEN 'Suspendido' " +
            "WHEN opor.estado=8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE oecu.idconfiguracion=@idconfiguracion " +
            "AND emp.nombre IS NOT NULL";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = reader["Cierre"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle1(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 " +
            "AND oecu.idconfiguracion=@idconfiguracion";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle12(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle13(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle14(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 " +
            "AND oecu.idconfiguracion=@idconfiguracion " +
            "AND emp.nombre IS NOT NULL";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle2(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=2 " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());
                

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle5(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN Clasificacion cla ON cla.Id=opor.IdClasificacion " +
            "LEFT JOIN SubClasificacion scla ON scla.Id=opor.IdSubClasificacion " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=5 " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle6(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=6 " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarEmpresasTemasDetalle7(string idconfiguracion)
        {
            string consulta = "SELECT opor.Id, emp.Nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "DATEDIFF(DAY,opor.Cierre, getdate()) DiasTranscurridos, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -60 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-59,-58,-57,-56,-55,-54,-53,-52,-51, -50,-49,-48,-47,-46,-45,-44,-43,-42,-41,-40,-39,-38,-37,-36,-35,-34,-33,-32,-31)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND (DATEDIFF(DAY, opor.cierre, getdate()) IN (-30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,-13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "LEFT JOIN oecu ON oecu.IdOportunidad = opor.id " +
            "LEFT JOIN Empresas emp ON (emp.id=oecu.IdEmpresa AND oecu.IdOportunidad = opor.id) " +
            "WHERE opor.Estado=7 " +
            "AND oecu.idconfiguracion=@idconfiguracion";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
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
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Agregar un nueva empresa
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        protected int Agregar(Empresas items)
        {
            string consulta = "IF EXISTS(SELECT rfc FROM empresas WHERE idconfiguracion = @idconfiguracion AND rfc = @rfc and sucursal = @sucursal) " +
            "BEGIN " +
            "   SELECT 0 " +
            "END " +
            "ELSE BEGIN ";
            consulta += "INSERT INTO empresas (nombre, sucursal, rfc, internaexterna,idusuario,";
            if (!string.IsNullOrEmpty(items.Direccion))
                consulta += "direccion,";
            if (!string.IsNullOrEmpty(items.Ciudad))
                consulta += "ciudad,";
            if (items.Estado > 0)
                consulta += "estado,";
            consulta += "idconfiguracion) VALUES(@nombre, @sucursal, @rfc,@internaexterna,@idusuario,";
            if (!string.IsNullOrEmpty(items.Direccion))
                consulta += "@direccion,";
            if (!string.IsNullOrEmpty(items.Ciudad))
                consulta += "@ciudad,";
            if (items.Estado > 0)
                consulta += "@estado,";
            consulta += "@idconfiguracion); " +
            "SELECT @@IDENTITY; END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@sucursal", items.Sucursal.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@rfc", items.RFC.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@internaexterna", items.InternaExterna, SqlDbType.Int);
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            if (!string.IsNullOrEmpty(items.Direccion))
                b.AddParameter("@direccion", items.Direccion, SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.Ciudad))
                b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            if (items.Estado > 0)
                b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected void AgregarEmpresasAGerente(string idusuario, string idconfiguracion)
        {
            string consulta = "DECLARE @empresas INT = (SELECT MAX(id) FROM empresas)+1; " +
            "DECLARE @contador int = 0; " +
            "WHILE @contador < @empresas " +
            "    BEGIN " +
            "    IF ((SELECT id FROM empresas WHERE idconfiguracion=3 AND id=@contador) = @contador) " +
            "        BEGIN " +
            "        INSERT INTO empresasusuarios VALUES (@contador, @idusuario, 0) " +
            "        END " +
            "    SET @contador += 1 " +
            "    END";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.SelectExecuteFunctions();
        }

        protected List<Empresas> PreGuardado(Empresas items)
        {
            string consulta = "IF EXISTS(SELECT nombre FROM empresas WHERE nombre LIKE @nombre AND idconfiguracion=@idconfiguracion) " +
            "BEGIN " +
            "   SELECT id, nombre FROM empresas WHERE nombre LIKE @nombre AND idconfiguracion=@idconfiguracion " +
            "END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + items.Nombre.ToUpper() + "%", SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            List<Empresas> resultado = new List<Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Empresas item = new Empresas();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                resultado.Add(item);
            }
            return resultado;
        }

        protected int AgregarCompleto(Empresas items)
        {
            string consulta = "" +
            "IF EXISTS(SELECT nombre FROM empresas WHERE nombre LIKE @nombre AND idconfiguracion=@idconfiguracion) " +
            "BEGIN " +
            "   SELECT 0 " +
            "END " +
            "ELSE " +
            "   BEGIN " +
            "INSERT INTO empresas (nombre, rfc, internaexterna,direccion,pais,ciudad,";
            if (!string.IsNullOrEmpty(items.CP))
                consulta += "cp,";
            consulta += "idusuario,";
            if (items.Estado > 0)
                consulta += "estado,";
            if (items.Sector > 0)
                consulta += "sector,";
            if (items.Tipo > 0)
                consulta += "tipo,";
            consulta += "telefono,extension,paginaweb,idconfiguracion,idudn) " +
            "VALUES(@nombre,@rfc,@internaexterna,@direccion,@pais,@ciudad,";
            if (!string.IsNullOrEmpty(items.CP))
                consulta += "@cp,";
            consulta += "@idusuario,";
            if (items.Estado > 0)
                consulta += "@estado,";
            if (items.Sector > 0)
                consulta += "@sector,";
            if (items.Tipo > 0)
                consulta += "@tipo,";
            consulta += "@telefono,@extension,@paginaweb,@idconfiguracion,@idudn); " +
            "SELECT @@IDENTITY; " + 
            "   END";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@rfc", items.RFC.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@internaexterna", items.InternaExterna, SqlDbType.Int);
            b.AddParameter("@direccion", items.Ciudad, SqlDbType.NVarChar);
            b.AddParameter("@pais", items.Pais, SqlDbType.Int);
            b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.CP))
                b.AddParameter("@cp", items.CP, SqlDbType.NVarChar, 5);
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            if (items.Estado > 0)
                b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            if (items.Sector > 0)
                b.AddParameter("@sector", items.Sector, SqlDbType.Int);
            if (items.Tipo > 0)
                b.AddParameter("@tipo", items.Tipo, SqlDbType.Int);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@extension", items.Extension, SqlDbType.NVarChar);
            b.AddParameter("@paginaweb", items.PaginaWeb, SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            b.AddParameter("@idudn", items.IdUDN, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected int AgregarParcial(Empresas items)
        {
            string consulta = "IF EXISTS(SELECT nombre FROM empresas WHERE nombre LIKE @nombre AND idconfiguracion=@idconfiguracion) " +
            "BEGIN " +
            "   SELECT 0 " +
            "END " +
            "ELSE " +
            "   BEGIN " +
            "       INSERT INTO empresas (nombre, rfc, internaexterna, idusuario,";
            consulta += "idconfiguracion,idudn) " +
           "       VALUES(@nombre,@rfc,@internaexterna,@idusuario,";
            consulta += "@idconfiguracion,@idudn); " +
            "       SELECT @@IDENTITY; " +
            "   END";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@rfc", items.RFC.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@internaexterna", items.InternaExterna, SqlDbType.Int);
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            b.AddParameter("@idudn", items.IdUDN, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected int AgregarYContinuar(Empresas items)
        {
            b.ExecuteCommandQuery("INSERT INTO empresas (nombre, rfc,idconfiguracion) " +
            "VALUES(@nombre,@rfc,@idconfiguracion); " +
            "SELECT @@IDENTITY");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@rfc", items.RFC, SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected int Modificar(Empresas items)
        {
            string consulta = "UPDATE empresas SET nombre=@nombre," +
            "Sucursal=@sucursal," +
            "direccion=@direccion," +
            "ciudad=@ciudad," +
            "estado=@estado," +
            "rfc=@rfc " +            
            "WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@sucursal", items.Sucursal.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@direccion", items.Direccion, SqlDbType.NVarChar);
            b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            b.AddParameter("@rfc", items.RFC, SqlDbType.NVarChar);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}