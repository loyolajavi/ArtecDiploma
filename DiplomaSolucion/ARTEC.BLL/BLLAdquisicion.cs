using System;
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
                //MODIFICAR STORE DE ADQUISICIONCREAR PORQUE FALTA IDPARTIDADETALLE Y QUIZAS OTROS MAS
                GestorAdquisicion.AdquisicionCrear(unaAdquisicion);
                foreach (Bien unBien in unaAdquisicion.BienesInventarioAsociados)
                {
                    if (unBien is Hardware)
                    {
                        ManagerInventarioHard.InventarioHardCrear(unBien as Hardware);
                    }
                    else
                    {
                        ManagerInventarioSoft.InventarioSoftCrear(unBien as Software);
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
