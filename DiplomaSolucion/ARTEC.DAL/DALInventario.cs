using System;
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
    public class DALInventario
    {

        public int InventarioEntregadoPorSolicDetalle(int IdSolicitudDetalle, int IdSolicitud)
        {
            SqlParameter[] parametersInvCantEntregado = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", IdSolicitudDetalle)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                int CantInv = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioEntregadoPorSolicDetalle", parametersInvCantEntregado);
                return CantInv;
            }
            catch (Exception es)
            {
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }


    }
}
