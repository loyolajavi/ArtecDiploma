﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.DAL;
using ARTEC.DAL.Servicios;

namespace ARTEC.BLL.Servicios
{
    public class BLLServicioMail
    {

        DALServicioMail GestorServicioMail = new DALServicioMail();

        public static void CargarMailConfig()
        {
            try
            {
                DALServicioMail.CargarMailConfig();
            }
            catch (Exception es)
            {
                throw;
            }
            
        }

        public void ModificarMailConfig(string unMail, string unPass, int unPuerto, string unHost, bool unSSL)
        {
            try
            {
                GestorServicioMail.ModificarMailConfig(unMail, unPass, unPuerto, unHost, unSSL);
            }
            catch (Exception es)
            {
                throw;
            }
        }

    }
}
