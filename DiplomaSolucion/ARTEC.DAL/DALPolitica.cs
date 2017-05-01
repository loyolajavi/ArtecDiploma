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
    public class DALPolitica
    {

        public Politica PoliticaTraerPorTipoDepYCat(int unTipoDep, int Categ)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDependencia", unTipoDep),
                new SqlParameter("@IdCategoria", Categ),
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "PoliticaTraerPorTipoDepYCat", parameters))
            {
                Politica unaLista = new Politica();
                unaLista = FRAMEWORK.Persistencia.Mapeador.MapearUno<Politica>(ds);
                return unaLista;
            }
        }

        public int PoliticaPorDepYCategCantidad(int unTipoDep, int Categ)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", unTipoDep),
                new SqlParameter("@IdCategoria", Categ),
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "PoliticaPorDepYCategCantidad", parameters);
                int CantDevuelta = Resultado;
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return CantDevuelta;
            }
            catch (Exception es)
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
