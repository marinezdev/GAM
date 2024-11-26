using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = GAM.Models.Models;

namespace GAM.Models.Repository
{
    public class Buscar
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<m.Buscar> SeleccionarBusqueda(string nombre, string empresa)
        {
            b.ExecuteCommandSP("Busqueda");
            b.AddParameter("@palabra", nombre == "" ? nombre : "%" + nombre + "%", SqlDbType.NVarChar, 50);
            b.AddParameter("@empresa", empresa == "" ? empresa : "%" + empresa + "%", SqlDbType.NVarChar, 50);
            List<m.Buscar> resultado = new List<m.Buscar>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Buscar item = new m.Buscar();
                item.Nombre = reader["asunto/empresa/proveedor"].ToString();
                item.Id = int.Parse(reader["id"].ToString());
                item.Archivo = reader["archivo"].ToString();
                item.Fecha = reader["fecha"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fecha"].ToString());
                item.EncontradoEn = reader["encontradoen"].ToString();
                item.PalabrasClave = reader["palabrasclave"].ToString();
                item.PalabraBuscada = reader["palabrabuscada"].ToString();
                item.EmpresaBuscada = reader["empresabuscada"].ToString();
                item.Creador = reader["creador"].ToString() == "" ? 0 : int.Parse(reader["creador"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
