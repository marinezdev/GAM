using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = GAM.Models.Models;
using System.Data;

namespace GAM.Models.Repository
{
    public class Busqueda
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<m.Modelos> SeleccionarBusqueda(string nombre, string empresa)
        {
            string consulta = string.Empty;
            if (nombre != "" && empresa != "") //dos palabras (una de ellas de empresa)
            {
                consulta = "SELECT opor.id, opor.nombre, ISNULL(SUBSTRING(opor.notas, 0,15) + '...', '') AS notas, opor.palabrasclave, arc.nombre as archivo, arc.fecha, usr.nombre AS usuario, emp.nombre as empresa " +
                "FROM oportunidades opor " +
                "INNER JOIN oecu ON oecu.idoportunidad = opor.id " +
                "INNER JOIN empresas emp ON emp.id = oecu.idempresa " +
                "LEFT JOIN archivos arc on arc.idoportunidad=opor.id " +
                "INNER JOIN usuarios usr on usr.id=opor.IdUsuario " +
                "WHERE 1 = 1 " +
                "AND opor.nombre LIKE @nombre " +
                "OR opor.notas LIKE @nombre " +
                "OR opor.palabrasclave LIKE @nombre " +
                "OR arc.nombre LIKE @nombre " +
                "OR usr.nombre LIKE @nombre " +
                "AND emp.nombre LIKE @empresa " +
                "AND opor.idconfiguracion=3 " +
                "AND emp.idconfiguracion=3";
            }
            else if (nombre != "" && empresa == "") //Sólo una palabra
            {
                consulta = "SELECT opor.id, opor.nombre, ISNULL(SUBSTRING(opor.notas, 0,15) + '...', '') AS notas, opor.palabrasclave, arc.nombre as archivo, arc.fecha, usr.nombre AS usuario, emp.nombre as empresa " +
                "FROM oportunidades opor " +
                "INNER JOIN oecu ON oecu.idoportunidad = opor.id " +
                "INNER JOIN empresas emp ON emp.id = oecu.idempresa " +
                "LEFT JOIN archivos arc on arc.idoportunidad=opor.id " +
                "INNER JOIN usuarios usr on usr.id=opor.IdUsuario " +
                "WHERE 1 = 1 " +
                "AND opor.nombre LIKE @nombre " +
                "OR opor.notas LIKE @nombre " +
                "OR opor.palabrasclave LIKE @nombre " +
                "OR arc.nombre LIKE @nombre " +
                "OR usr.nombre LIKE @nombre " +
                "AND opor.idconfiguracion=3 " +
                "AND emp.idconfiguracion=3";
            }
            else if (nombre == "" && empresa != "") //Una palabra (que sea de una empresa)
            {
                consulta = "SELECT opor.id, opor.nombre, ISNULL(SUBSTRING(opor.notas, 0,15) + '...', '') AS notas, opor.palabrasclave, arc.nombre as archivo, arc.fecha, usr.nombre AS usuario, emp.nombre as empresa " +
                "FROM oportunidades opor " +
                "INNER JOIN oecu ON oecu.idoportunidad = opor.id " +
                "INNER JOIN empresas emp ON emp.id = oecu.idempresa " +
                "LEFT JOIN archivos arc on arc.idoportunidad=opor.id " +
                "INNER JOIN usuarios usr on usr.id=opor.IdUsuario " +
                "WHERE 1 = 1 " +                
                "AND emp.nombre LIKE @empresa " +
                "AND opor.idconfiguracion=3 " +
                "AND emp.idconfiguracion=3";
            }
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.NVarChar, 50);
            b.AddParameter("@empresa", "%" + empresa + "%", SqlDbType.NVarChar, 50);
            List<m.Modelos> resultado = new List<m.Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Modelos item = new m.Modelos();
                item.Oportunidades.Id            = int.Parse(reader["id"].ToString());
                item.Oportunidades.Nombre        = reader["nombre"].ToString();
                item.Oportunidades.Notas         = reader["notas"].ToString();
                item.Oportunidades.PalabrasClave = reader["palabrasclave"].ToString();
                item.Archivos.Nombre             = reader["archivo"].ToString();
                item.Archivos.Fecha              = reader["fecha"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fecha"].ToString());
                item.Usuarios.Nombre             = reader["usuario"].ToString();
                item.Empresas.Nombre             = reader["empresa"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    
        protected List<m.Modelos> SeleccionarBusqueda2(string nombre, string empresa)
        {
            string consulta = string.Empty;
            if (nombre != "" && empresa != "") //Dos palabras, una de ellas empresa
            {
                consulta = "SELECT de.id, de.idempresa, de.nombre, de.fecha, emp.nombre AS empresa " +
                "FROM documentosempresas de " +
                "INNER JOIN empresas emp ON emp.id=de.idempresa " +
                "WHERE 1=1 " +
                "AND de.nombre LIKE @nombre " +
                "OR de.palabrasclave LIKE @nombre " +
                "OR de.notas LIKE @nombre " +
                "AND emp.nombre = @empresa";
            }
            else if (nombre != "" && empresa == "") //Sólo una palabra
            {
                consulta = "SELECT de.id, de.idempresa, de.nombre, de.fecha, emp.nombre AS empresa " +
                    "FROM documentosempresas de " +
                    "INNER JOIN empresas emp ON emp.id=de.idempresa " +
                    "WHERE 1=1 " +
                    "AND de.nombre LIKE @nombre " +
                    "OR de.palabrasclave LIKE @nombre " +
                    "OR de.notas LIKE @nombre ";
            }
            else if (nombre == "" && empresa != "") //sólo una palabra, que sea empresa
            {
                consulta = "SELECT de.id, de.idempresa, de.nombre, de.fecha, emp.nombre AS empresa " +
                "FROM documentosempresas de " +
                "INNER JOIN empresas emp ON emp.id=de.idempresa " +
                "WHERE 1=1 " +
                "AND emp.nombre LIKE @empresa";
            }
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.NVarChar, 50);
            b.AddParameter("@empresa", "%" + empresa + "%", SqlDbType.NVarChar, 50);
            List<m.Modelos> resultado = new List<m.Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Modelos item = new m.Modelos();
                item.DocumentosEmpresas.Id = int.Parse(reader["id"].ToString());
                item.DocumentosEmpresas.IdEmpresa = int.Parse(reader["idempresa"].ToString());
                item.DocumentosEmpresas.Nombre = reader["nombre"].ToString();
                item.DocumentosEmpresas.Fecha = DateTime.Parse(reader["fecha"].ToString());
                //item.Notas = " | " + reader["notas"].ToString();
                //item.PalabrasClave = " | " + reader["palabrasclave"].ToString();
                item.Empresas.Nombre = reader["empresa"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected List<m.Modelos> SeleccionarBusqueda3(string nombre)
        {
            string consulta = "SELECT dp.id, dp.idproveedor, dp.nombre, dp.fecha, usu.nombre AS usuario " +
            "FROM documentosproveedores dp " +
            "INNER JOIN usuarios usu ON usu.id=dp.idproveedor " +
            "WHERE dp.nombre LIKE @nombre " +
            "OR dp.notas LIKE @nombre " +
            "OR dp.palabrasclave LIKE @nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.NVarChar, 50);
            List<m.Modelos> resultado = new List<m.Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Modelos item = new m.Modelos();
                item.DocumentosProveedores.Id = int.Parse(reader["id"].ToString());
                item.DocumentosProveedores.IdProveedor = int.Parse(reader["idproveedor"].ToString());
                item.DocumentosProveedores.Nombre = reader["nombre"].ToString();
                item.DocumentosProveedores.Fecha = DateTime.Parse(reader["fecha"].ToString());
                //item.Notas = " | " + reader["notas"].ToString();
                //item.PalabrasClave = " | " + reader["palabrasclave"].ToString();
                item.Usuarios.Nombre = reader["usuario"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

    }
}
