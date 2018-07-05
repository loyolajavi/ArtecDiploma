using ARTEC.DAL.Servicios;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.BLL.Servicios
{
    public class BLLFamilia
    {

        public void FamiliaTraerSubPermisos(List<IFamPat> unasFamilias)
        {

            DALFamilia GestorFamilia = new DALFamilia();

            try
            {

                foreach (IFamPat unaFamilia in unasFamilias)
                {
                    //List<IFamPat> FamiliasHijas = GestorFamilia.FamiliaTraerFamiliasHijas(unaFamilia);
                    GestorFamilia.FamiliaTraerFamiliasHijas(unaFamilia);
                }


            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "FamiliaTraerSubPermisos");
                throw;
            }
        }



    }
}
