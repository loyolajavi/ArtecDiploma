﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLRendicion
    {

        DALRendicion GestorRendicion = new DALRendicion();

        public Rendicion AdquisicionesConBienesPorIdPartida(int NroPartida)
        {
            return GestorRendicion.AdquisicionesConBienesPorIdPartida(NroPartida);
        }

    }
}