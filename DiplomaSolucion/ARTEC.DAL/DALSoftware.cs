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
    public class DALSoftware
    {




        public int BienTraerIdPorDescripMarcaModelo(Bien unBien)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdCategoria", unBien.unaCategoria.IdCategoria),
                new SqlParameter("@IdTipoBien", Bien.elTipoBien.Software),
                new SqlParameter("@IdMarca", unBien.unaMarca.IdMarca),
                new SqlParameter("@IdModelo", unBien.unModelo.IdModeloVersion)
			};


            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int ResIdBien = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "BienTraerIdPorDescripMarcaModelo", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return ResIdBien;
                
            }
            catch (Exception)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }

        }


    }
}
