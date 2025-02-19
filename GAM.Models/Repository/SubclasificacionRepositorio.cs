﻿using GAM.Models.Models;
using System.Collections.Generic;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class SubclasificacionRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Subclasificacion> SeleccionarPorId(string Id)
        {
            b.ExecuteCommandQuery("SELECT * FROM subclasificacion WHERE idclasificacion=@id ORDER BY Nombre");
            b.AddParameter("@id", Id, System.Data.SqlDbType.Int);
            List<Subclasificacion> resultado = new List<Subclasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Subclasificacion item = new Subclasificacion()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected Subclasificacion SeleccionarPorIdEditar(string id)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idclasificacion FROM subclasificacion WHERE id=@id");
            b.AddParameter("@id", id, System.Data.SqlDbType.Int);
            Subclasificacion resultado = new Subclasificacion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.IdClasificacion = int.Parse(reader["IdClasificacion"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<UsuariosRoles> SeleccionarParaAdministracion()
        {
            b.ExecuteCommandQuery("SELECT scla.Id, scla.Nombre, cla.Nombre AS Clasificacion " +
            "FROM subclasificacion scla " +
            "INNER JOIN clasificacion cla ON cla.id=scla.IdClasificacion");
            List<UsuariosRoles> resultado = new List<UsuariosRoles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                UsuariosRoles item = new UsuariosRoles();
                item.SubClasificacion.Id = int.Parse(reader["Id"].ToString());
                item.SubClasificacion.Nombre = reader["Nombre"].ToString();
                item.Clasificacion.Nombre = reader["Clasificacion"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected int Agregar(string nombre, string idclasificacion)
        {
            b.ExecuteCommandQuery("INSERT INTO subclasificacion (nombre, idclasificacion) VALUES(@nombre, @idclasificacion)");
            b.AddParameter("@nombre", nombre, System.Data.SqlDbType.NVarChar);
            b.AddParameter("@idclasificacion", idclasificacion, System.Data.SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Modificar(string nombre, string idclasificacion, string id)
        {
            b.ExecuteCommandQuery("UPDATE subclasificacion SET nombre=@nombre, idclasificacion=@idclasificacion WHERE id=@id");
            b.AddParameter("@nombre", nombre, System.Data.SqlDbType.NVarChar);
            b.AddParameter("@idclasificacion", idclasificacion, System.Data.SqlDbType.Int);
            b.AddParameter("@id", id, System.Data.SqlDbType.Int);
            return b.InsertUpdateDelete();
        }


    }
}