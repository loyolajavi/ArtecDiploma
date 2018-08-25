using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLPartida
    {

        DALPartida GestorPartida = new DALPartida();

        public decimal TraerLimitePartida()
        {
            return GestorPartida.TraerLimitePartida();
        }



        public bool PartidaCrear(Partida laPartida)
        {
            if (GestorPartida.PartidaCrear(laPartida) > 0)
            {
                return true;
            }

            return false;
        }



        public List<Partida> PartidaTraerPorNroPart(int NroPart)
        {
            return GestorPartida.PartidaTraerPorNroPart(NroPart);
        }



        public bool PartidaAsociar(Partida laPartida)
        {
            if (GestorPartida.PartidaAsociar(laPartida))
            {
                BLLSolicDetalle ManagerSolicDetalle = new BLLSolicDetalle();
                foreach (PartidaDetalle unDetPart in laPartida.unasPartidasDetalles)
                {
                    ManagerSolicDetalle.SolicDetalleUpdateEstado(unDetPart.SolicDetalleAsociado.IdSolicitud, unDetPart.SolicDetalleAsociado.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Comprar);    
                }
                return true;
            }
                
            return false;
        }


        public List<Partida> PartidasBuscarPorIdSolicitud(int NroPart)
        {
            return GestorPartida.PartidasBuscarPorIdSolicitud(NroPart);
        }


        public int? RelPDetAdqPartidaTieneAdq(int IdPart)
        {
            return GestorPartida.RelPDetAdqPartidaTieneAdq(IdPart);
        }

        public bool PartidaModifMontoSolic(int IdPartida, decimal MontoSolic)
        {
            if (GestorPartida.PartidaModifMontoSolic(IdPartida, MontoSolic))
                return true;
            return false;
        }

        public bool PartidaModifDetalles(List<PartidaDetalle> PDetallesBorrar)
        {
            if (GestorPartida.PartidaModifDetalles(PDetallesBorrar))
                return true;
            return false;
        }





    }
}
