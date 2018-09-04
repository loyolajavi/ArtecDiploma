using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLRendicion
    {

        DALRendicion GestorRendicion = new DALRendicion();

        public Rendicion AdquisicionesConBienesPorIdPartida(int NroPartida)
        {
            return GestorRendicion.AdquisicionesConBienesPorIdPartida(NroPartida);
        }


        public int RendicionTraerIdRendPorIdPartida(int IdPartida)
        {
            return GestorRendicion.RendicionTraerIdRendPorIdPartida(IdPartida);
        }


        public int RendicionCrear(Rendicion unaRendicion)
        {
            int IdRendAUX = GestorRendicion.RendicionCrear(unaRendicion);
            if (IdRendAUX > 0 )
                return IdRendAUX;
            return 0;
            //Retorno el idRendicion para dps usarlo en el nombre del documento a generar
        }



        public void RendicionModificar(Rendicion unaRendicion)
        {
            GestorRendicion.RendicionModificar(unaRendicion);
        }





        public List<Rendicion> RendicionBuscar(string IdRendicion = null, string IdPartida = null, string IdSolicitud = null, string NombreDependencia = null)
        {
            return GestorRendicion.RendicionBuscar(IdRendicion, IdPartida, IdSolicitud, NombreDependencia);
        }

        public bool RendicionEliminar(Rendicion unaRendicion)
        {
            try
            {
                if (GestorRendicion.RendicionEliminar(unaRendicion.IdRendicion))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
