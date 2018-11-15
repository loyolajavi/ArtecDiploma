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
    public class DALMarca
    {

        public List<Marca> MarcaTraerPorIdCategoria(int IdCat)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", IdCat)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "MarcaTraerPorIdCategoria", parameters))
            {
                List<Marca> unaLista = new List<Marca>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Marca>(ds);
                return unaLista;
            }
        }


        public void MarcaCrear(Bien NuevoBien, int IdTipoBien)
        {
            SqlParameter[] parametersMarcaCrear = new SqlParameter[]
			{
                new SqlParameter("@DescripMarca", NuevoBien.unaMarca.DescripMarca)
			};

            try
            {
                //Crear MARCA
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "MarcaCrear", parametersMarcaCrear);
                int IdMarcaRes = Decimal.ToInt32(Resultado);
                NuevoBien.unaMarca.IdMarca = IdMarcaRes;

                //Crear MODELO
                SqlParameter[] parametersModeloCrear = new SqlParameter[]
			    {
                    new SqlParameter("@DescripModelo", NuevoBien.unModelo.DescripModeloVersion)
			    };
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
