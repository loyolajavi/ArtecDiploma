﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLAdquisicion
    {

        DALAdquisicion GestorAdquisicion = new DALAdquisicion();
        BLLInventarioHard ManagerInventarioHard = new BLLInventarioHard();
        BLLInventarioSoft ManagerInventarioSoft = new BLLInventarioSoft();

        public void AdquisicionCrear(Adquisicion unaAdquisicion)
        {
            try
            {
                GestorAdquisicion.ComenzarAdquisicion();
                int IdAdq = GestorAdquisicion.AdquisicionCrear(unaAdquisicion);
                foreach (Bien unBien in unaAdquisicion.BienesInventarioAsociados)
                {
                    if (unBien is Hardware)
                    {
                        ManagerInventarioHard.InventarioHardCrear(unBien as Hardware, IdAdq);
                    }
                    else
                    {
                        ManagerInventarioSoft.InventarioSoftCrear(unBien as Software, IdAdq);
                    }
                }
                GestorAdquisicion.ConfirmarAdquisicion();
            }
            catch (Exception)
            {
                GestorAdquisicion.CancelarAdquisicion();
                throw;
            }
            finally
            {
                GestorAdquisicion.TerminarAdquisicion();
            }


            
            
        }

    }
}
