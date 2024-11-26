using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class ContactosRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        //Seleccionar

        protected List<Contactos> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT Id, Nombre, ApellidoPaterno, ISNULL(ApellidoMaterno, '') AS ApellidoMaterno FROM contactos WHERE activo=1 ORDER BY nombre, apellidopaterno");
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarTodos(string idconfiguracion, string idrol, string idusuario)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños,con.TipoContacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.activo=1 ";
            if (idrol == "3")
            {
                //consulta += "AND emp.id IN (SELECT idempresa FROM EmpresasUsuarios WHERE IdUsuario=@idusuario AND activo=1) ";
                consulta += "AND con.UsuarioAlta = @idusuario ";
            }
            if (idrol == "7")
                consulta += "AND con.usuarioalta=@idusuario ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarTodosPorTipoContacto(string idconfiguracion, string idrol, string idusuario, string tipocontacto)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños,con.TipoContacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.tipocontacto=@tipocontacto  " +
            "AND con.activo=1 ";
            if (idrol == "3")
            {
                //consulta += "AND emp.id IN (SELECT idempresa FROM EmpresasUsuarios WHERE IdUsuario=@idusuario AND activo=1) ";
                consulta += "AND con.UsuarioAlta = @idusuario ";
            }
            if (idrol == "7")
                consulta += "AND con.usuarioalta=@idusuario ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@tipocontacto", tipocontacto, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarCompartidos(string idusuario)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, con.Correo, con.Telefono, con.Celular, con.TipoContacto, con.FechaCumpleaños " +
            ", emp.Nombre AS Empresa " +
            ",udn.Nombre AS UDN " +
            "FROM contactos con " +
            "INNER JOIN compartircontactos cc ON cc.idcontacto = con.id " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id = con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id = con.idudn " +
            "WHERE cc.idusuario = @idusuario";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

        protected List<ContactosEmpresas> SeleccionarCompartidosPorTipoContacto(string idusuario, string tipocontacto)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, con.Correo, con.Telefono, con.Celular, con.TipoContacto, con.FechaCumpleaños " +
            ", emp.Nombre AS Empresa " +
            ",udn.Nombre AS UDN " +
            "FROM contactos con " +
            "INNER JOIN compartircontactos cc ON cc.idcontacto = con.id " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id = con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id = con.idudn " +
            "WHERE cc.idusuario = @idusuario " +
            "AND con.tipocontacto=@tipocontacto";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@tipocontacto", tipocontacto, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

        protected List<ContactosEmpresas> SeleccionarGteProyectoComisionistas(string idconfiguracion, string idrol, string idusuario)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños, con.tipocontacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.activo=1 " +
            "AND con.idudn IN (4,6) ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarGteProyectoComisionistasPorTipoContacto(string idconfiguracion, string idrol, string idusuario, string tipocontacto)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños, con.tipocontacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.tipocontacto=@tipocontacto " +
            "AND con.activo=1 " +
            "AND con.idudn IN (4,6) ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@tipocontacto", tipocontacto, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarRedesSociales(string idconfiguracion, string idrol, string idusuario)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños, con.tipocontacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.activo=1 " +
            "AND con.idudn IN (7) ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<ContactosEmpresas> SeleccionarRedesSocialesPorTipoContacto(string idconfiguracion, string idrol, string idusuario, string tipocontacto)
        {
            string consulta = "SELECT con.Id, con.Nombre, ISNULL(con.ApellidoPaterno, '') AS ApellidoPaterno, ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, emp.Nombre AS Empresa, con.Correo, con.Telefono, con.Celular, con.FechaCumpleaños, con.tipocontacto, udn.Nombre AS UDN " +
            "FROM contactos con " +
            "LEFT JOIN ContactosEmpresas coem ON coem.IdContacto = con.Id " +
            "LEFT JOIN Empresas emp ON coem.IdEmpresa = emp.Id " +
            "INNER JOIN Configuracion conf ON conf.id=con.idconfiguracion " +
            "LEFT JOIN udn ON udn.id=con.idudn " +
            "WHERE con.idconfiguracion=@idconfiguracion " +
            "AND con.tipocontacto=@tipocontacto " +
            "AND con.activo=1 " +
            "AND con.idudn IN (7) ";
            consulta += "ORDER BY con.Nombre, con.apellidopaterno";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@tipocontacto", tipocontacto, SqlDbType.Int);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                item.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                item.Contactos.TipoContacto = int.Parse(reader["tipocontacto"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.UDN.Nombre = reader["UDN"].ToString() == "" ? "" : reader["UDN"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarContactosEnTemasEnProceso(string idconfiguracion)
        {
            string consultaanterior = "SELECT con.Nombre + ' ' + con.ApellidoPaterno + ' ' + con.ApellidoMaterno AS Contacto, opo.Nombre AS Tema " +
            "FROM contactos con " +
            "INNER JOIN OportunidadesResponsables opor ON opor.IdAsignado = con.id " +
            "INNER JOIN oportunidades opo ON opo.id = opor.IdOportunidad";

            string consulta = "SELECT opor.Id, con.Nombre, con.ApellidoPaterno, ISNULL(ApellidoMaterno, '') AS ApellidoMaterno , emp.nombre AS Empresa, opor.Nombre, opor.Estado, opor.Fecha, opor.Cierre, " +
            "CASE " +
            "WHEN opor.Estado=1 AND DATEDIFF(DAY,opor.cierre,getdate()) <= -16 THEN 'EnProceso1' " +
            "WHEN opor.estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-15,-14,-13,-12,-11,-10,-9,-8,-7)) THEN 'EnProceso2' " +
            "WHEN opor.estado = 1 AND(DATEDIFF(DAY, opor.cierre, getdate()) IN (-6,-5,-4,-3,-2,-1)) THEN 'EnProceso3' " +
            "WHEN opor.estado = 1 AND DATEDIFF(DAY, opor.cierre, getdate()) >= 0 THEN 'EnProceso4' " +
            "WHEN opor.estado = 2 THEN 'Cerrado' " +
            "WHEN opor.estado = 5 THEN 'Terminado' " +
            "WHEN opor.estado = 6 THEN 'Cancelado' " +
            "WHEN opor.estado = 7 THEN 'Suspendido' " +
            "WHEN opor.estado = 8 THEN 'Reasignar' " +
            "END AS EstadoActual  " +
            "FROM oportunidades opor " +
            "INNER JOIN OportunidadesResponsables opre ON opre.IdOportunidad=opor.id " +
            "LEFT JOIN Contactos con ON con.Id=opre.IdAsignado " +
            "INNER JOIN oecu ON oecu.IdOportunidad=opor.Id " +
            "LEFT JOIN empresas emp ON emp.id = oecu.IdEmpresa " +
            "WHERE con.idconfiguracion=@idconfiguracion";

            //b.ExecuteCommandQuery(consulta);
            //List <Modelos> resultado = new List<Modelos>();
            //var reader = b.ExecuteReader();
            //while (reader.Read())
            //{
            //    Modelos item = new Modelos();
            //    item.Contactos.Nombre = reader["Contacto"].ToString();
            //    item.Oportunidades.Nombre = reader["Tema"].ToString();
            //    resultado.Add(item);
            //}
            //reader = null;
            //b.ConnectionCloseToTransaction();
            //return resultado;

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();

                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Oportunidades.Id = int.Parse(reader["Id"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Oportunidades.Nombre = reader["Nombre"].ToString();
                item.Oportunidades.Estado = int.Parse(reader["Estado"].ToString());
                item.Oportunidades.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                item.Oportunidades.Cierre = DateTime.Parse(reader["Cierre"].ToString());

                item.Bitacora.NombreEstado = reader["EstadoActual"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

        protected string SeleccionarIdContactoDeIdUsuario(string idusuario)
        {
            b.ExecuteCommandQuery("SELECT id FROM contactos WHERE idusuarioresponsable=@idusuario");
            b.AddParameter("idusuario", idusuario, SqlDbType.Int);
            return b.SelectString();
        }

        protected List<ContactosEmpresas> Buscar(string Nombre)
        {
            b.ExecuteCommandQuery("SELECT con.Id AS IdContacto, empr.Id As IdEmpresa, con.Nombre, con.ApellidoPaterno, ISNULL(con.ApellidoMaterno, '') AS ApellidoMaterno , empr.Nombre AS Empresa, " +
            "con.Correo, con.Telefono, con.Celular " +
            "FROM ContactosEmpresas cone " +
            "INNER JOIN Empresas empr ON cone.IdEmpresa = empr.Id " +
            "LEFT JOIN Contactos con ON cone.idcontacto = con.Id " +
            "WHERE 1=1 " +
            "AND con.Nombre + ' ' + con.ApellidoPaterno + ' ' + con.ApellidoMaterno LIKE @nombre " +
            "OR empr.Nombre LIKE @nombre");
            b.AddParameter("@nombre", "%" + Nombre + "%", SqlDbType.NVarChar);
            List<ContactosEmpresas> resultado = new List<ContactosEmpresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ContactosEmpresas item = new ContactosEmpresas();

                item.Contactos.Id = int.Parse(reader["IdContacto"].ToString());
                item.Empresas.Id = int.Parse(reader["IdEmpresa"].ToString());
                item.Empresas.Nombre = reader["Empresa"].ToString();
                item.Contactos.Nombre = reader["Nombre"].ToString();
                item.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Contactos.Correo = reader["Correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();

                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        protected List<Contactos> BuscarParecidos(Contactos items)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, apellidopaterno,apellidomaterno " +
            "FROM contactos WHERE apellidopaterno LIKE '%' + @apellidopaterno + '%' AND apellidomaterno LIKE '%' + @apellidomaterno + '%'");
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@celular", items.Celular, SqlDbType.NVarChar);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string BuscarParecido(Contactos items)
        {
            b.ExecuteCommandQuery("IF EXISTS(SELECT 1 " +
            "FROM contactos WHERE nombre=@nombre AND apellidopaterno=@apellidopaterno AND apellidomaterno=@apellidomaterno) " +
            " SELECT 1 " +
            "ELSE " +
            "SELECT 0");
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            return b.SelectString();
        }

        protected ContactosEmpresas SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT cont.Id AS IdContacto,cont.Nombre,cont.ApellidoPaterno,cont.ApellidoMaterno,cont.Correo,cont.Correo,cont.Telefono,cont.Celular," +
            "cont.Direccion,cont.CP,cont.Ciudad,cont.Estado,cont.Cargo,cont.FechaCumpleaños,cont.TipoContacto,cont.Notas,cont.ContactoUsuario,cont.IdArea,cont.IdUDN,cont.Pais,cont.Activo, " +
            "empr.Id AS IdEmpresa, empr.Nombre AS EmpresaNombre " +
            "FROM contactos cont " +
            "LEFT JOIN contactosempresas coem ON cont.Id = coem.IdContacto " +
            "LEFT JOIN empresas empr ON empr.id = coem.idempresa WHERE cont.id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            ContactosEmpresas resultado = new ContactosEmpresas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Contactos.Id = int.Parse(reader["IdContacto"].ToString());
                resultado.Contactos.Nombre = reader["Nombre"].ToString();
                resultado.Empresas.Id = reader["IdEmpresa"].ToString() == "" ? 0 : int.Parse(reader["IdEmpresa"].ToString());
                resultado.Empresas.Nombre = reader["EmpresaNombre"].ToString();
                resultado.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Contactos.Correo = reader["Correo"].ToString();
                resultado.Contactos.Telefono = reader["Telefono"].ToString();
                resultado.Contactos.Celular = reader["Celular"].ToString();
                resultado.Contactos.Direccion = reader["Direccion"].ToString();
                resultado.Contactos.CP = reader["CP"].ToString();
                resultado.Contactos.Ciudad = reader["CIudad"].ToString();
                resultado.Contactos.Estado = reader["Estado"].ToString() == "" ? 0 : int.Parse(reader["Estado"].ToString());
                resultado.Contactos.Pais = reader["pais"].ToString() == "" ? 0 : int.Parse(reader["pais"].ToString());
                resultado.Contactos.Cargo = reader["Cargo"].ToString();
                resultado.Contactos.FechaCumpleaños = reader["FechaCumpleaños"].ToString();
                resultado.Contactos.TipoContacto = reader["TipoContacto"].ToString() == "" ? 0 : int.Parse(reader["TipoContacto"].ToString());
                resultado.Contactos.Notas = reader["Notas"].ToString();
                resultado.Contactos.ContactoUsuario = int.Parse(reader["ContactoUsuario"].ToString());
                resultado.Contactos.IdArea = reader["IdArea"].ToString() == "" ? 0 : int.Parse(reader["IdArea"].ToString());
                resultado.Contactos.IdUDN = reader["IdUDN"].ToString() == "" ? 0 : int.Parse(reader["IdUDN"].ToString());
                resultado.Contactos.Activo = bool.Parse(reader["activo"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Contactos> SeleccionarContactosPorEmpresa(string id)
        {
            b.ExecuteCommandQuery("SELECT con.Id, con.Nombre, con.ApellidoPaterno, ISNULL(con.ApellidoMaterno, '') AS ApellidoMaterno " +
            "FROM contactos con " +
            "INNER JOIN contactosempresas ce ON con.id = ce.IdContacto " +
            "INNER JOIN Empresas emp ON emp.Id = ce.idempresa " +
            "WHERE emp.id = @id ");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Id = int.Parse(reader["Id"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Contactos> SeleccionarContactosPorConfiguracion(string id, string idrol, string idusuario)
        {
            string consulta = "SELECT con.Id, con.Nombre,con.ApellidoPaterno,ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno " +
            "FROM contactos con " +
            "INNER JOIN configuracion conf ON conf.id = con.IdConfiguracion " +
            "WHERE conf.id=@id " +
            "AND con.activo=1 ";
            if (idrol == "7")
                consulta += "AND con.UsuarioAlta = @idusuario ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            if (idrol == "7")
                b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Id = int.Parse(reader["Id"].ToString());
                //item.IdUsuarioResponsable = string.IsNullOrEmpty(reader["IdUsuarioResponsable"].ToString()) ? 0 : int.Parse(reader["IdUsuarioResponsable"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Contactos> SeleccionarContactosPorConfiguracion(string id, string idrol, string idusuario, string idempresa)
        {
            string consulta = "SELECT con.Id, con.Nombre,con.ApellidoPaterno,ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno " +
            "FROM contactos con " +
            "INNER JOIN configuracion conf ON conf.id = con.IdConfiguracion ";
            if (id == "2")
                consulta += "INNER JOIN ContactosEmpresas ce ON ce.IdContacto=con.id ";
            consulta += "WHERE conf.id=@id " +
            "AND con.activo=1 ";
            if (idrol == "7")
                consulta += "AND con.UsuarioAlta = @idusuario ";
            if (id == "2")
                consulta += "AND ce.IdEmpresa = @idempresa ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            if (idrol == "7")
                b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            if (id == "2")
                b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Id = int.Parse(reader["Id"].ToString());
                //item.IdUsuarioResponsable = string.IsNullOrEmpty(reader["IdUsuarioResponsable"].ToString()) ? 0 : int.Parse(reader["IdUsuarioResponsable"].ToString());
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<Modelos> SeleccionarContactosAsignadosAOportunidad(string idconfiguracion, string idoportunidad)
        {
            string consulta = "SELECT con.Id, con.Nombre,con.ApellidoPaterno,ISNULL(con.ApellidoMaterno,'') AS ApellidoMaterno, tp.nombre AS NombreTipoPersona, " +
            "con.correo, con.telefono, con.celular " +
            "FROM contactos con " +
            "INNER JOIN configuracion conf ON conf.id = con.IdConfiguracion " +
            "INNER JOIN oportunidadescontactos oc ON oc.idcontacto = con.id " +
            "INNER JOIN tipopersona tp ON tp.id=oc.idtipopersona " +
            "WHERE conf.id=@idconfiguracion " +
            "AND oc.idoportunidad=@idoportunidad";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            List<Modelos> resultado = new List<Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Modelos item = new Modelos();
                item.Contactos.Id = int.Parse(reader["Id"].ToString());
                item.Contactos.Nombre = reader["Nombre"].ToString() + " " + reader["ApellidoPaterno"].ToString() + " " + reader["ApellidoMaterno"].ToString();
                item.TipoPersona.Nombre = reader["NombreTipoPersona"].ToString();
                item.Contactos.Correo = reader["correo"].ToString();
                item.Contactos.Telefono = reader["Telefono"].ToString();
                item.Contactos.Celular = reader["Celular"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SeleccionarValidarSiContactoPerteneceAEmpresa(string idcontacto)
        {
            b.ExecuteCommandQuery("SELECT idempresa FROM contactosempresas WHERE idcontacto=@id");
            b.AddParameter("@id", idcontacto, SqlDbType.Int);
            return b.SelectString();
        }

        protected string SeleccionarCreadorContacto(string idcontacto)
        {
            string consulta = "SELECT usuarioalta FROM contactos WHERE id=@idcontacto";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcontacto", idcontacto, SqlDbType.Int);
            return b.SelectString();
        }

        protected bool SeleccionarValidarCreadorContacto(string idcontacto, string idusuario)
        { 
            string consulta = "DECLARE @usuarioalta INT; " +
            "SELECT @usuarioalta = usuarioalta FROM contactos WHERE id = @contacto; " +
            "IF(@usuarioalta = @usuarioactivo) " +
            "SELECT 1 " +
            "ELSE " +
            "SELECT 2";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@contacto", idcontacto, SqlDbType.Int);
            b.AddParameter("@usuarioactivo", idusuario, SqlDbType.Int);
            if (int.Parse(b.SelectString()) == 1)
                return true;
            else
                return false;
        }

        protected string SeleccionarNombreContacto(string idcontacto)
        {
            string consulta = "SELECT nombre + ' ' + isnull(apellidopaterno,'') + ' ' + ISNULL(apellidomaterno,'') AS nombre FROM contactos WHERE id=@idcontacto";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcontacto", idcontacto, SqlDbType.Int);
            return b.SelectString();
        }

        /// <summary>
        /// Obtiene los campos que se mostrarán del contacto y la empresa en la búsqueda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected ContactosEmpresas SeleccionarPorIdDetalleContactoEmpresa(string id)
        {
            //b.ExecuteCommandQuery("SELECT cont.Id, cont.Nombre + ' ' + cont.ApellidoPaterno + ' ' + cont.ApellidoMaterno AS Contacto,cont.Correo,cont.Correo,cont.Telefono,cont.Celular,cont.Direccion,cont.Ciudad,cont.Estado,cont.Cargo,cont.FechaCumpleaños,cont.TipoContacto,cont.Notas," +
            //"empr.Id AS IdEmpresa, empr.Nombre AS Empresa, empr.Prospecto, empr.Cliente, empr.Competidor " +
            //"FROM contactos cont " +
            //"INNER JOIN contactosempresas coem ON cont.Id = coem.IdContacto " +
            //"INNER JOIN empresas empr ON empr.id = coem.idempresa " +
            //"WHERE cont.id=@id");
            //b.AddParameter("@id", id, SqlDbType.Int);
            //ContactosBuscarDetalle resultado = new ContactosBuscarDetalle();
            //var reader = b.ExecuteReader();
            //while (reader.Read())
            //{
            //    resultado.IdContacto  = int.Parse(reader["Id"].ToString());
            //    resultado.IdEmpresa   = int.Parse(reader["IdEmpresa"].ToString());
            //    resultado.Contacto    = reader["Contacto"].ToString();
            //    resultado.Cargo       = reader["Cargo"].ToString();
            //    resultado.Telefono    = reader["Telefono"].ToString();
            //    resultado.Correo      = reader["Correo"].ToString();
            //    resultado.Ciudad      = reader["Ciudad"].ToString();
            //    resultado.Notas       = reader["Notas"].ToString();
            //    resultado.Empresa     = reader["Empresa"].ToString();
            //    resultado.Prospecto   = reader["Prospecto"] == null ? false : bool.Parse(reader["Prospecto"].ToString());
            //    resultado.Cliente     = reader["Cliente"] == null ? false: bool.Parse(reader["Cliente"].ToString());
            //    resultado.Competidor  = reader["Competidor"] == null ? false : bool.Parse(reader["Competidor"].ToString());
            //}
            //reader = null;
            //b.ConnectionCloseToTransaction();
            //return resultado;

            b.ExecuteCommandQuery("SELECT cont.Id AS IdContacto, cont.Nombre, cont.ApellidoPaterno, ISNULL(cont.ApellidoMaterno, '') AS ApellidoMaterno,cont.Correo,cont.Correo,cont.Telefono,cont.Celular,cont.Direccion,cont.Ciudad,cont.Estado,cont.Cargo,cont.FechaCumpleaños,cont.TipoContacto,cont.Notas," +
            "empr.Id AS IdEmpresa, empr.Nombre AS Empresa, empr.Prospecto, empr.Cliente, empr.Competidor " +
            "FROM contactos cont " +
            "INNER JOIN contactosempresas coem ON cont.Id = coem.IdContacto " +
            "INNER JOIN empresas empr ON empr.id = coem.idempresa " +
            "WHERE cont.id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            ContactosEmpresas resultado = new ContactosEmpresas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Contactos.Id = int.Parse(reader["IdContacto"].ToString());
                resultado.Empresas.Id = int.Parse(reader["IdEmpresa"].ToString());
                resultado.Contactos.Nombre = reader["Nombre"].ToString();
                resultado.Contactos.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.Contactos.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Contactos.Cargo = reader["Cargo"].ToString();
                resultado.Contactos.Telefono = reader["Telefono"].ToString();
                resultado.Contactos.Correo = reader["Correo"].ToString();
                resultado.Contactos.Ciudad = reader["Ciudad"].ToString();
                resultado.Contactos.Notas = reader["Notas"].ToString();
                resultado.Empresas.Nombre = reader["Empresa"].ToString();
                resultado.Empresas.Prospecto = reader["Prospecto"] == null ? false : bool.Parse(reader["Prospecto"].ToString());
                resultado.Empresas.Cliente = reader["Cliente"] == null ? false : bool.Parse(reader["Cliente"].ToString());
                resultado.Empresas.Competidor = reader["Competidor"] == null ? false : bool.Parse(reader["Competidor"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //Agregar
        protected List<Contactos> PreGuardado1(Contactos items)
        {
            string consulta = "IF EXISTS(SELECT nombre, correo FROM contactos WHERE nombre LIKE @nombre OR correo LIKE @correo AND idconfiguracion=@idconfiguracion) " +
            "BEGIN SELECT nombre, correo FROM contactos WHERE nombre LIKE @nombre OR correo LIKE @correo AND idconfiguracion=@idconfiguracion; END";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + items.Nombre.ToUpper() + "%", SqlDbType.NVarChar);
            b.AddParameter("@correo", "%" + items.Correo + "%", SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Nombre = reader["Nombre"].ToString();
                item.Correo = reader["Correo"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Agregar contacto, devuelve el id asignado
        /// </summary>
        /// <param name="items">Valores de entrada</param>
        /// <returns>Id asignado</returns>
        protected int Agregar(Contactos items)
        {
            //Consulta
            string consulta = "IF EXISTS(SELECT correo FROM contactos WHERE correo LIKE '%' + @correo + '%') " +
            "   SELECT 0 " +
            "ELSE " +
            "   INSERT INTO contactos (nombre,";
            if (!string.IsNullOrEmpty(items.ApellidoPaterno))
                consulta += "apellidopaterno,";
            if (!string.IsNullOrEmpty(items.ApellidoMaterno))
                consulta += "apellidomaterno,";
            consulta += "correo,telefono,celular,";
            if (!string.IsNullOrEmpty(items.Direccion))
                consulta += "direccion,";
            if (!string.IsNullOrEmpty(items.Ciudad))
                consulta += "ciudad,";
            if (!string.IsNullOrEmpty(items.Notas))
                consulta += "notas,";
            consulta += "idconfiguracion) VALUES(@nombre,";
            if (!string.IsNullOrEmpty(items.ApellidoPaterno))
                consulta += "@apellidopaterno,";
            if (!string.IsNullOrEmpty(items.ApellidoMaterno))
                consulta += "@apellidomaterno,";
            consulta += "@correo,@telefono,@celular,";
            if (!string.IsNullOrEmpty(items.Direccion))
                consulta += "@direccion,";
            if (!string.IsNullOrEmpty(items.Ciudad))
                consulta += "@ciudad,";
            if (!string.IsNullOrEmpty(items.Notas))
                consulta += "@notas,";
            consulta += "@idconfiguracion); " +
            " SELECT @@IDENTITY";
            b.ExecuteCommandQuery(consulta);
            //Parametros
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.ApellidoPaterno))
                b.AddParameter("@apellidopaterno", items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.ApellidoMaterno))
                b.AddParameter("@apellidomaterno", items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@celular", items.Celular, SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.Direccion))
                b.AddParameter("@direccion", items.Direccion, SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.Ciudad))
                b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(items.Notas))
                b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);

            return b.SelectWithReturnValue();
        }

        protected int Agregar3(Contactos items)
        {
            string consulta = "IF EXISTS(SELECT correo FROM contactos WHERE correo LIKE '%' + @correo + '%') " +
            "   SELECT 0 " +
            "ELSE " +
            "   INSERT INTO contactos (nombre,apellidopaterno,apellidomaterno,correo,telefono,celular,direccion,ciudad,cp,estado,pais,cargo,fechacumpleaños,tipocontacto,notas,idconfiguracion,idudn,idarea,usuarioalta) " +
            "   VALUES(@nombre,@apellidopaterno,@apellidomaterno,@correo,@telefono,@celular,@direccion,@ciudad,@cp,@estado,@pais,@cargo,@cumpleaños,@notas,@tipocontacto,@idconfiguracion,@idudn,@idarea,@usuarioalta); " +
            "   SELECT @@IDENTITY";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@celular", items.Celular, SqlDbType.NVarChar);
            b.AddParameter("@direccion", items.Direccion, SqlDbType.NVarChar);
            b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            b.AddParameter("@cp", items.CP, SqlDbType.NVarChar, 5);
            b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            b.AddParameter("@pais", items.Pais, SqlDbType.Int);
            b.AddParameter("@cargo", items.Cargo, SqlDbType.NVarChar);
            b.AddParameter("@cumpleaños", items.FechaCumpleaños, SqlDbType.NVarChar);
            b.AddParameter("@tipocontacto", items.TipoContacto, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar);
            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            b.AddParameter("@idudn", items.IdUDN, SqlDbType.Int);
            b.AddParameter("@idarea", items.IdArea, SqlDbType.Int);
            b.AddParameter("@usuarioalta", items.UsuarioAlta, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        protected List<Contactos> PreGuardado2(Contactos items)
        {
            string consulta = "IF EXISTS(SELECT nombre, apellidopaterno, apellidomaterno, correo " +
                "FROM contactos " +
                "WHERE nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno LIKE @nombre " +
                "OR correo LIKE @correo " +
                "AND idconfiguracion=@idconfiguracion) " +
            "BEGIN " +
            "   SELECT nombre, apellidopaterno, apellidomaterno, correo " +
            "   FROM contactos " +
            "   WHERE nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno LIKE @nombre " +
            "   OR correo LIKE @correo " +
            "   AND idconfiguracion=@idconfiguracion; " +
            "END";
            b.ExecuteCommandQuery(consulta);
            string nom = items.Nombre.ToUpper() + " " + items.ApellidoPaterno.ToUpper() + " " + items.ApellidoMaterno.ToUpper();
            b.AddParameter("@nombre", "%" + nom + "%", SqlDbType.NVarChar);
            b.AddParameter("@correo", "%" + items.Correo + "%", SqlDbType.NVarChar);

            b.AddParameter("@idconfiguracion", items.IdConfiguracion, SqlDbType.Int);
            List<Contactos> resultado = new List<Contactos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Contactos item = new Contactos();
                item.Nombre = reader["Nombre"].ToString();
                item.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                item.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                item.Correo = reader["Correo"].ToString();
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Agregar contacto de todas formas, sin importar si esta duplicado, devuelve el id asignado
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        protected int Agregar2(Contactos items)
        {
            string consulta =
            "INSERT INTO contactos (nombre,apellidopaterno,apellidomaterno,correo,telefono,celular,usuarioalta) " +
            "VALUES(@nombre,@apellidopaterno,@apellidomaterno,@correo,@telefono,@celular,@usuarioalta); " +
            "SELECT @@IDENTITY";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@celular", items.Celular, SqlDbType.NVarChar);
            b.AddParameter("@usuarioalta", items.UsuarioAlta, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        //Modificar
        protected int Modificar(Contactos items)
        {
            string consulta = "UPDATE CONTACTOS SET nombre=@nombre, apellidopaterno=@apellidopaterno, apellidomaterno=@apellidomaterno," +
            "correo=@correo,telefono=@telefono,celular=@celular,direccion=@direccion, cp=@cp,ciudad=@ciudad,estado=@estado,cargo=@cargo,fechacumpleaños=@fechacumpleaños," +
            "tipocontacto=@tipocontacto, notas=@notas, activo=@activo ";
            if (items.Pais > 0)
                consulta += ",pais=@pais ";
            if (items.IdUDN > 0)
                consulta += ",idudn=@idudn ";
            if (items.IdArea > 0)
                consulta += ",idarea=@idarea ";
            consulta += " WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno == "" ? "" : items.ApellidoPaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno == "" ? "" : items.ApellidoMaterno.ToUpper(), SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar);
            b.AddParameter("@telefono", items.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@celular", items.Celular, SqlDbType.NVarChar);
            b.AddParameter("@direccion", items.Direccion, SqlDbType.NVarChar);
            b.AddParameter("@cp", items.CP, SqlDbType.NVarChar, 5);
            b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            if (items.Pais > 0)
                b.AddParameter("@pais", items.Pais, SqlDbType.Int);
            b.AddParameter("@cargo", string.IsNullOrEmpty(items.Cargo) ? "" : items.Cargo, SqlDbType.NVarChar);
            b.AddParameter("@fechacumpleaños", string.IsNullOrEmpty(items.FechaCumpleaños) ? "" : items.FechaCumpleaños, SqlDbType.NVarChar);
            b.AddParameter("@tipocontacto", items.TipoContacto, SqlDbType.Int);
            b.AddParameter("@notas", items.Notas, SqlDbType.NVarChar);
            if (items.IdUDN > 0)
                b.AddParameter("@idudn", items.IdUDN, SqlDbType.Int);
            if (items.IdArea > 0)
                b.AddParameter("@idarea", items.IdArea, SqlDbType.Int);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        protected int ModificarContactoUsuario(Contactos items)
        {
            b.ExecuteCommandQuery("UPDATE contactos SET ContactoUsuario=1, IdUsuarioResponsable=@nuevo WHERE id=@id");
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            b.AddParameter("@nuevo", items.IdUsuarioResponsable, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        //Eliminar
        protected int EliminarContactoDeOportunidad(string idcontacto, string idoportunidad)
        {
            b.ExecuteCommandQuery("DELETE FROM oportunidadescontactos WHERE idoportunidad=@idoportunidad AND idcontacto=@idcontacto");
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            b.AddParameter("@idcontacto", idcontacto, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

    }
}