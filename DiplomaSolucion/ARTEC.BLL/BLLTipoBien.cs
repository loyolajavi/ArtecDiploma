using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.DAL;
using ARTEC.ENTIDADES;

namespace ARTEC.BLL
{
    public class BLLTipoBien
    {

        DALTipoBien GestorTipoBien;
        
        public BLLTipoBien()
        {
            GestorTipoBien = new DALTipoBien();
        }

        public List<TipoBien> TraerTodos()
        {
            return GestorTipoBien.TraerTodos();
        }


        public List<TipoBien> TipoBienTraerTipoBienPorIdCategoria(int idCategoria)
        {
            return GestorTipoBien.TipoBienTraerTipoBienPorIdCategoria(idCategoria);
        }



    }
}
