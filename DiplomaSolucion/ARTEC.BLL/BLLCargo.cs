﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLCargo
    {

        DALCargo GestorCargo = new DALCargo();

        public List<Cargo> CargosTraerTodos()
        {
            return GestorCargo.CargosTraerTodos();
        }

    }
}