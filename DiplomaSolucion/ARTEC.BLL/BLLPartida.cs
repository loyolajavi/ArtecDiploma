﻿using System;
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

    }
}
