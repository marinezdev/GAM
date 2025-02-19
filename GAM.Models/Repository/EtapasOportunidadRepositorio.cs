﻿using GAM.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace GAM.Models.Repository
{
    /// <summary>
    /// Clase CRUD
    /// </summary>
    public class EtapasOportunidadRepositorio
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        /// <summary>
        /// Otiene las etapas por las que pasa un tema para visualizarle en un gráfico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected List<EtapasOportunidad> SeleccionarPorIdOportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT eo.Etapa, eo.Fecha " +
            "FROM EtapasOportunidad eo " +
            "INNER JOIN Oportunidades opo ON opo.id = eo.IdOportunidad " +
            "WHERE opo.id=@id " +
            "ORDER BY eo.fecha");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<EtapasOportunidad> resultado = new List<EtapasOportunidad>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                EtapasOportunidad item = new EtapasOportunidad();
                item.Etapa = int.Parse(reader["Etapa"].ToString());
                item.Fecha = DateTime.Parse(reader["Fecha"].ToString());

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected List<EtapasOportunidad> SeleccionarEtapasEstadoPorIdOportunidad(string id)
        {
            b.ExecuteCommandQuery("SELECT Etapa, Completada " +
            "FROM EtapasOportunidad " +
            "WHERE idoportunidad=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            List<EtapasOportunidad> resultado = new List<EtapasOportunidad>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                EtapasOportunidad item = new EtapasOportunidad();
                item.Etapa = int.Parse(reader["Etapa"].ToString());
                item.Completada = int.Parse(reader["Completada"].ToString());

                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        protected string SelecccionarSiEtapaCompletada(string id, string etapa)
        {
            b.ExecuteCommandQuery("SELECT Completada FROM EtapasOportunidad WHERE idoportunidad=@id AND etapa=@etapa");
            b.AddParameter("@id", id, SqlDbType.Int);
            b.AddParameter("@etapa", etapa, SqlDbType.Int);
            return b.SelectString();
        }

        /// <summary>
        /// Agrega una nueva etapa para seguimiento
        /// </summary>
        /// <param name="idoportunidad">Oportunidad que cambia sus etapas</param>
        /// <param name="etapa">Número de etapa a agregar</param>
        /// <returns></returns>
        protected int Agregar(string idoportunidad, string etapa)
        {
            b.ExecuteCommandQuery("INSERT INTO etapasoportunidad (idoportunidad, etapa) VALUES(@idoportunidad, @etapa)");
            b.AddParameter("@idoportunidad", idoportunidad, SqlDbType.Int);
            b.AddParameter("@etapa", etapa, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        /// <summary>
        /// Actualiza el completado de una etapa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected int Modificar(string id, string etapa)
        {
            b.ExecuteCommandQuery("UPDATE etapasoportunidad SET completada=1, fechacompletada=getdate() WHERE idoportunidad=@id AND etapa=@etapa");
            b.AddParameter("@id", id, SqlDbType.Int);
            b.AddParameter("@etapa", etapa, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }


    }
}