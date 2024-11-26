using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class ArchivosRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected Archivos SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, Fecha, IdOportunidad, Notas, version,clasificacion,subclasificacion FROM archivos WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            Archivos resultado = new Archivos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Notas = reader["Notas"].ToString();
                resultado.Version = int.Parse(reader["version"].ToString());
                resultado.Clasificacion = int.Parse(reader["clasificacion"].ToString());
                resultado.SubClasificacion = int.Parse(reader["subclasificacion"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected Archivos SeleccionarPorId2(string id)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, Fecha, IdOportunidad, Notas, version,clasificacion  FROM archivos WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            Archivos resultado = new Archivos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Notas = reader["Notas"].ToString();
                resultado.Version = int.Parse(reader["version"].ToString());
                resultado.Clasificacion = int.Parse(reader["clasificacion"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        protected string SeleccionarPorNombre(string id)
        {
            b.ExecuteCommandQuery("SELECT nombre FROM archivos WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        protected int CuantosArchivosTieneOportunidad(string idoportunidad)
        {
            string consulta = "SELECT count(id) FROM archivos WHERE idoportunidad=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", idoportunidad, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        protected List<Archivos> SeleccionarPorIdOportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, Fecha, IdOportunidad, Notas, version FROM archivos WHERE idoportunidad=@idopo AND activo=1");
            b.AddParameter("@idopo", id, SqlDbType.Int);
            List<Archivos> resultado = new List<Archivos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Archivos item = new Archivos()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Fecha = reader["Fecha"].ToString() == "" ? DateTime.Parse("1900-01-01") : DateTime.Parse(reader["Fecha"].ToString()),
                    IdOportunidad = int.Parse(reader["IdOportunidad"].ToString()),
                    Notas = reader["Notas"].ToString(),
                    Version = int.Parse(reader["version"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Agrega un consecutivo por vez primera
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivo(int idoportunidad)
        {
            b.ExecuteCommandQuery("SELECT ISNULL(version, 1) AS consecutivo FROM archivos WHERE idoportunidad=@idoportunidad");
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        /// <summary>
        /// Incrementa el valor de un consecutivo existente
        /// </summary>
        /// <param name="idoportunidad"></param>
        /// <returns></returns>
        protected int SeleccionarConsecutivoIncrementa(int idoportunidad)
        {
            b.ExecuteCommandQuery("SELECT MAX(version) + 1 AS consecutivo FROM archivos WHERE idoportunidad=@idoportunidad");
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        protected int Agregar(Archivos items)
        {
            string consulta = "INSERT INTO archivos(nombre, idoportunidad, version, clasificacion, Activo, subclasificacion) VALUES(@nombre, @idoportunidad, @version, @clasificacion, 1, @subclasificacion) SELECT @@IDENTITY";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@idoportunidad", items.IdOportunidad, SqlDbType.Int);
            b.AddParameter("@version", items.Version, SqlDbType.Int);
            b.AddParameter("@clasificacion", items.Clasificacion, SqlDbType.Int);
            b.AddParameter("@subclasificacion", items.SubClasificacion, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected int Modificar(string Notas, string Id, string Clasificacion, string SubClasificacion)
        {
            b.ExecuteCommandQuery("UPDATE archivos set notas=@notas,Clasificacion=@Clasificacion,SubClasificacion=@SubClasificacion WHERE id=@id");
            b.AddParameter("@notas", Notas, SqlDbType.NVarChar);
            b.AddParameter("@Clasificacion", Clasificacion, SqlDbType.Int);
            b.AddParameter("@SubClasificacion", SubClasificacion, SqlDbType.Int);
            b.AddParameter("@id", Id, SqlDbType.Int);
    
           
            return b.InsertUpdateDelete();
        }

        protected int Eliminar(string id)
        {
            b.ExecuteCommandQuery("update archivos set Activo = 0 where Id = @id");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}