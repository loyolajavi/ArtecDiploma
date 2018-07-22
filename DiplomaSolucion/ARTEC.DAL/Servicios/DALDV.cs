using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.DAL.Servicios
{
    public class DALDV
    {
        public bool DVActualizarDVH(int IdFila, long Acum, string NomTabla, string NomColumnaWhere)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", NomTabla),
                new SqlParameter("IdFila", IdFila),
                new SqlParameter("ValorAcum", Acum),
                new SqlParameter("NomColumna", NomColumnaWhere)
            };

            try
            {
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DVActualizarDVH", parameters);
                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (FilasAfectadas > 0)
                    return true;
                return false;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
            //        FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}
        }


    }
}
