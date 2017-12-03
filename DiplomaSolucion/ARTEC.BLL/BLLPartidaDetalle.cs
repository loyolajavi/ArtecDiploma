using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLPartidaDetalle
    {

        DALPartidaDetalle GestorPartidaDetalle = new DALPartidaDetalle();


        public List<SolicDetalle> CategoriaDetBienesTraerPorIdPartida(int IdPartida, EstadoSolicDetalle.EnumEstadoSolicDetalle estadoSolic)
        {
            return GestorPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(IdPartida, estadoSolic);
        }


        public List<ENTIDADES.Helpers.HLPDetallesAdquisicion> InventarioAdquiridoCantPorPartDetalle(int IdPartida)
        {
            return GestorPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(IdPartida);
        }

        public int PartidaDetalleUIDPorIdCategoriaIdPartida(int NroPart, int IdCat)
        {
            return GestorPartidaDetalle.PartidaDetalleUIDPorIdCategoriaIdPartida(NroPart, IdCat);
        }


        public PartidaDetalle SolicDetallePartidaDetalleAsociacionTraer(int IdSolic, int IdSolicDetalle)
        {
            return GestorPartidaDetalle.SolicDetallePartidaDetalleAsociacionTraer(IdSolic, IdSolicDetalle);
        }



    }
}
