﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;



namespace ARTEC.BLL
{
    public class BLLDependencia
    {

        //public List<ENTIDADES.Dependencia> MostrarTodos()
        //{ 
            
        //}

        DALDependencia GestorDependencia = new DALDependencia();

        /// <summary>
        /// Traer todas las dependencias.
        /// </summary>
        /// <returns>List<Dependencia></returns>
        public List<Dependencia> TraerTodos()
        {

            //pruebaDAL.prueba();
            return GestorDependencia.TraerTodos();

        }

    }
}
