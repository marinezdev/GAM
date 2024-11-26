using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = GAM.Models.Models;

namespace GAM.Models.Repository
{
    public class DocumentosProveedores
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<m.DocumentosProveedores> Seleccionar(int idproveedor)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, idproveedor, notas, fecha " +
            "FROM documentosproveedores " +
            "WHERE idproveedor=@idproveedor AND activo = 1");
            b.AddParameter("@idproveedor", idproveedor, SqlDbType.Int);
            List<m.DocumentosProveedores> resultado = new List<m.DocumentosProveedores>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.DocumentosProveedores item = new m.DocumentosProveedores();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdProveedor = int.Parse(reader["idproveedor"].ToString());
                item.Notas = reader["notas"].ToString();
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected m.DocumentosProveedores SeleccionarPorId(int id)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idproveedor, notas, palabrasclave, fecha FROM documentosproveedores WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.DocumentosProveedores resultado = new m.DocumentosProveedores();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.IdProveedor = int.Parse(reader["idproveedor"].ToString());
                resultado.Notas = reader["notas"].ToString();
                resultado.PalabrasClave = reader["palabrasclave"].ToString();
                resultado.Fecha = DateTime.Parse(reader["fecha"].ToString());


            }
            b.CloseConnection();
            return resultado;
        }

        /// Agrega un consecutivo por vez primera
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivo(int idproveedor)
        {
            b.ExecuteCommandQuery("SELECT ISNULL(consecutivo, 1) AS consecutivo FROM documentosproveedores WHERE idproveedor=@idproveedor");
            b.AddParameter("@idproveedor", idproveedor, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        /// <summary>
        /// Incrementa el valor de un consecutivo existente
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivoIncrementa(int idproveedor)
        {
            b.ExecuteCommandQuery("SELECT MAX(consecutivo) + 1 AS consecutivo FROM documentosproveedores WHERE idproveedor=@idproveedor");
            b.AddParameter("@idproveedor", idproveedor, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        protected string SeleccionarPorNombre(int id)
        {
            b.ExecuteCommandQuery("SELECT nombre FROM documentosproveedores WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected int Agregar(m.DocumentosProveedores items)
        {
            string consulta = "INSERT INTO documentosproveedores (nombre, idproveedor, consecutivo, notas, palabrasclave,clasificacion,Activo, subclasificacion) VALUES(@nombre, @idproveedor,@consecutivo, @notas, @palabrasclave,@clasificacion,1, @subclasificacion) SELECT @@IDENTITY";
          

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@idproveedor", items.IdProveedor, SqlDbType.Int);
            b.AddParameter("@consecutivo", items.Consecutivo, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar, 500);
            b.AddParameter("@palabrasclave", items.PalabrasClave, SqlDbType.NVarChar, 50);
            b.AddParameter("@subclasificacion", items.SubClasificacion, SqlDbType.Int);
            b.AddParameter("@clasificacion", items.Clasificacion, SqlDbType.Int);

           
            return b.SelectWithReturnValue();
        }

        protected int Modificar(m.DocumentosProveedores items)
        {
            b.ExecuteCommandQuery("UPDATE documentosproveedores SET " +
            "nombre=@nombre, " +
            "idempresa=@idempresa, " +
            "notas=@notas " +
            "WHERE id=@id");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@idproveedor", items.IdProveedor, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar, 500);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int ModificarNotas(string Notas, string PalabrasClave, string Id)
        {
            b.ExecuteCommandQuery("UPDATE documentosproveedores set notas=@notas, palabrasclave=@palabrasclave WHERE id=@id");
            b.AddParameter("@notas", Notas, SqlDbType.NVarChar);
            b.AddParameter("@palabrasclave", PalabrasClave, SqlDbType.NVarChar);
            b.AddParameter("@id", Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Eliminar(int id)
        {
            b.ExecuteCommandQuery("update documentosProveedores set Activo = 0 where id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
