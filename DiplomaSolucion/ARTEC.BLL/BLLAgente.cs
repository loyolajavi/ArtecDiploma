﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;
using ARTEC.BLL.Servicios;

namespace ARTEC.BLL
{
    public class BLLAgente
    {

        DALAgente GestorAgente = new DALAgente();

        //public List<Agente> AgenteTraerTodos()
        //{
        //    return GestorAgente.AgenteTraerTodos();
        //}


        public List<Agente> AgentesTraerTodos()
        {
            return GestorAgente.AgentesTraerTodos();
        }

        public int AgenteCrear(Agente NuevoAgente, int IdDep)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Agente Crear" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                int IdAgenteNuevo = GestorAgente.AgenteCrear(NuevoAgente, IdDep);
                if (IdAgenteNuevo > 0)
                    return IdAgenteNuevo;
                return 0;
            }
            catch (Exception es)
            {
                throw;
            }
           

        }

        public Agente AgenteBuscar(string ApellidoAgente)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Agente Buscar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                return GestorAgente.AgenteBuscar(ApellidoAgente);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Dependencia> AgenteTraerDependencias(int IdAgente)
        {
            try
            {
                return GestorAgente.AgenteTraerDependencias(IdAgente);
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public Cargo AgenteTraerCargoPorDep(Dependencia unaDependencia, int IdAgente)
        {
            try
            {
                return GestorAgente.AgenteTraerCargoPorDep(unaDependencia, IdAgente);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool AgenteModificar(Agente unAgente)
        {
            try
            {
                if (!BLLFamilia.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Agente Modificar" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                if (GestorAgente.AgenteModificar(unAgente))
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