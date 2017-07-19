﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;

namespace ARTEC.DAL
{
    public class DALAsignacion
    {

        public int AsignacionCrear(Asignacion unaAsig)
        {
            DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Fecha", unaAsig.Fecha),
                new SqlParameter("@IdDependencia", unaAsig.unaDependencia.IdDependencia)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsignacionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                {

                    SqlParameter[] parametersAsigDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdAsigDetalle", item.IdAsigDetalle),
                        new SqlParameter("@IdAsignacion", IDDevuelto),
                        new SqlParameter("@IdInventario", item.unInventario.IdInventario),
                        new SqlParameter("@IdSolicitudDetalle", item.SolicDetalleAsoc.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsoc.IdSolicitud)
                        //VER TEMA DE HARD SOFT POR LO DEL AGENTE
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsigDetalleCrear", parametersAsigDetalles);
                    
                    //Actualizar Estado Inventario
                    if (!GestorEstadoInventario.InventarioEstadoUpdate(item.unInventario.IdInventario))
                    {
                        FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                        return 0;
                    }

                    if (item.SolicDetalleAsoc.Cantidad == DALInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud))
                    {
                        //ACA HAY QUE COLOCAR AL ESTADO DE SOLICDETALLE EN FINALIZADO
                        System.Windows.Forms.MessageBox.Show("Test");
                    }

                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return 0;
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }

    }
}
