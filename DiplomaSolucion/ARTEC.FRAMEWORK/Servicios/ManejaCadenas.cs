using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ManejaCadenas
    {

        public static List<string> SepararTexto(string texto, char plimitador)
        {

            List<string> lista = new List<string>();

            string[] vector = null;

            vector = texto.Split(plimitador);



            for (int j = vector.GetLowerBound(0); j <= vector.GetUpperBound(0); j++)
            {
                if (!(string.IsNullOrWhiteSpace(vector[j])))
                {
                    lista.Add(vector[j]);
                }


            }

            return lista;



        }

    }
}
