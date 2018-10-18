using ARTEC.ENTIDADES.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioPermisos
    {

        public static bool BuscarPermiso(List<IFamPat> PermisosVer, string[] unTagControl)
        {
            foreach (var unTag in unTagControl)
            {
                foreach (IFamPat unPermiso in PermisosVer)
                {
                    if (unPermiso.CantHijos > 0)
                    {
                        if (BuscarSubPermisos((unPermiso as Familia).ElementosFamPat, unTag))
                            return true;
                    }
                    else
                        if (unPermiso.NombreIFamPat == unTag)
                            return true;
                }
            }
            return false;
        }


        public static bool BuscarSubPermisos(List<IFamPat> PermisosVer, string unTagControl)
        {
            bool Res = false;
            foreach (IFamPat unPer in PermisosVer)
            {
                if (unPer.CantHijos > 0)
                {
                    if (BuscarSubPermisos((unPer as Familia).ElementosFamPat, unTagControl))
                    {
                        Res = true;
                        break;
                    }
                }
                else
                {
                    if (unPer.NombreIFamPat == unTagControl)
                    {
                        Res = true;
                        break;
                    }
                }
            }
            return Res;
        }

    }
}
