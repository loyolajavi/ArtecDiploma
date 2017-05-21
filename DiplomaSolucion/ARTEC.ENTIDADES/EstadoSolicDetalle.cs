﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class EstadoSolicDetalle
    {

        public int IdEstadoSolicDetalle { get; set; }
        public string DescripEstadoSolicDetalle { get; set; }

        public enum EnumEstadoSolDetalle
        {
            Pendiente, Solucionado, Cerrado
        }

        public override string ToString()
        {
            return this.DescripEstadoSolicDetalle;
        }


    }
}