using GAM.Models.Models;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class RolesRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Roles> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id,nombre,observaciones,activo FROM roles");
            List<Roles> resultado = new List<Roles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Roles item = new Roles();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.Observaciones = reader["Observaciones"].ToString();
                item.Activo = bool.Parse(reader["Activo"].ToString());
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected int Agregar(string Nombre, string Observaciones, string Activo)
        {
            b.ExecuteCommandQuery("INSERT INTO roles (nombre,activo) " +
            "VALUES(@nombre,@activo)");
            b.AddParameter("@nombre", Nombre, SqlDbType.NVarChar);
            b.AddParameter("@activo", Activo == "on" ? true : false, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }
    }
}