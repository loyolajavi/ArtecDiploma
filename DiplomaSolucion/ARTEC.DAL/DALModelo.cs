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
    public class DALModelo
    {
        public List<ModeloVersion> ModeloTraerPorMarcaCategoria(int IdCat, int laMarca)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", IdCat),
                new SqlParameter("@IdMarca", laMarca)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "ModeloTraerPorMarcaCategoria", parameters))
            {
                List<ModeloVersion> unaLista = new List<ModeloVersion>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<ModeloVersion>(ds);
                return unaLista;
            }
        }


        public void ModeloCrear(Bien NuevoBien, int IdTipoBien)
        {
            try
            {
                //Crear MODELO
                SqlParameter[] parametersModeloCrear = new SqlParameter[]
			    {
                    new SqlParameter("@DescripModelo", NuevoBien.unModelo.DescripModeloVersion)
			    };
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var ResModelo = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "ModeloCrear", parametersModeloCrear);
                int IdModeloRes = Decimal.ToInt32(ResModelo);
                NuevoBien.unModelo.IdModeloVersion = IdModeloRes;

                //Crear BIEN
                SqlParameter[] parametersBienCrear = new SqlParameter[]
			    {
                    new SqlParameter("@IdCategoria", NuevoBien.unaCategoria.IdCategoria),
                    new SqlParameter("@IdMarca", NuevoBien.unaMarca.IdMarca),
                    new SqlParameter("@IdModeloVersion", NuevoBien.unModelo.IdModeloVersion)
			    };
                var ResBien = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "BienCrear", parametersBienCrear);
                int IdBienRes = Decimal.ToInt32(ResBien);
                NuevoBien.IdBien = IdBienRes;
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
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
