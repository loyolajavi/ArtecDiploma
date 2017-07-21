using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLAsignacion
    {

        DALAsignacion GestorAsignacion = new DALAsignacion();
        DALInventario GestorInventario = new DALInventario();
        DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();

        public bool AsignacionCrear(Asignacion unaAsig)
        {
            try
            {
                if (GestorAsignacion.AsignacionCrear(unaAsig) > 0)
                {
                    foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                    {
                        
                        if (item.SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud))
                        {
                            GestorSolicDetalle.SolicDetalleUpdateEstado(item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado);
                        }
                    }
                }
                return true;
            }
            catch (Exception es)
            {
                return false;    
                throw;
            }
            
               
            
        }

    }
}
