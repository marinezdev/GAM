using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GAM.Models.Models;

namespace GAM.Models.Repository
{
    public class DocumentosASAESubClasificacionesRepository
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Subclasificacion> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idclasificacion FROM documentosasaesubclasificacion WHERE Activo = 1");
           
            List<Subclasificacion> resultado = new List<Subclasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Subclasificacion item = new Subclasificacion();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdClasificacion = int.Parse(reader["idclasificacion"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        protected List<Subclasificacion> SeleccionarP()
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idclasificacion FROM documentosasaesubclasificacion WHERE ActivoP = 1");
           
            List<Subclasificacion> resultado = new List<Subclasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Subclasificacion item = new Subclasificacion();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdClasificacion = int.Parse(reader["idclasificacion"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected Subclasificacion SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idclasificacion FROM documentosasaesubclasificacion WHERE id=@id AND Activo = 1");
            b.AddParameter("@id", id, SqlDbType.Int);
            Subclasificacion resultado = new Subclasificacion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.IdClasificacion = int.Parse(reader["IdClasificacion"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        protected List<Subclasificacion> SeleccionarSubClasificacionesPorClasificacion(string idclasificacion)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre FROM documentosasaesubclasificacion WHERE idclasificacion=@idclasificacion AND Activo = 1");
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Subclasificacion> resultado = new List<Subclasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Subclasificacion item = new Subclasificacion();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        protected List<Subclasificacion> SeleccionarSubClasificacionesPorClasificacionP(string idclasificacion)
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre FROM documentosasaesubclasificacion WHERE idclasificacion=@idclasificacion AND ActivoP = 1");
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Subclasificacion> resultado = new List<Subclasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Subclasificacion item = new Subclasificacion();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        protected int Agregar(Subclasificacion items)
        {
            string consulta = "INSERT INTO documentosasaesubclasificacion VALUES(@nombre,@idclasificacion,@Id,1,0,0)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@idclasificacion", items.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@Id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        } 
        protected int AgregarP(Subclasificacion items)
        {
            string consulta = "INSERT INTO documentosasaesubclasificacion VALUES(@nombre,@idclasificacion,NULL,0,@Id,1)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@idclasificacion", items.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@Id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Modificar(Subclasificacion items)
        {
            string consulta = "UPDATE documentosasaesubclasificacion SET nombre=@nombre, idclasificacion=@idclasificacion WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@idclasificacion", items.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int Eliminar(string id)
        {
            string consulta = "IF NOT EXISTS(SELECT subclasificacion FROM DocumentosEmpresas WHERE subclasificacion = @id AND Activo=1) UPDATE documentosasaesubclasificacion SET Activo = 0 Where Id = @id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int EliminarClasificacion(string id)
        {
            string consulta = "IF NOT EXISTS(select Clasificacion FROM DocumentosEmpresas where Clasificacion = @id AND Activo=1) BEGIN UPDATE  documentosasaeclasificacion SET Activo = 0 Where Id = @id UPDATE documentosasaesubclasificacion SET Activo = 0 Where IdClasificacion = @id END ELSE BEGIN SELECT 0 END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        } 
        protected int EliminarClasificacionP(string id)
        {
            string consulta = "IF NOT EXISTS(select Clasificacion FROM DocumentosProveedores where Clasificacion = @id AND Activo=1) BEGIN UPDATE  documentosasaeclasificacion SET ActivoP = 0 Where Id = @id UPDATE documentosasaesubclasificacion SET ActivoP = 0 Where IdClasificacion = @id END ELSE BEGIN SELECT 0 END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        protected int EliminarP(string id)
        {
            string consulta = "IF NOT EXISTS(SELECT subclasificacion FROM DocumentosProveedores WHERE subclasificacion = @id AND Activo=1) UPDATE documentosasaesubclasificacion SET ActivoP = 0 Where Id = @id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
        protected int EliminarClasificacion2(string id)
        {
            string consulta = "IF NOT EXISTS(select Clasificacion FROM Archivos where Clasificacion = @id AND Activo=1) BEGIN UPDATE  documentosasaeclasificacion SET Activo = 0 Where Id = @id UPDATE documentosasaesubclasificacion SET Activo = 0 Where IdClasificacion = @id END ELSE BEGIN SELECT 0 END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }




    }
}
