using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.DAL.Servicios
{
    public class DALFamilia
    {


        public void FamiliaTraerFamiliasHijas(ARTEC.ENTIDADES.Servicios.IFamPat unaFamilia)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat)
			};

            SqlParameter[] parameters2 = new SqlParameter[]
			{
                new SqlParameter("@IdFamilia", unaFamilia.IdIFamPat)
			};

            try
            {
                //Busco las familias que contenga la FAMILIA en revisión y llamo a Agregar de la Entidad Familia y queda guardado en el argumento, por lo que no tengo q retornar nada
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaTraerFamiliasHijas", parameters))
                {
                    List<IFamPat> unasFamiliasHijas = new List<IFamPat>();
                    unasFamiliasHijas = DALUsuario.MapearFamilias(ds);

                    foreach (IFamPat FamiliaHija in unasFamiliasHijas)
                    {
                        unaFamilia.Agregar(FamiliaHija);
                    }
                }
                //IDEM anterior pero con patentes.. Busco las patentes que contenga la FAMILIA en revisión y llamo a Agregar de la Entidad Familia y queda guardado en el argumento, por lo que no tengo q retornar nada
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "FamiliaTraerPatentes", parameters2))
                {
                    List<IFamPat> unasPatentes = new List<IFamPat>();
                    unasPatentes = DALUsuario.MapearPatentes(ds);

                    foreach (IFamPat unaPatente in unasPatentes)
                    {
                        unaFamilia.Agregar(unaPatente);
                    }
                }



                  

            }
            catch (Exception es)
            {
                throw;
            }


        }


    }
}
