using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAM.Models.Business;

namespace GAM.Models
{
    /// <summary>
    /// Clase estática de acceso rápido a catálogos
    /// </summary>
    public static class Catalogos
    {
        /// <summary>
        /// Genera una consulta para llenar una lista proporcionando el nombre de la tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static List<Models.Catalogos> Seleccionar(string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = "";

            if (tabla == "empresas")
            {
                consulta = "select  Empresas.Id as 'Id' , Empresas.Nombre + iif(len(Empresas.Sucursal) > 0, ' (' + Empresas.Sucursal + ')', '') as 'Nombre' from Empresas order by 2 asc";
            }
            else
            {
                consulta = string.Format("SELECT * FROM {0} ORDER BY nombre", tabla);
            }

            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            //reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Catalogos> ListarClas(string tabla, string Id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = "";

            if (tabla == "empresas")
            {
                consulta = "select  Empresas.Id as 'Id' , Empresas.Nombre + iif(len(Empresas.Sucursal) > 0, ' (' + Empresas.Sucursal + ')', '') as 'Nombre' from Empresas order by 2 asc";
            }
            else
            {
                consulta = string.Format("SELECT * FROM {0}  where IdEmpresa =" + Id + " AND Activo=1 ORDER BY nombre", tabla);
            }

            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            //reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Empresas> SeleccionarPorIdempresa(string id)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandQuery("SELECT * FROM empresas WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<Models.Empresas> resultado = new List<Models.Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Empresas item = new Models.Empresas
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Sucursal = reader["Sucursal"].ToString(),
                    Direccion = reader["Direccion"].ToString(),
                    Ciudad = reader["Ciudad"].ToString(),
                    Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString()),
                    RFC = reader["RFC"].ToString()
                 };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Catalogos> ListarSubClas(string tabla,string Id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = "";

            if (tabla == "empresas")
            {
                consulta = "select  Empresas.Id as 'Id' , Empresas.Nombre + iif(len(Empresas.Sucursal) > 0, ' (' + Empresas.Sucursal + ')', '') as 'Nombre' from Empresas order by 2 asc";
            }
            else
            {
                consulta = string.Format("SELECT * FROM {0}  where IdEmpresa =" + Id + " AND Activo=1 ORDER BY nombre", tabla);
            }

            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            //reader = null;
            b.CloseConnection();
            return resultado;
        }


        public static List<Models.Catalogos> ListarClasP(string tabla, string Id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = "";

            if (tabla == "empresas")
            {
                consulta = "select  Empresas.Id as 'Id' , Empresas.Nombre + iif(len(Empresas.Sucursal) > 0, ' (' + Empresas.Sucursal + ')', '') as 'Nombre' from Empresas order by 2 asc";
            }
            else
            {
                consulta = string.Format("SELECT * FROM {0}  where IdProvedor =" + Id + " AND ActivoP=1 ORDER BY nombre", tabla);
            }

            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            //reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Catalogos> Seleccionarsub(string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = "";

            if (tabla == "empresas")
            {
                consulta = "select  Empresas.Id as 'Id' , Empresas.Nombre + iif(len(Empresas.Sucursal) > 0, ' (' + Empresas.Sucursal + ')', '') as 'Nombre' from Empresas order by 2 asc";
            }
            else
            {
                consulta = string.Format("SELECT * FROM {0} WHere Activo=1 ORDER BY nombre", tabla);
            }

            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            //reader = null;
            b.CloseConnection();
            return resultado;
        }
        /// <summary>
        /// Obtiene un listado de una tabla especificando una configuración
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="idconfiguracion"></param>
        /// <returns></returns>
        public static List<Models.Catalogos> Seleccionar(string tabla, string idconfiguracion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE idconfiguracion={1} ORDER BY nombre", tabla, idconfiguracion);
            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene los datos de una tabla para llenar una lista
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="nombre">Nombre del campo nombre</param>
        /// <param name="id">Nombre del campo id</param>
        /// <returns></returns>
        public static List<Models.Catalogos> Seleccionar(string tabla, string nombre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT {1}, {2} FROM {0} ORDER BY nombre", tabla, nombre, id);
            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[1].ToString()),
                    Nombre = reader[0].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene un registro de una fila de la consulta obtenida
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="idNombre">Nombre del campo Id</param>
        /// <param name="id">Valor numérico del campo id</param>
        /// <returns>Propiedad con los valores obtenidos</returns>
        public static Models.Catalogos SeleccionarPorId(string tabla, string idNombre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1}=@id", tabla, idNombre);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            Models.Catalogos resultado = new Models.Catalogos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader[0].ToString());
                resultado.Nombre = reader[1].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Catalogos> SeleccionarSubConsulta(string tabla, string campopadre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1} = {2} ORDER BY nombre", tabla, campopadre, id);
            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        public static List<Models.Catalogos> SeleccionarSubConsultaP(string tabla, string campopadre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1} = {2} AND ActivoP =1 ORDER BY nombre", tabla, campopadre, id);
            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        public static List<Models.Catalogos> SeleccionarSubConsulta2(string tabla, string campopadre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1} = {2} AND Activo =1 ORDER BY nombre", tabla, campopadre, id);
            b.ExecuteCommandQuery(consulta);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
        public static string SeleccionarNombrePorId(string id, string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT nombre FROM {0} WHERE id=@id", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        /// <summary>
        /// Válida si un nombre es de una empresa
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static bool SeleccionarConfirmarNombreExiste(string nombre)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT nombre FROM {0} WHERE nombre LIKE @nombre","empresas");
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.NVarChar);
            if (b.SelectString().Contains(nombre.ToUpper()))
                return true;
            else
                return false;
        }

        ///// <summary>
        ///// Guarda dos valores dos columnas sin especificación de identidad
        ///// </summary>
        ///// <param name="tabla">Nombre de la tabla</param>
        ///// <param name="columna1">Nombre de la columna 1</param>
        ///// <param name="columna2">Nombre de la columna 2</param>
        //public static void Guardar(string tabla, string valor1, string valor2)
        //{
        //    AccesoDatos b = new AccesoDatos();

        //    string consulta = string.Format("INSERT INTO {0} VALUES(@valor1, @valor2)", tabla);
        //    b.ExecuteCommandQuery(consulta);
        //    b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
        //    b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
        //    b.InsertUpdateDelete();
        //}

        /// <summary>
        /// Guarda un valor una columna con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="valor1">Valor para el campo 1</param>
        public static int Guardar(string tabla,string valor1,string Id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} VALUES(@valor1,@Id,1,0,0)", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@Id", Id, SqlDbType.NVarChar);
          
            return b.InsertUpdateDelete();
        }
        public static int GuardarP(string tabla,string valor1,string Id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} VALUES(@valor1,NULL,0,@Id,1)", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@Id", Id, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        /// <summary>
        /// Guarda dos valores dos columnas con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        /// <param name="valor1">Valor para el campo 1</param>
        /// <param name="valor2">Valor para el campo 2</param>
        public static void Guardar(string tabla, string columna1, string columna2, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} ({1}, {2}) VALUES(@valor1, @valor2)", tabla, columna1, columna2);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Guarda tres valores tres columnas con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        /// <param name="columna3">Nombre de la columna 3</param>
        /// <param name="valor1">Valor para el campo 1</param>
        /// <param name="valor2">Valor para el campo 2</param>
        /// <param name="valor3">Valor para el campo 3</param>
        public static void Guardar(string tabla, string columna1, string columna2, string columna3, string valor1, string valor2, string valor3)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} ({1}, {2}, {3}) VALUES(@valor1, @valor2, @valor3)", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        public static void ModificarNombre(string tabla, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET Nombre=@valor2 WHERE id=@valor1", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con dos valores, uno para un valor, otro para un id
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="columnaid"></param>
        /// <param name="valorcolumnaid"></param>
        /// <param name="columnanombre"></param>
        public static void Modificar(string tabla, string columna1, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET Nombre=@valor2 WHERE {1}=@valor1", tabla, columna1);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para dos campos, uno para Id
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre del campo Id</param>
        /// <param name="valor1">Valor del campo Id</param>
        /// <param name="columna2">Nombre de la columna2</param>
        /// <param name="valor2">Valor de la columma2</param>
        /// <param name="columna3">Nombre de la columna3</param>
        /// <param name="valor3">Valor de la columna 3</param>
        public static void Modificar(string tabla, string columna1, string valor1, string columna2, string valor2, string columna3, string valor3)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para campos, uno para Id
        /// </summary>
        /// <param name="prms">Todos los parámetros (cuidar el orden): nombre de la tabla, nombre del campo id, valor del campo id, nombre columna 2, valor columna 2
        /// nombre columna 3, valor columna 3</param>
        public static void Modificar(params string[] prms)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", prms[0], prms[1], prms[3], prms[5]);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", prms[2], SqlDbType.NVarChar);
            b.AddParameter("@valor2", prms[4], SqlDbType.NVarChar);
            b.AddParameter("@valor3", prms[6], SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }


        //Procesos dinámicos para crear los documentos *************************************************
        public static List<Models.DocumentosEmpresas> SeleccionarClasificacionesDocumentos(string idclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT Id, Nombre, idempresa, notas, consecutivo, fecha, palabrasclave, clasificacion, subclasificacion " +
            "FROM DocumentosEmpresas " +
            "WHERE clasificacion=@idclasificacion " +
            "AND SubClasificacion IS NULL AND Activo =1");


            
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Models.DocumentosEmpresas> resultado = new List<Models.DocumentosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.DocumentosEmpresas item = new Models.DocumentosEmpresas
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    IdEmpresa = int.Parse(reader["idempresa"].ToString()),
                    Notas = reader["notas"].ToString(),
                    Consecutivo = int.Parse(reader["consecutivo"].ToString()),
                    Fecha = DateTime.Parse(reader["fecha"].ToString()),
                    PalabrasClave = reader["palabrasclave"].ToString(),
                    Clasificacion = int.Parse(reader["clasificacion"].ToString()),
                    SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        //ENLISTAR DATOS SEGUN SUS CARACTERISTICAS
        public static List<Models.DocumentosEmpresas> SeleccionarClasificacionSubClasificacionDocumentos(string idclasificacion, string idsubclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandQuery("SELECT Id, Nombre, idempresa, notas, consecutivo, fecha, palabrasclave, clasificacion, subclasificacion " +
            "FROM DocumentosEmpresas WHERE clasificacion=@idclasificacion ANd subclasificacion=@idsubclasificacion AND Activo =1");
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            b.AddParameter("@idsubclasificacion", idsubclasificacion, SqlDbType.Int);
            List<Models.DocumentosEmpresas> resultado = new List<Models.DocumentosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.DocumentosEmpresas    item = new Models.DocumentosEmpresas();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdEmpresa = int.Parse(reader["idempresa"].ToString());
                item.Notas = reader["notas"].ToString();
                item.Consecutivo = int.Parse(reader["consecutivo"].ToString());
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.PalabrasClave = reader["palabrasclave"].ToString();
                item.Clasificacion = int.Parse(reader["clasificacion"].ToString());
                item.SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //**********************************************************************************************

        public static List<Models.DocumentosProveedores> SeleccionarClasificacionesDocumentos2(string idclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT Id, Nombre, idProveedor, notas, consecutivo, fecha, palabrasclave, clasificacion, subclasificacion " +
            "FROM DocumentosProveedores  " +
            "WHERE clasificacion=@idclasificacion " +
            "AND SubClasificacion IS NULL AND Activo =1");
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Models.DocumentosProveedores> resultado = new List<Models.DocumentosProveedores>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.DocumentosProveedores item = new Models.DocumentosProveedores
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    IdProveedor = int.Parse(reader["idproveedor"].ToString()),
                    Notas = reader["notas"].ToString(),
                    Consecutivo = int.Parse(reader["consecutivo"].ToString()),
                    Fecha = DateTime.Parse(reader["fecha"].ToString()),
                    PalabrasClave = reader["palabrasclave"].ToString(),
                    Clasificacion = int.Parse(reader["clasificacion"].ToString()),
                    SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        } 
        public static List<Models.DocumentosProveedores> SeleccionarClasificacionesDocumentos2P(string idclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT Id, Nombre, idProveedor, notas, consecutivo, fecha, palabrasclave, clasificacion, subclasificacion " +
            "FROM DocumentosProveedores  " +
            "WHERE IdProveedor=@idclasificacion " +
            "AND SubClasificacion IS NULL AND Activo=1");
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Models.DocumentosProveedores> resultado = new List<Models.DocumentosProveedores>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.DocumentosProveedores item = new Models.DocumentosProveedores
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    IdProveedor = int.Parse(reader["idproveedor"].ToString()),
                    Notas = reader["notas"].ToString(),
                    Consecutivo = int.Parse(reader["consecutivo"].ToString()),
                    Fecha = DateTime.Parse(reader["fecha"].ToString()),
                    PalabrasClave = reader["palabrasclave"].ToString(),
                    Clasificacion = int.Parse(reader["clasificacion"].ToString()),
                    SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.DocumentosProveedores> SeleccionarClasificacionSubClasificacionDocumentos2(string idclasificacion, string idsubclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandQuery("SELECT Id, Nombre, IdProveedor, notas, consecutivo, fecha, palabrasclave, clasificacion, subclasificacion " +
            "FROM DocumentosProveedores   WHERE clasificacion=@idclasificacion ANd subclasificacion=@idsubclasificacion AND Activo =1");
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            b.AddParameter("@idsubclasificacion", idsubclasificacion, SqlDbType.Int);
            List<Models.DocumentosProveedores> resultado = new List<Models.DocumentosProveedores>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.DocumentosProveedores item = new Models.DocumentosProveedores();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdProveedor = int.Parse(reader["idproveedor"].ToString());
                item.Notas = reader["notas"].ToString();
                item.Consecutivo = int.Parse(reader["consecutivo"].ToString());
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.PalabrasClave = reader["palabrasclave"].ToString();
                item.Clasificacion = int.Parse(reader["clasificacion"].ToString());
                item.SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //**********************************************************************************************

        public static List<Models.Archivos> SeleccionarClasificacionesDocumentos3(string idclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT Id, Nombre, IdOportunidad, fecha, notas, version, clasificacion, subclasificacion " +
            "FROM Archivos  " +
            "WHERE clasificacion=@idclasificacion " +
            "AND SubClasificacion = 0 " +
            " AND Activo =1"
            );
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            List<Models.Archivos> resultado = new List<Models.Archivos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Archivos item = new Models.Archivos
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    IdOportunidad = int.Parse(reader["idoportunidad"].ToString()),
                    Fecha = DateTime.Parse(reader["fecha"].ToString()),
                    Notas = reader["notas"].ToString(),
                    Version= int.Parse(reader["version"].ToString()),
                    Clasificacion = int.Parse(reader["clasificacion"].ToString()),
                    SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public static List<Models.Archivos> SeleccionarClasificacionSubClasificacionDocumentos3(string idclasificacion, string idsubclasificacion)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandQuery("SELECT Id, Nombre, IdOportunidad, fecha, notas, version, clasificacion, subclasificacion " +
            "FROM Archivos   WHERE clasificacion=@idclasificacion AND subclasificacion=@idsubclasificacion AND Activo = 1");
            b.AddParameter("@idclasificacion", idclasificacion, SqlDbType.Int);
            b.AddParameter("@idsubclasificacion", idsubclasificacion, SqlDbType.Int);
            List<Models.Archivos> resultado = new List<Models.Archivos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Archivos item = new Models.Archivos();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdOportunidad = int.Parse(reader["idoportunidad"].ToString());
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.Notas = reader["notas"].ToString();
                item.Version = int.Parse(reader["version"].ToString());
                item.Clasificacion = int.Parse(reader["clasificacion"].ToString());
                item.SubClasificacion = reader["subclasificacion"].ToString() == "" ? 0 : int.Parse(reader["subclasificacion"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

    }
}
