﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLDeposito
    {

        DALDeposito GestorDeposito = new DALDeposito();

        public List<Deposito> DepositoTraerTodos()
        {
            return GestorDeposito.DepositoTraerTodos();
        }

    }
}
