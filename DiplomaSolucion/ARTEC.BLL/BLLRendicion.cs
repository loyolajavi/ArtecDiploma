using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;

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


        public int RendicionCrear(Rendicion unaRendicion, Partida unaPartida)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Rendicion Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                int IdRendAUX = GestorRendicion.RendicionCrear(unaRendicion, unaPartida);
                if (IdRendAUX > 0)
                    //Retorno el idRendicion para dps usarlo en el nombre del documento a generar
                    return IdRendAUX;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void RendicionModificar(Rendicion unaRendicion)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Rendicion Regenerar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorRendicion.RendicionModificar(unaRendicion);
            }
            catch (Exception)
            {
                throw;
            }
            
        }





        public List<Rendicion> RendicionBuscar(string IdRendicion = null, string IdPartida = null, string IdSolicitud = null, string NombreDependencia = null)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Rendicion Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorRendicion.RendicionBuscar(IdRendicion, IdPartida, IdSolicitud, NombreDependencia);
            }
            catch (Exception es)
            {
                throw;
            }
            
        }

        public void RendicionEliminar(Rendicion unaRendicion, Partida unaPartida)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Rendicion Eliminar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                GestorRendicion.RendicionEliminar(unaRendicion.IdRendicion, unaPartida);
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
