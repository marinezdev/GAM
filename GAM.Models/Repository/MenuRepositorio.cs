using System;
using GAM.Models.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Models.Repository
{
    public class MenuRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<MenuMenuRoles> SeleccionarMenuPorIdRol(string idrol, string idconfiguracion)
        {
            string consulta = "SELECT mn.idjquery, mn.ruta, mn.icono, mn.nombre " +
            "FROM menuroles mr " +
            "INNER JOIN menu mn ON mn.id = mr.idmenu " +
            "WHERE mn.idconfiguracion = @idconfiguracion " +
            "AND mr.idrol = @idrol " +
            "AND mn.disponible=1 " +
            "AND mr.accesible=1";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            List<MenuMenuRoles> resultado = new List<MenuMenuRoles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                MenuMenuRoles item = new MenuMenuRoles();
                item.Menu.IdJquery = reader["idjquery"].ToString();
                item.Menu.Ruta = reader["ruta"].ToString();
                item.Menu.Icono = reader["icono"].ToString();
                item.Menu.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
