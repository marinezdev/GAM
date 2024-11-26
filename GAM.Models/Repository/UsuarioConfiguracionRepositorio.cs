using GAM.Models.Models;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class UsuarioConfiguracionRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        /// <summary>
        /// Se une el usuario y la configuracion a la que pertenecerá
        /// </summary>
        /// <param name="idusuario"></param>
        /// <param name="idconfiguracion"></param>
        /// <returns></returns>
        protected int Agregar(string idusuario, string idconfiguracion)
        {
            b.ExecuteCommandQuery("INSERT INTO usuarioconfiguracion VALUES(@idusuario,@idconfiguracion)");
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            b.AddParameter("@idconfiguracion", idconfiguracion, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}