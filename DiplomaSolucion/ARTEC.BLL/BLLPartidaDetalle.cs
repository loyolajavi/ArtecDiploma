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


        public List<SolicDetalle> CategoriaDetBienesTraerPorIdPartida(int IdPartida)
        {
            return GestorPartidaDetalle.CategoriaDetBienesTraerPorIdPartida(IdPartida);
        }


        public List<ENTIDADES.Helpers.HLPDetallesAdquisicion> InventarioAdquiridoCantPorPartDetalle(int IdPartida)
        {
            return GestorPartidaDetalle.InventarioAdquiridoCantPorPartDetalle(IdPartida);
        }

        public int PartidaDetallePorIdCategoriaIdPartida(int NroPart, int IdCat)
        {
            return GestorPartidaDetalle.PartidaDetallePorIdCategoriaIdPartida(NroPart, IdCat);
        }
    }
}
