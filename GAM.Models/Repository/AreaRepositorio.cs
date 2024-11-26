using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class AreaRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Area> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id, nombre FROM area");
            List<Area> resultado = new List<Area>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Area item = new Area();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected int Agregar(string nombre)
        {
            string consulta = "INSERT INTO area (nombre) VALUES(@nombre)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", nombre, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }
    }
}
