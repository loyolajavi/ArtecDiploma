﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLInventario
    {

        DALInventario GestorInventario = new DALInventario();
        BLLInventarioHard GestorInvHard = new BLLInventarioHard();
        BLLInventarioSoft GestorInvSoft = new BLLInventarioSoft();

        public List<Inventario> InventariosTraerListosParaAsignar(int IdSolicitud)
        {
            return GestorInventario.InventariosTraerListosParaAsignar(IdSolicitud);
        }


        public IEnumerable<Bien> InventariosTraerListosParaAsignarPorSolicDetalle(SolicDetalle unSolicDet, int IdCategoria)
        {
            //return GestorInventario.InventariosTraerListosParaAsignarPorSolicDetalle(IdSolicitud, IdSolDetalle);

            TipoBien unTipoBienAux = new TipoBien();
            BLLTipoBien managerTipoBienAux = new BLLTipoBien();
            unTipoBienAux = managerTipoBienAux.TipoBienTraerTipoBienPorIdCategoria(IdCategoria);

            if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                return GestorInvHard.InventarioHardTraerListosParaAsignar(unSolicDet);
            else
                //return GestorInvSoft.InventarioHardTraerListosParaAsignar(unSolicDet);
                return GestorInvSoft.InventarioSoftTraerListosParaAsignar(unSolicDet);

        }

        

    }
}
