using GAM.Models.Models;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class ActividadesRepositorio 
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Actividades> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT * FROM actividades");
            List<Actividades> resultado = new List<Actividades>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Actividades item = new Actividades()
                {
                    Id     = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected bool Agregar(Actividades items)
        {
            b.ExecuteCommandQuery("INSERT INTO actividades (nombre) VALUES(@nombre)");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            int i = b.InsertUpdateDelete();
            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}