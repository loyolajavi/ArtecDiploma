using System;
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
    public class DALHardware
    {

        public List<Hardware> TraerHardware()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "HardwareTraerHardware"))
            {
                List<Hardware> unosHard = new List<Hardware>();
                unosHard = FRAMEWORK.Persistencia.Mapeador.Mapear<Hardware>(ds);
                return unosHard;
            }
        }



        public int BienTraerIdPorDescripMarcaModelo(int IdCat, int IdMarca, int IdModelo)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdCategoria", IdCat),
                new SqlParameter("@IdMarca", IdMarca),
                new SqlParameter("@IdModelo", IdModelo)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int ResIdBien = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "BienTraerIdPorDescripMarcaModelo", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return ResIdBien;

            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }


    }
}
