using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAM.Models.Models;

namespace GAM.Models.Repository
{
    public class DocumentosEmpresa
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<DocumentosEmpresas> Seleccionar(int idempresa)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, idempresa, notas, fecha " +
            "FROM documentosempresas " +
            "WHERE idempresa = @idempresa  AND activo = 1" +
            "order by nombre ASC");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            List<DocumentosEmpresas> resultado = new List<DocumentosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                DocumentosEmpresas item = new DocumentosEmpresas();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdEmpresa = int.Parse(reader["idempresa"].ToString());
                item.Notas = reader["notas"].ToString();
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());                
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected DocumentosEmpresas SeleccionarPorId(int id)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idempresa, notas, palabrasclave, fecha FROM documentosempresas WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            DocumentosEmpresas resultado = new DocumentosEmpresas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.IdEmpresa = int.Parse(reader["idempresa"].ToString());
                resultado.Notas = reader["notas"].ToString();
                resultado.PalabrasClave = reader["palabrasclave"].ToString();
                resultado.Fecha = DateTime.Parse(reader["fecha"].ToString());

                resultado.Clasificacion = 2;
                resultado.SubClasificacion = 1;
            }
            b.CloseConnection();
            return resultado;
        }

        /// Agrega un consecutivo por vez primera
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivo(int idempresa)
        {
            b.ExecuteCommandQuery("SELECT ISNULL(consecutivo, 1) AS consecutivo FROM documentosempresas WHERE idempresa=@idempresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        /// <summary>
        /// Incrementa el valor de un consecutivo existente
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivoIncrementa(int idempresa)
        {
            b.ExecuteCommandQuery("SELECT MAX(consecutivo) + 1 AS consecutivo FROM documentosempresas WHERE idempresa=@idempresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        protected string SeleccionarPorNombre(int id)
        {
            b.ExecuteCommandQuery("SELECT nombre FROM documentosempresas WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        //protected int Agregar(DocumentosEmpresas items)
        //{
        //    string consulta = "INSERT INTO documentosempresas (nombre, idempresa, consecutivo, notas, palabrasclave, clasificacion, subclasificacion) " +
        //    "VALUES(@nombre, @idempresa,@consecutivo, @notas, @palabrasclave, @clasificacion, @subclasificacion);";
        //    b.ExecuteCommandQuery(consulta);
        //    b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
        //    b.AddParameter("@idempresa", items.IdEmpresa, SqlDbType.Int);
        //    b.AddParameter("@consecutivo", items.Consecutivo, SqlDbType.Int);
        //    b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar, 500);
        //    b.AddParameter("@palabrasclave", items.PalabrasClave, SqlDbType.NVarChar, 50);

        //    b.AddParameter("@clasificacion", items.Clasificacion, SqlDbType.Int);
        //    b.AddParameter("@subclasificacion", items.SubClasificacion, SqlDbType.Int);
        //    return b.InsertUpdateDelete();
        //}

        protected int Agregar(DocumentosEmpresas items)
        {
            string consulta = "INSERT INTO documentosempresas (nombre, idempresa, consecutivo, notas, palabrasclave, clasificacion,Activo";
            if (items.SubClasificacion > 0)
                consulta += ",subclasificacion";
            consulta += ") " +
                "VALUES(@nombre, @idempresa,@consecutivo, @notas, @palabrasclave, @clasificacion,1";
            if (items.SubClasificacion > 0)
                consulta += ",@subclasificacion";
            consulta += ");" +
                "SELECT @@IDENTITY";

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@idempresa", items.IdEmpresa, SqlDbType.Int);
            b.AddParameter("@consecutivo", items.Consecutivo, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar, 500);
            b.AddParameter("@palabrasclave", items.PalabrasClave, SqlDbType.NVarChar, 50);

            b.AddParameter("@clasificacion", items.Clasificacion, SqlDbType.Int);

            if (items.SubClasificacion > 0)
                b.AddParameter("@subclasificacion", items.SubClasificacion, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected int Modificar(DocumentosEmpresas items)
        {
            b.ExecuteCommandQuery("UPDATE documentosempresas SET " +
            "nombre=@nombre, " +
            "idempresa=@idempresa, " +
            "notas=@notas " +
            "WHERE id=@id");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@idempresa", items.IdEmpresa, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar, 500);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int ModificarNotas(string Notas, string PalabrasClave, string Id)
        {
            b.ExecuteCommandQuery("UPDATE documentosempresas set notas=@notas, palabrasclave=@palabrasclave WHERE id=@id");
            b.AddParameter("@notas", Notas, SqlDbType.NVarChar);
            b.AddParameter("@palabrasclave", PalabrasClave, SqlDbType.NVarChar);
            b.AddParameter("@id", Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Eliminar(int id)
        {
            b.ExecuteCommandQuery("update documentosempresas set Activo = 0 where id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
