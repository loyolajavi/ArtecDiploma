﻿using ARTEC.DAL.Servicios;
using ARTEC.ENTIDADES.Servicios;
using ARTEC.FRAMEWORK.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.BLL.Servicios
{
    public class BLLFamilia
    {
        DALFamilia GestorFamilia = new DALFamilia();

        public void FamiliaTraerSubPermisos(List<IFamPat> unasFamilias)
        {
            try
            {
                //Por cada familia/patente reviso si tiene subpermisos para agregarselos
                foreach (IFamPat unaFamilia in unasFamilias)
                {
                    GestorFamilia.FamiliaTraerFamiliasHijas(unaFamilia);
                }


            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "FamiliaTraerSubPermisos");
                throw;
            }
        }


        public void FamiliaUnaTraerSubPermisos(IFamPat unaFamilia)
        {
            try
            {
                //Reviso si tiene subpermisos para agregarselos
                GestorFamilia.FamiliaTraerFamiliasHijas(unaFamilia);
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "FamiliaUnaTraerSubPermisos");
                throw;
            }
        }

        public List<IFamPat> PermisosTraerTodos()
        {
            try
            {
                List<IFamPat> unasFamilias;
                unasFamilias = GestorFamilia.PermisosTraerTodos();
                FamiliaTraerSubPermisos(unasFamilias);
                return unasFamilias;
            }
            catch (Exception es)
            {
                string IdError = ServicioLog.CrearLog(es, "PermisosTraerTodos");
                throw;
            }
        }




        public bool FamiliaCrear(IFamPat nuevaFamilia)
        {
            try
            {
                if (GestorFamilia.FamiliaCrear(nuevaFamilia))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public Familia FamiliaBuscar(string NombreIFamPat)
        {
            try
            {
                return GestorFamilia.FamiliaBuscar(NombreIFamPat);
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool FamiliaModificar(IFamPat AModifFamilia, List<IFamPat> FamQuitarMod, List<IFamPat> FamAgregarMod)
        {
            try
            {
                if (GestorFamilia.FamiliaModificar(AModifFamilia, FamQuitarMod, FamAgregarMod))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool FamiliaEliminar(Familia unafamilia)
        {
            try
            {
                //if (GestorFamilia.FamiliaEliminar(unafamilia.IdIFamPat))
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<ENTIDADES.Usuario> FamiliaUsuariosComprometidos(int IdFamilia)
        {
            try
            {
                return GestorFamilia.FamiliaUsuariosComprometidos(IdFamilia);
            }
            catch (Exception es)
            {
                throw;
            }
        }
    }
}
