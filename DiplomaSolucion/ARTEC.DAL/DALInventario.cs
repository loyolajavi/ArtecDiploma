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

        public static int InventarioEntregadoPorSolicDetalle(int IdSolicitudDetalle, int IdSolicitud)
        {
            SqlParameter[] parametersInvCantEntregado = new SqlParameter[]
			{
                new SqlParameter("@IdSolicitud", IdSolicitud),
                new SqlParameter("@IdSolicitudDetalle", IdSolicitudDetalle)
			};

            int CantInv = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "InventarioEntregadoPorSolicDetalle", parametersInvCantEntregado);
            return CantInv;
        }


    }
}
