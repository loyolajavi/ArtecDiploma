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
        DALFamilia GestorFamilia = new DALFamilia();

        public void FamiliaTraerSubPermisos(List<IFamPat> unasFamilias)
        {
            try
            {
                //Por cada familia/patente reviso si tiene subpermisos para agregarselos
                foreach (IFamPat unaFamilia in unasFamilias)
                {
                    GestorFamilia.FamiliaTraerFamiliasHijas(unaFamilia);
                }


            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "FamiliaTraerSubPermisos");
                throw;
            }
        }

        public List<IFamPat> PermisosTraerTodos()
        {
            try
            {
                return GestorFamilia.PermisosTraerTodos();
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "PermisosTraerTodos");
                throw;
            }
        }



    }
}
