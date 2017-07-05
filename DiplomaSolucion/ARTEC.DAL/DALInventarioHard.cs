﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    public class DALInventarioHard
    {

        public void InventarioHardCrear(Hardware unBien, int IdAdq)
        {
            SqlParameter[] parametersInvHard = new SqlParameter[]
			{
                new SqlParameter("@IdBienEspecif", unBien.IdBien),
                new SqlParameter("@SerieKey ", unBien.unInventarioAlta.SerieKey),
                new SqlParameter("@IdAdquisicion", IdAdq),
                new SqlParameter("@IdDeposito", unBien.unInventarioAlta.unDeposito.IdDeposito),
                new SqlParameter("@IdEstadoInventario", unBien.unInventarioAlta.unEstado.IdEstadoInventario),
                new SqlParameter("@IdPartidaDetalle", unBien.unInventarioAlta.PartidaDetalleAsoc.IdPartidaDetalle),
                new SqlParameter("@IdPartida", unBien.unInventarioAlta.PartidaDetalleAsoc.IdPartida)
			};

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioHardCrear", parametersInvHard);

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}



        }




    }
}
