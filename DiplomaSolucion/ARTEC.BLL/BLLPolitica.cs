using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLPolitica
    {

        //DALPolitica GestorPolitica = new DALPolitica();

        //public Politica PoliticaTraerPorTipoDepYCat(int idDependencia, int Categ)
        //{
        //    int unTipoDep;
        //    DALTipoDependencia GestorTipoDep = new DALTipoDependencia();
        //    unTipoDep = GestorTipoDep.TipoDependenciaTraerPorDependencia(idDependencia).IdTipoDependencia;

        //    return GestorPolitica.PoliticaTraerPorTipoDepYCat(unTipoDep, Categ);
        //}

        //public bool VerificarPolitica(int idDependencia, int Categ, int CantSolicitadaActual)
        
        //{

        //    int CantPermitida = PoliticaTraerPorTipoDepYCat(idDependencia, Categ).Cantidad;

        //    if (CantPermitida == 1)
        //    {
        //        return false;
        //    }
        //    else if (CantPermitida > 1)
        //    {
        //        int CantidadAcumulada = PoliticaPorCantidad(idDependencia, Categ);
        //        CantidadAcumulada = CantidadAcumulada + CantSolicitadaActual;
        //        if (CantidadAcumulada > CantPermitida)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    return true;
        //}



        //public int PoliticaPorCantidad(int idDependencia, int Categ)
        //{

        //    int Cnt = GestorPolitica.PoliticaPorDepYCategCantidad(idDependencia, Categ);
        //    return Cnt;
        //}


    }
}
