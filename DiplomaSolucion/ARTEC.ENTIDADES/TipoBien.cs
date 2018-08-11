using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES
{
    public class TipoBien
    {

        public int IdTipoBien { get; set; }
        public string DescripTipoBien { get; set; }

        public enum EnumTipoBien
        {
            Hard = 1, Soft = 2
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.DescripTipoBien))
            {
                return this.DescripTipoBien;
            }
            return "";
        }


    }
}
