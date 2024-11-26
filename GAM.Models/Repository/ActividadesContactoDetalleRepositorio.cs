using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class ActividadesContactoDetalleRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<ActividadesContactoDetalleTipo> SeleccionarActividadesPorIdContacto(string idcontacto)
        {
            string consulta = "SELECT acd.id AS IdActividadesContactoDetalle, usu.nombre + ' ' + ISNULL(usu.ApellidoPaterno,'') + ' ' + ISNULL(usu.ApellidoMaterno,'') AS Usuario, acd.notas, acd.fecha, " +
            "ta.nombre AS TipoActividad " +
            "FROM actividadescontactodetalle acd " +
            "INNER JOIN actividadescontacto ac ON ac.id = acd.idactividadcontacto " +
            "INNER JOIN usuarios usu ON usu.id = ac.idusuario " +
            "INNER JOIN tipoactividad ta ON ta.id = acd.idtipoactividad " +
            "WHERE ac.idcontacto=@idcontacto";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcontacto", idcontacto, SqlDbType.Int);
            List<ActividadesContactoDetalleTipo> resultado = new List<ActividadesContactoDetalleTipo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ActividadesContactoDetalleTipo item = new ActividadesContactoDetalleTipo();
                item.ActividadesContactoDetalle.Id      = int.Parse(reader["IdActividadesContactoDetalle"].ToString());
                item.Usuarios.Nombre                    = reader["Usuario"].ToString();
                item.ActividadesContactoDetalle.Notas   = reader["Notas"].ToString();
                item.ActividadesContactoDetalle.Fecha   = DateTime.Parse(reader["Fecha"].ToString());
                item.Catalogos.Nombre                   = reader["TipoActividad"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected ActividadesContactoDetalleTipo SeleccionarPorId(string id)
        {
            string consulta = "SELECT * FROM actividadescontactodetalle WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            ActividadesContactoDetalleTipo resultado = new ActividadesContactoDetalleTipo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {                
                resultado.ActividadesContactoDetalle.Id              = int.Parse(reader["Id"].ToString());
                resultado.ActividadesContactoDetalle.IdTipoActividad = int.Parse(reader["Idtipoactividad"].ToString());
                resultado.ActividadesContactoDetalle.Notas           = reader["Notas"].ToString();
                resultado.ActividadesContactoDetalle.Fecha           = DateTime.Parse(reader["Fecha"].ToString());               
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected int Agregar(ActividadesContactoDetalle items)
        {
            string consulta = "INSERT INTO actividadescontactodetalle  (idactividadcontacto, idtipoactividad, fecha, notas) " +
            "VALUES (@idactividadcontacto, @idtipoactividad, @fecha, @notas) ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idactividadcontacto", items.IdActividadContacto, SqlDbType.Int);
            b.AddParameter("@idtipoactividad", items.IdTipoActividad, SqlDbType.Int);
            b.AddParameter("@fecha", items.Fecha, SqlDbType.DateTime);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        protected int Modificar(string idtipoactividad, string fecha, string notas, string id)
        {
            string consulta = "UPDATE actividadescontactodetalle SET idtipoactividad=@idtipoactividad, fecha=@fecha, notas=@notas WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtipoactividad", idtipoactividad, SqlDbType.Int);
            b.AddParameter("@fecha", fecha, SqlDbType.DateTime);
            b.AddParameter("@notas", notas, SqlDbType.VarChar);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();

        }
    }
}
